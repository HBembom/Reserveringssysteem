using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using ReserveeringsSysteemApi.Controllers.Options;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Models
{
    public class Guests
    {
        public int GuestId { get; set; }
        public int AmountOfDays { get; set; }
        public string TypeOfGuest { get; set; }
        public double Price { get; set; }
        internal DbConnector Connector { get; set; }

        public Guests(DbConnector connector)
        {
            Connector = connector;
        }

        public Guests() { } //Necessary for deserialization

        public async Task InsertGuest()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = "INSERT INTO `guests` (AmountOfDays, TypeOfGuest, Price) VALUES (@AmountOfDays, @TypeOfGuest, @Price)";
            AddGuestsParameters(command);
            await command.ExecuteNonQueryAsync();
            GuestId = (int)command.LastInsertedId;
        }

        public async Task<Guests> SelectGuestById(int id)
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `guests` WHERE `GuestId` = @GuestId";
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@GuestId",
                DbType = DbType.Int32,
                Value = id,
            });
            var res = await ReadAllGuests(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res[0] : null;
        }

        public async Task<List<Guests>> SelectAllGuests()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"SELECT * FROM `guests`";
            var res = await ReadAllGuests(await command.ExecuteReaderAsync());

            return res.Count > 0 ? res : null;
        }

        public async Task UpdateGuestById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"UPDATE `guests` SET `AmountOfDays` = @AmountOfDays, `TypeOfGuest` = @TypeOfGuest, `Price` = @Price WHERE `GuestId` = @GuestId"
                                                               ;
            AddGuestsParameters(command);
            AddGuestsId(command);
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteGuestById()
        {
            await using var command = Connector.Conn.CreateCommand();
            command.CommandText = @"DELETE FROM `guests` WHERE GuestId = @GuestId";
            AddGuestsId(command);
            await command.ExecuteNonQueryAsync();
        }

        private void AddGuestsParameters(MySqlCommand command)
        {
         command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"AmountOfDays",
                DbType = DbType.Int32,
                Value = AmountOfDays
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"TypeOfGuest",
                DbType = DbType.String,
                Value = TypeOfGuest
            });
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"Price",
                DbType = DbType.Double,
                Value = Price
            });
        }

        private void AddGuestsId(MySqlCommand command)
        {
            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = @"GuestId",
                DbType = DbType.Int32,
                Value = GuestId
            });
        }

        private async Task<List<Guests>> ReadAllGuests(DbDataReader reader)
        {
            var guests = new List<Guests>();
            await using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var guest = new Guests(Connector)
                    {
                        GuestId = reader.GetInt32(0),
                        AmountOfDays = reader.GetInt32(1),
                        TypeOfGuest = reader.GetString(2),
                        Price = reader.GetDouble(3)
                    };
                    guests.Add(guest);
                }
            }

            return guests;
        }
    }
}
