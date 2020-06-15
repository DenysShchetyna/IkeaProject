using System.Data;
using Dapper;
using Ikea_Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea_Library.Helpers;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Ikea_Library.DataAccess
{
    public static class SqliteDataAccess
    {
        public static bool IsAvailable()
        {
            bool ok = false;

            try
            {
                List<string> sqls = new List<string>()
                {
                    "create table if not exists `Users` ( `Name` text not null, `Password` text not null);",
                };

                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.UsersDataPath))
                {
                    cnn.Open();

                    foreach (string sql in sqls)
                    {
                        cnn.Execute(sql);
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                ok = false;
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
            }

            return ok;
        }

        public static List<PersonModel> SelectAllUsers()
        {
            List<PersonModel> output = new List<PersonModel>();

            try
            {
                string sql = "select * from Users";

                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.UsersDataPath))
                {
                    output = cnn.Query<PersonModel>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                output = null;
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
            }

            return output;
        }

        public static PersonModel SelectUser( string password)
        {
            PersonModel output = new PersonModel();

            try
            {
                password = Hashing.Hash(password);
                string sql = $"select * from Users where Password = '{password}';";
            
                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.UsersDataPath))
                {
                    output = cnn.QueryFirst<PersonModel>(sql, new { password });
                }
            }
            catch (Exception ex)
            {
                output = null;
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
            }

            return output;
        }

        public static PersonModel ChangePassword(string name,string newPassword)
        {
            PersonModel newPersonModel = new PersonModel();
            try
            {
                string sql = $"DELETE FROM Users WHERE Name = '{name}'";             

                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.UsersDataPath))
                {
                    cnn.Execute(sql);                    
                    newPersonModel.Name = name;
                    newPersonModel.Password = Hashing.Hash(newPassword);
                    string sqlInsertOrder = $"insert into Users (Name, Password) Values(@Name, @Password);";
                    cnn.Execute(sqlInsertOrder, newPersonModel);
                    Console.WriteLine("password changed");
                }
            }

            catch (Exception ex)
            {
                newPersonModel = null;
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
            }

            return newPersonModel;
        }

        //Password Admin
        //iHN12uxiqfAtMqY8nhTHZBqaikLk+o9lkOuSjZdEtXu1BXodIn5NQO+RGsAwWQu84r/beBA/8LeQlM7oQlYB9Q==
    }
}
