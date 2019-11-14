using System;
using Aircraft.Web.Core.Db;

namespace Aircraft.Web.Core.Tools
{
    public static class Initialaizer
    {
        public static void CreateDb(bool forceDelete = true)
        {
            if (string.IsNullOrWhiteSpace(DBContext.ConnectionString))
            {
                throw new NullReferenceException("no connection string for init in DBContext.ConnectionString");
            }

            using (var context = new DBContext())
            {
                if (forceDelete)
                {
                    try
                    {
                        context.Database.EnsureDeleted();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("skip database delete");
                    }
                }

                context.Database.EnsureCreated();
            }
        }
    }
}