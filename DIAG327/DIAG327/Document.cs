using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DIAG327
{
    public class Document
    {
        public Document()
        {

        }

        public void Save_Full(string[] name, double[] min, double[] max, double[] average, string s1, string[] left, string[] center, Label[] right, string s2)
        {
            BaseFont times = BaseFont.CreateFont("c:/windows/fonts/times.ttf", "cp1251", BaseFont.EMBEDDED);

            using (SaveFileDialog save_file_dialog = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (save_file_dialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);

                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(save_file_dialog.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph("Анализ параметров ЭБУ  " + s1 + ".", new iTextSharp.text.Font(times, 12)));

                        for (int i = 0; i < 20; i++)
                        {
                            doc.Add(new iTextSharp.text.Paragraph(name[i] + "  " + min[i] + "  " + max[i] + "  " + average[i], new iTextSharp.text.Font(times, 12)));
                        }

                        doc.Add(new iTextSharp.text.Paragraph("Анализ неисправностей автомобиля  " + s2 + ".", new iTextSharp.text.Font(times, 12)));

                        for (int i = 0; i < 34; i++)
                        {
                            doc.Add(new iTextSharp.text.Paragraph(left[i] + "  " + center[i] + "  " + right[i].Text, new iTextSharp.text.Font(times, 12)));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }

        public void Save_Errors(string[] left, string[] center, Label[] right, string s)
        {
            BaseFont times = BaseFont.CreateFont("c:/windows/fonts/times.ttf", "cp1251", BaseFont.EMBEDDED);

            using (SaveFileDialog save_file_dialog = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (save_file_dialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);

                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(save_file_dialog.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph("Анализ неисправностей автомобиля  " + s + ".", new iTextSharp.text.Font(times, 12)));

                        for (int i = 0; i < 34; i++)
                        {
                            doc.Add(new iTextSharp.text.Paragraph(left[i] + "  " + center[i] + "  " + right[i].Text, new iTextSharp.text.Font(times, 12)));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }       
    }
}
