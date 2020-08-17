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
                    dataGridView.Rows.Add(Materials[i].RecipeName, Materials[i].CreationTime, Materials[i].Status);
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[2].Value) == false)
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

        //Show drawing sides data
        public static void ShowResultsDrawingSides(DataGridView datagridTable_DrawingSides, List<DrawingSide> drawingSides)
        {
            for (int i = 0; i < drawingSides.Count; i++)
            {
                datagridTable_DrawingSides.Rows.Add(drawingSides[i].SideName, drawingSides[i].CreationTime, drawingSides[i].Status);
            }
            foreach (DataGridViewRow row in datagridTable_DrawingSides.Rows)
            {
                if (Convert.ToBoolean(row.Cells[2].Value) == false)
                {
                    row.DefaultCellStyle.BackColor = Colors.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Colors.Green;
                }
            }

            datagridTable_DrawingSides.ClearSelection();
        }

        //show holes data
        public static void ShowResultsHoles(DataGridView datagridTable_HolesData, List<Hole> holes)
        {
            for (int i = 0; i < holes.Count; i++)
            {
                datagridTable_HolesData.Rows.Add(holes[i].CreationTime, holes[i].X, holes[i].Y, holes[i].Diameter, holes[i].Status);
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
