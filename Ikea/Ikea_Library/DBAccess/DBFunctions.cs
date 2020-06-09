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
        public static bool InsterMeasurement(Material plank)
        {
            bool ok = false;
            string insertMaterialOrder = "insert into MainTable(IDMeasurement,TimeStamp,Barcode,Status,HolesCount,ImagePath) VALUES(@IDMeasurement,@TimeStamp,@Barcode,@Status,@HolesCount,@ImagePath)";
            string insertHoleDataOrder = "insert into MeasurementTable(IDMeasurement,X,Y,Radius,Status) VALUES (@IDMeasurement,@X,@Y,@Radius,@Status)";

            if (IsAvailable() == true)
            {
                try
                {
                    using (IDbConnection cnn = new SqlConnection(LoadConnectionString(GlobalVariables.ConnectionStringId)))
                    {
                        cnn.Execute(insertMaterialOrder, plank);
                        Console.WriteLine("{0,-30}|{1,-70}{2,-20}", DateTime.Now, "Material Added to Database", "|OK|");

                        for (int i = 0; i < plank.Holes.Count; i++)
                        {
                            cnn.Execute(insertHoleDataOrder, plank.Holes[i]);
                        }

                        ok = true;
                        Console.WriteLine("{0,-30}|{1,-70}{2,-20}", DateTime.Now, "Add Holes Added to Database", "|OK|");
                    }
                }

                catch (Exception ex)
                {
                    ok = false;
                    Console.WriteLine(DateTime.Now + ex.Message);
                }
            }

            return ok;
        }

        public static List<Material> TakeMainInfo()
        {
            List<Material> output = null;
            string takeOrder = "SELECT top (100)* FROM MainTable ORder by IDMeasurement desc";

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
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
            }

            return output;
        }

        public static List<Hole> TakeMeasurement(string idMeasturement)
        {
            List<Hole> output = null;
            string takeOrder = $"SELECT * FROM MeasurementTable WHERE IDMeasurement = '{idMeasturement}'";

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
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
            }

            return output;
        }
        public static Material TakeImage(string idMeasturement)
        {
            Material output = null;
            string takeImageOrder = $"SELECT * FROM MainTable WHERE IDMeasurement = '{idMeasturement}'";

            try
            {
                using (IDbConnection cnn = new SqlConnection(LoadConnectionString(GlobalVariables.ConnectionStringId)))
                {
                    output = cnn.Query<Material>(takeImageOrder).ToList()[0];
                }
            }

            catch (Exception ex)
            {
                output = null;
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
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
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
            }

            return ok;
        }

        private static string LoadConnectionString(string id)
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }

}
