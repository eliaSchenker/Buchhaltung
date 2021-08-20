using Buchhaltung_New.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Buchhaltung_New
{
    /// <summary>
    /// Class responsible for exporting the various data from Buchhaltung
    /// </summary>
    class Exporter
    {
        private string path;

        public Exporter(string path = "C:/")
        {
            this.path = path;
        }

        /// <summary>
        /// Exports every Buchung to an Excel Spreadsheet
        /// </summary>
        /// <returns>A boolean which is true if the export was successfull and false if it was not</returns>
        public bool exportBuchungenToExcel()
        {
            int columncount = 5;
            SpreadsheetDocument ssd;
            try
            {
                ssd = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook);
            }
            catch
            {
                MessageHandler.showError("Datei konnte nicht exportiert werden.");
                return false;
            }
            //Add work part to the Document  
            WorkbookPart wbp = ssd.AddWorkbookPart();
            wbp.Workbook = new Workbook();

            //add work sheet to the work part  
            WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
            wsp.Worksheet = new Worksheet(new SheetData());
            // add sheets   
            Sheets sht = ssd.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
            // Append a new worksheet and associate it with the workbook.  
            Sheet sheet = new Sheet()
            {
                Id = ssd.WorkbookPart.
                // create an new sheet  
                GetIdOfPart(wsp),
                SheetId = 1,
                Name = "Konto"
            };
            sht.Append(sheet);
            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();
            //create a new row, cell   
            Row row = new Row();
            Cell[] cell = new Cell[columncount];

            string[] columnheaders = new string[] { "Konto 1", "Konto 2", "Datum", "Beschreibung", "Betrag"};

            // the below used to create temple of the existing gridview  
            for (int i = 0; i < columncount; i++)
            {
                string[] columnheadname = new string[]
                {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"
                };
                cell[i] = new Cell()
                //passing the cell value  
                {
                    CellReference = columnheadname[0].ToString(),
                    DataType = CellValues.String,

                    CellValue = new CellValue(columnheaders[i])
                };

                row.Append(cell[i]);
            }
            sheetData.Append(row);
            worksheet.Append(sheetData);
            wsp.Worksheet = worksheet;
            wbp.Workbook.Save();
            ssd.Close();

            int rowcount = Buchhaltung.buchungen.Count;
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(path, true))
            {
                WorkbookPart wbPart = document.WorkbookPart;
                // check whether the sheet is exist or not  
                IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == "Konto");

                if (sheets == null)
                {
                    throw new ArgumentException("sheetName");
                }
                else
                {
                    //get the ID of the sheet  
                    string sheetss = sheets.First().Id.Value;

                    // get the workpartsheet of the exesting data  
                    WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheetss);
                    //get the sheet data of the exsting data  
                    sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    for (int i = 0; i < rowcount; i++)
                    {
                        //Assign the column name dynamically using array  

                        string[] columnheadname = new string[]
                        {
                    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"
                        };
                        //create a row  
                        row = new Row();
                        //create the cell dynamically using array  
                        cell = new Cell[columncount];
                        for (int j = 0; j < columncount; j++)
                        {
                            // get the value in the grid view  
                            
                            string data1 = "";
                            switch(j)
                            {
                                case 0:
                                    data1 = Buchhaltung.buchungen[i].konto1;
                                    break;
                                case 1:
                                    data1 = Buchhaltung.buchungen[i].konto2;
                                    break;
                                case 2:
                                    data1 = Buchhaltung.buchungen[i].datum.ToString("dd-M-yyyy");
                                    break;
                                case 3:
                                    data1 = Buchhaltung.buchungen[i].beschreibung;
                                    break;
                                case 4:
                                    data1 = Buchhaltung.buchungen[i].betrag.ToString();
                                    break;
                            }

                            cell[j] = new Cell()
                            {
                                CellReference = columnheadname[0].ToString(),
                                DataType = (j == columncount - 1) ? CellValues.Number : CellValues.String,

                                CellValue = new CellValue(data1)
                            };
                            row.Append(cell[j]);
                        }
                        sheetData.Append(row);
                    }
                    worksheetPart.Worksheet.Save();
                }
            }

            return true;
        }
    }
}