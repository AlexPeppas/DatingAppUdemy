
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UdemyDatingApp.AdvancedTechniques.DocumentManipulation
{
    public class PdfMainClass
    {
        public void PdfFunctionality ()
        {
            string pathPdf = "C:\\faniPdf.pdf";
            byte[] pdfBytes = System.IO.File.ReadAllBytes(pathPdf);
            string pathSign = "C:\\FaniSignaturePdf.pdf";
            byte[] signBytes = System.IO.File.ReadAllBytes(pathSign);

            string pathOutput = "C:\\Concat.pdf";
            //byte[] finalDoc = pdfBytes.Concat(signBytes).ToArray();
            //byte[] finalDoc = System.Array.Copy(signBytes, 0, pdfBytes, pdfBytes.Length);
            byte[] finalDoc = new byte[pdfBytes.Length + signBytes.Length];
            System.Buffer.BlockCopy(pdfBytes, 0, finalDoc, 0, pdfBytes.Length);
            System.Buffer.BlockCopy(signBytes, 0, finalDoc, pdfBytes.Length, signBytes.Length);
            System.IO.File.WriteAllBytes(pathOutput, finalDoc);

            SimulateMain();
           /* MergePDF("C:\\faniPdf.pdf", "C:\\FaniSignaturePdf.pdf");
            MergePDF("C:\\Concatenation2.pdf", "C:\\faniPdf.pdf");*/
        }
        static void SimulateMain()
        {
            using (Stream inputPdfStream = new FileStream("C:\\faniPdf.pdf", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream inputImageStream = new FileStream(@"C:\qrMenu.png", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream outputPdfStream = new FileStream("C:\\result.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var reader = new PdfReader(inputPdfStream);
                var stamper = new PdfStamper(reader, outputPdfStream);
                var pdfContentByte = stamper.GetOverContent(1);

                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(inputImageStream);
                image.SetAbsolutePosition(100, 100);
                pdfContentByte.AddImage(image);
                stamper.Close();
            }
        }
        private static void MergePDF(string File1, string File2)
        {
            string[] fileArray = new string[3];
            fileArray[0] = File1;
            fileArray[1] = File2;

            PdfReader reader = null;
            Document sourceDocument = new Document();
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = @"C:\Concatenation2.pdf";

            
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //output file Open  
            sourceDocument.Open();


            //files list wise Loop  
            for (int f = 0; f < fileArray.Length - 1; f++)
            {
                int pages = TotalPageCount(fileArray[f]);

                reader = new PdfReader(fileArray[f]);
                //Add pages in new file  
                for (int i = 1; i <= pages; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }

                reader.Close();
            }
            //save the output file  
            sourceDocument.Close();
        }

        private static int TotalPageCount(string file)
        {
            using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(file)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }

        /*private static void EncryptPDF()
        {
            try
            {
                //Create a pdf document.  
                PdfDocument doc = new PdfDocument();
                doc.LoadFromFile(@"result.pdf");

                //encrypt  
                doc.Security.KeySize = PdfEncryptionKeySize.Key128Bit;
                doc.Security.OwnerPassword = "test";
                doc.Security.UserPassword = "test";
                doc.Security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FillFields;

                doc.SaveToFile(@"Result_Encrypted.pdf");
                doc.Close();
                System.Diagnostics.Process.Start(@"Result_Encrypted.pdf");
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static void InsertImageIntoPDF()
        {
            try
            {
                //Path to Store PDF file  
                string outputFile = "result.pdf";
                //Create a PDF document using Spire.PDF.dll  
                PdfDocument doc = new PdfDocument();
                //Add a page  
                PdfPageBase page = doc.Pages.Add();

                //Create a pdf grid  
                PdfGrid grid = new PdfGrid();

                //Set the cell padding of pdf grid  
                grid.Style.CellPadding = new PdfPaddings(1, 1, 1, 1);

                //Add a row for pdf grid  
                PdfGridRow row = grid.Rows.Add();

                //Add two columns for pdf grid   
                grid.Columns.Add(4);
                float width = page.Canvas.ClientSize.Width - (grid.Columns.Count + 1);

                //Set the width of the first column  
                grid.Columns[0].Width = width * 0.20f;
                grid.Columns[1].Width = width * 0.20f;
                grid.Columns[2].Width = width * 0.20f;
                grid.Columns[3].Width = width * 0.20f;

                //Add a image  
                PdfGridCellTextAndStyleList lst = new PdfGridCellTextAndStyleList();
                PdfGridCellTextAndStyle textAndStyle = new PdfGridCellTextAndStyle();
                textAndStyle.Image = PdfImage.FromFile("ccorner.jpg");

                //Set the size of image  
                textAndStyle.ImageSize = new SizeF(70, 70);
                lst.List.Add(textAndStyle);

                //Add a image into the first cell.   
                row.Cells[1].Value = lst;

                //Draw pdf grid into page at the specific location  
                PdfLayoutResult result = grid.Draw(page, new PointF(10, 30));

                //Save to a pdf file   
                doc.SaveToFile(outputFile, FileFormat.PDF);

            }
            catch (Exception)
            {
                throw;
            }
        }
*/    }
}
