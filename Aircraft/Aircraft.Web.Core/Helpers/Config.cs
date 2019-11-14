using System;
using Microsoft.Extensions.Configuration;

namespace Aircraft.Web.Core.Helpers
{
    public static class Config
    {
        public static string GetConnectionString()
        {
            var dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            if (string.IsNullOrEmpty(dbConnection))
            {
                dbConnection = Statics.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("SqlDbConnection non exist");
            }

            return dbConnection;
        }

        public static string Get(string name)
        {
            return Statics.Configuration[name];
        }
    }
}