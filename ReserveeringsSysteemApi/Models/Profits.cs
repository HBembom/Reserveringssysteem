using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MySqlConnector;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Models
{
    public class Profits
    {
        public double Profit { get; set; }
        [MaybeNull]
        public int Period { get; set; }
        internal DbConnector Connector { get; set; }
        public Profits(DbConnector connector)
        {
            Connector = connector;
        }

        public Profits() { } //Necessary for deserialization

        public async Task<Profits> SelectTotalProfit()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT SUM(TotalCost) FROM `reservations`";

            var res = await ReadAllOccupancies(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res[0] : null;
        }

        public async Task<Profits> SelectTotalProfitFromPeriod(string StartDate, string Endate)
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT SUM(TotalCost) FROM `reservations` WHERE ArrivalDate BETWEEN @StartDate AND @EndDate";
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@StartDate",
                DbType = DbType.String,
                Value = StartDate,
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@EndDate",
                DbType = DbType.String,
                Value = Endate,
            });

            var res = await ReadAllOccupancies(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res[0] : null;
        }
        public async Task<List<Profits>> SelectTotalProfitByPeriod()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT SUM(TotalCost), month(ArrivalDate) AS Period FROM `reservations` GROUP BY month(ArrivalDate) ORDER BY month(ArrivalDate) ";
            var res = await ReadAllOccupanciesByPeriod(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res : null;
        }

        private async Task<List<Profits>> ReadAllOccupancies(DbDataReader reader)
        {
            var profits = new List<Profits>();
            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var profit = new Profits(Connector)
                    {
                        Profit = reader.GetDouble(0)
                    };
                    profits.Add(profit);
                }
            }

            return profits;
        }
        private async Task<List<Profits>> ReadAllOccupanciesByPeriod(DbDataReader reader)
        {
            var profits = new List<Profits>();
            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var profit = new Profits(Connector)
                    {
                        Profit = reader.GetDouble(0),
                        Period = reader.GetInt32(1)
                    };
                    profits.Add(profit);
                }
            }

            return profits;
        }
    }

}
