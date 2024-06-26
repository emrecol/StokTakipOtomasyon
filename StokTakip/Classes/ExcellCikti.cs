using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

namespace StokTakipProgramı.Classes
{
    internal class reporting
    {

        public static void report(DataGridView dtgv)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.OverwritePrompt = false;
            sv.Title = "Excell Dosyaları";
            sv.DefaultExt = "xlsx";
            sv.Filter = "xlsx Dosyaalrı (*.xlsx) | *.xlsx | Tüm Dosyalar(*.*) | *.*";

            if (sv.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sayfa1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Excell dışa aktarım";

                for (int i = 1; i < dtgv.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dtgv.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dtgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dtgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dtgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(sv.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
            }
        }

        internal static void report(DataGridView dtgvHareketler, object dtgv)
        {
            throw new NotImplementedException();
        }
    }
}