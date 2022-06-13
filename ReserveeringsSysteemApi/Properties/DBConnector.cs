using System;
using MySqlConnector;

namespace ReserveeringsSysteemApi.Properties
{
    public class DbConnector : IDisposable
    {
        public MySqlConnection Conn { get; }

        public DbConnector(string connStr)
        {
            Conn = new MySqlConnection(connStr);
        }

        public void Dispose() => Conn.Dispose();
    }
}
