using Dapper;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.DBAccess
{
    public static class SqliteDataAccess
    {
        private static string CreateTableOrder = "create table if not exists `Users` ( `Name` text not null, `Password` text not null);";
        private static string CreateDefaultAdminOrder = "insert into Users(Name,Password) Values ('Admin','Admin')";

        public static void IsAvailable()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteUsersDatabasePath))
                {
                    int tmp = cnn.Execute(CreateTableOrder);

                    if (tmp == 0)
                    {
                        cnn.Execute(CreateDefaultAdminOrder);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        public static PersonModel ChceckUserPassword(string password)
        {
            PersonModel output = new PersonModel();

            try
            {
                string hashedPassword = Hash.HashFunc(password);
                string sql = $"select * from Users where Password = '{hashedPassword}';";

                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteUsersDatabasePath))
                {
                    output = cnn.QueryFirst<PersonModel>(sql, new { password });
                }
            }
            catch (Exception ex)
            {
                output = null;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");

            }


            return output;
        }

        public static void ChangePassword(string name, string newPassword)
        {
            try
            {
                string sql = $"DELETE FROM Users WHERE Name = '{name}'";

                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteUsersDatabasePath))
                {
                    cnn.Execute(sql);

                    InsertPerson(name, newPassword);

                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Password changed", "|OK|");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

        }

        private static void InsertPerson(string name, string newPassword)
        {
            try
            {
                PersonModel newPersonModel = new PersonModel();

                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteUsersDatabasePath))
                {
                    newPersonModel.Name = name;
                    newPersonModel.Password = Hash.HashFunc(newPassword);
                    string sqlInsertOrder = $"insert into Users (Name, Password) Values(@Name, @Password);";
                    cnn.Execute(sqlInsertOrder, newPersonModel);
                }

            }
            catch (Exception ex )
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");

            }
        }
    }
}
