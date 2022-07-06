using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Models
{
    public class Prices
    {
        public int PriceId { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public bool IsTax { get; set; }
        internal DbConnector Connector { get; set; }

        public Prices(DbConnector connector)
        {
            Connector = connector;
        }

        public Prices() { } //Necessary for deserialization

        public async Task InsertPrice()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = "INSERT INTO `prices` (Amount, Name, IsTax) VALUES (@Amount, @Name, @IsTax)";
            AddPricesParameters(command);
            await command.ExecuteNonQueryAsync();
            PriceId = (int)command.LastInsertedId;
        }

        public async Task<Prices> SelectPriceByName(string name)
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `prices` WHERE `Name` = @Name";
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Name",
                DbType = DbType.String,
                Value = name,
            });
            var res = await ReadAllPrices(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res[0] : null;
        }

        public async Task<List<Prices>> SelectAllPrices()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `prices`";
            var res = await ReadAllPrices(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res : null;
        }

        public async Task UpdatePriceById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"UPDATE `prices` SET Amount = @Amount, Name = @Name, IsTax = @IsTax WHERE PriceId = @PriceId";
            AddPricesParameters(command);
            AddPricesId(command);
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeletePriceById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"DELETE FROM `prices` WHERE PriceId = @PriceId";
            AddPricesId(command);
            await command.ExecuteNonQueryAsync();
        }

        private void AddPricesParameters(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"Amount",
                DbType = DbType.Double,
                Value = Amount
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"Name",
                DbType = DbType.String,
                Value = Name
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"IsTax",
                DbType = DbType.Boolean,
                Value = IsTax
            });
        }

        private void AddPricesId(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"PriceId",
                DbType = DbType.Int32,
                Value = PriceId
            });
        }

        private async Task<List<Prices>> ReadAllPrices(DbDataReader reader)
        {
            var prices = new List<Prices>();
            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var price = new Prices(Connector)
                    {
                        PriceId = reader.GetInt32(0),
                        Amount = reader.GetDouble(1),
                        Name = reader.GetString(2),
                        IsTax = reader.GetBoolean(3)
                    };
                    prices.Add(price);
                }
            }

            return prices;
        }
    }
}
