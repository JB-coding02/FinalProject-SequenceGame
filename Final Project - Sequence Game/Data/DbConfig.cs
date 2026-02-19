using System;

namespace Final_Project___Sequence_Game
{
    public static class DbConfig
    {
        public static string GetConnectionString()
        {
            // single-line connection string for EF
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SequenceGameDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Command Timeout=30";
        }
    }
}
