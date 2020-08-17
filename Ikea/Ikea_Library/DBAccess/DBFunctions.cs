using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ikea_Library;
using Ikea_Library.Helpers;

namespace Ikea_Library.DBAccess
{
    public class DBFunctions
    {
        public static bool InsterMeasurement(Material material)
        {
            bool ok = false;
            string insertMaterialOrder = "insert into Plank(RecipeName,CreationTime,Status) VALUES(@RecipeName,@CreationTime,@Status)";
            string insertDrawingSidesOrder = "insert into SideOfPlank(SideName,CreationTime,Status,ImagePath) VALUES(@SideName,@CreationTime,@Status,@ImagePath)";
            string insertHoleDataOrder = "insert into Holes(CreationTime,X,Y,Diameter,Status) VALUES (@CreationTime,@X,@Y,@Diameter,@Status)";

            if (IsAvailable() == true)
            {
                try
                {
                    using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteResultsDatabasePath))
                    {
                        cnn.Execute(insertMaterialOrder, material);
                        Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Material Added to Database", "|OK|");

                        for (int i = 0; i < material.DrawingSides.Count; i++)
                        {
                            cnn.Execute(insertDrawingSidesOrder, material.DrawingSides[i]);
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Drawing Side Added to Database", "|OK|");

                            for (int j = 0; j < material.DrawingSides[i].HolesList.Count; j++)
                            {
                                cnn.Execute(insertHoleDataOrder, material.DrawingSides[i].HolesList[j]);
                            }
                        }

                        ok = true;
                        Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Add Holes Added to Database", "|OK|");
                    }
                }

                catch (Exception ex)
                {
                    ok = false;
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message.Split('.')[0], "|Error|");
                }
            }

            return ok;
        }

        public static List<Material> TakeMainInfo()
        {
            List<Material> output = null;
            string takeOrder = "SELECT * FROM Plank Order by CreationTime desc limit 100";

            try
            {
                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteResultsDatabasePath))
                {
                    output = cnn.Query<Material>(takeOrder).ToList();
                }
            }

            catch (Exception ex)
            {
                output = null;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return output;
        }

        public static List<DrawingSide> TakeDrawingSides(string timeStamp)
        {
            List<DrawingSide> output = null;
            string takeOrder = $"SELECT * FROM SideOfPlank WHERE CreationTime = '{timeStamp}'";

            try
            {
                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteResultsDatabasePath))
                {
                    output = cnn.Query<DrawingSide>(takeOrder).ToList();
                }
            }

            catch (Exception ex)
            {
                output = null;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return output;
        }

        public static List<Hole> TakeHoles(string timeStamp)
        {
            List<Hole> output = null;
            string takeOrder = $"SELECT * FROM Holes WHERE CreationTime = '{timeStamp}'";

            try
            {
                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteResultsDatabasePath))
                {
                    output = cnn.Query<Hole>(takeOrder).ToList();
                }
            }

            catch (Exception ex)
            {
                output = null;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return output;
        }
        public static DrawingSide TakeImage(string timeStamp)
        {
            DrawingSide output = null;
            string takeImageOrder = $"SELECT * FROM SideOfPlank WHERE CreationTime = '{timeStamp}'";

            try
            {
                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteResultsDatabasePath))
                {
                    output = cnn.Query<DrawingSide>(takeImageOrder).ToList()[0];
                }
            }

            catch (Exception ex)
            {
                output = null;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return output;
        }

        private static bool IsAvailable()
        {
            bool ok = false;

            try
            {
                using (IDbConnection cnn = new SQLiteConnection(GlobalVariables.SqliteResultsDatabasePath))
                {
                    cnn.Open();
                    cnn.Close();
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                ok = false;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return ok;
        }
    }
}
