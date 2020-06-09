using Ikea_Library.DBAccess;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ikea_Library.DataGridTables
{
    public class DataGridFunctions
    {
        public static void UpdateTable(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            List<Material> Materials = DBFunctions.TakeMainInfo();
            try
            {
                for (int i = 0; i < Materials.Count; i++)
                {
                    dataGridView.Rows.Add(Materials[i].IDMeasurement, Materials[i].TimeStamp, Materials[i].Barcode, Materials[i].Status);


                }
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[3].Value) == false)
                    {
                        row.DefaultCellStyle.BackColor = Colors.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Colors.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + ex.Message);
            }
        }
        public static void ShowResults(DataGridView datagridTable_HolesData, List<Hole> measurements)
        {

            for (int i = 0; i < measurements.Count; i++)
            {
                datagridTable_HolesData.Rows.Add(measurements[i].IDMeasurement, measurements[i].X, measurements[i].Y, measurements[i].Radius, measurements[i].Status);
            }
            foreach (DataGridViewRow row in datagridTable_HolesData.Rows)
            {
                if (Convert.ToBoolean(row.Cells[4].Value) == false)
                {
                    row.DefaultCellStyle.BackColor = Colors.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Colors.Green;

                }
            }

            datagridTable_HolesData.ClearSelection();
        }
    }
}
