using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            string insertMaterialOrder = "insert into MainTable(Name,TimeStamp,Status,DrawingsCount) VALUES(@Name,@TimeStamp,@Status,@DrawingsCount)";
            string insertDrawingSidesOrder = "insert into DrawingSide(Name,TimeStamp,Status,HolesCount,ImagePath) VALUES(@Name,@TimeStamp,@Status,@HolesCount,@ImagePath)";
            string insertHoleDataOrder = "insert into MeasurementTable(TimeStamp,X,Y,Radius,Status) VALUES (@TimeStamp,@X,@Y,@Radius,@Status)";

            if (IsAvailable() == true)
            {
                try
                {
                    using (IDbConnection cnn = new SqlConnection(LoadConnectionString(GlobalVariables.ConnectionStringId)))
                    {
                        cnn.Execute(insertMaterialOrder, material);
                        Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Material Added to Database", "|OK|");

                        for (int i = 0; i < material.DrawingSides.Count; i++)
                        {
                            cnn.Execute(insertDrawingSidesOrder, material.DrawingSides[i]);
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Drawing Sides Added to Database", "|OK|");

                            for (int j = 0; j <material.DrawingSides[i].Holes.Count; j++)
                            {
                                cnn.Execute(insertHoleDataOrder, material.DrawingSides[i].Holes[j]);
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
            string takeOrder = "SELECT top (100)* FROM MainTable ORder by TimeStamp desc";

            try
            {
                using (IDbConnection cnn = new SqlConnection(LoadConnectionString(GlobalVariables.ConnectionStringId)))
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
            string takeOrder = $"SELECT * FROM DrawingSide WHERE TimeStamp = '{timeStamp}'";

            try
            {
                using (IDbConnection cnn = new SqlConnection(LoadConnectionString(GlobalVariables.ConnectionStringId)))
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
            string takeOrder = $"SELECT * FROM MeasurementTable WHERE TimeStamp = '{timeStamp}'";

            try
            {
                using (IDbConnection cnn = new SqlConnection(LoadConnectionString(GlobalVariables.ConnectionStringId)))
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
            string takeImageOrder = $"SELECT * FROM DrawingSide WHERE timeStamp = '{timeStamp}'";

            try
            {
                using (IDbConnection cnn = new SqlConnection(LoadConnectionString(GlobalVariables.ConnectionStringId)))
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
                using (IDbConnection cnn = new SqlConnection(LoadConnectionString(GlobalVariables.ConnectionStringId)))
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

        private static string LoadConnectionString(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }

}
