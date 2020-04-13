using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Drawing;
using Microsoft.Office.Interop.Word;

namespace ChocoholicsPortal
{
    class APFunctions
    {
        chocanonEntities dbs = new chocanonEntities();
        DateTime today = DateTime.Today;
        DateTime lastWeek = DateTime.Today.AddDays(-7);
        Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();


        public void RunAPProcess()
        {
            //dbs.ap_period.Add(new ap_period { EndDate = new DateTime(2020, 4, 10) });
            //Get Providers

            var WeekProviders = GetWeekProviders();

            //loop through billing info
            foreach (var item in WeekProviders)
            {
                var weeklyBilling = GetWeeklyBillingPerProvider(item);

                var getAPPeriod = dbs.ap_period.Where(m => m.EndDate <= today).Max(m=>m.APPeriodID);

                InsertEFTRecord(
                    new eft()
                    {
                        ProviderID = item.ProviderID,
                        ProviderName = (item.FirstName + item.LastName),
                        APPeriodID = getAPPeriod,
                        Amount = weeklyBilling ?? 0
                    }
                );
            }

            if(WeekProviders.Count>0)
            {
                GenerateReports();
            }
            
        }
        private void GenerateReports()
        {
            //Generate AP Manager Report
            GenerateManagerReport();



            //Generate Provider Report
            //Generate Member Report
        }
        private void GenerateManagerReport()
        {
            var FileName = "MANAGERREPORT-"
                + dbs.ap_period.Where(m => m.EndDate <= today).Max(m=>m.APPeriodID)
                + ".docx";

            var WeekProviders = GetWeekProviders();
            
            //Create a new document  
            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add();

            //Add header into the document  
            foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
            { 
                Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                headerRange.Font.Size = 20;
                headerRange.Text = "Weekly Billing Report";
            }
            
            document.Content.SetRange(0, 0);
            document.Content.Text = "AP Period: " + lastWeek.ToShortDateString() + 
                " - " + today.ToShortDateString() + Environment.NewLine;
            
            Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add();

            para1.Range.InsertParagraphAfter();
            Table firstTable = document.Tables.Add(para1.Range, WeekProviders.Count + 1, 3);
            firstTable.Borders.Enable = 1;
            var c = firstTable.Rows.Count;
            var c2 = firstTable.Columns.Count;
            foreach (Row row in firstTable.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    //Header row  
                    if (cell.RowIndex == 1)
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = "Provider Name";
                        }
                        else if (cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = "# of Consultations";
                        }
                        else
                        {
                            cell.Range.Text = "Billed Amount";
                        }
                    }
                    else
                    {
                        var thisProvider = WeekProviders[cell.RowIndex - 2];
                        if (cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = thisProvider.FirstName + " " + thisProvider.LastName;
                        }
                        else if (cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = GetWeeklyConsulationsPerProvider(thisProvider).ToString();
                        }
                        else
                        {
                            cell.Range.Text = "$" + GetWeeklyBillingPerProvider(thisProvider).ToString();
                        }
                    }
                }
            }


            Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add();
            para2.Range.InsertParagraphAfter();
            Table lastTable = document.Tables.Add(para2.Range, 2, 4);
            lastTable.Borders.Enable = 1;
            foreach (Row row in lastTable.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    if (cell.RowIndex == 1)
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = "TOTALS";
                        }
                        else if (cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = "Providers";
                        }
                        else if (cell.ColumnIndex == 3)
                        {
                            cell.Range.Text = "Consultations";
                        }
                        else
                        {
                            cell.Range.Text = "Billing";
                        }
                    }
                    else
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = "";
                        }
                        else if (cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = WeekProviders.Count.ToString();
                        }
                        else if (cell.ColumnIndex == 3)
                        {
                            cell.Range.Text = GetWeeklyConsulations().ToString();
                        }
                        else
                        {
                            cell.Range.Text = "$" + GetWeeklyBilling().ToString();
                        }
                    }
                }
            }

            //Add the footers into the document  
            foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
            {
                //Get the footer range and add the footer details.  
                Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                footerRange.Font.Size = 10;
                footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                footerRange.Text = FileName;
            }

            //Save the document  
            object filename = FileName;
            document.SaveAs2(ref filename);
            document.Close();
            document = null;
            winword.Quit();
            winword = null;
        }
        private List<provider> GetWeekProviders()
        {
            return dbs.bill_info.Where(m => m.ServiceDate <= today && m.ServiceDate >= lastWeek)
                .Select(m => m.provider).Distinct()
                .ToList();
        }
        private double? GetWeeklyBillingPerProvider(provider singleProvider)
        {
            return dbs.bill_info.Where(m => m.ServiceDate <= today && m.ServiceDate >= lastWeek
                    && m.ProviderID == singleProvider.ProviderID).Sum(m => m.service.ServiceCost);
        }
        private double? GetWeeklyConsulationsPerProvider(provider singleProvider)
        {
            return dbs.bill_info.Where(m => m.ServiceDate <= today && m.ServiceDate >= lastWeek
                    && m.ProviderID == singleProvider.ProviderID).Count();
        }
        private double? GetWeeklyBilling()
        {
            return dbs.bill_info.Where(m => m.ServiceDate <= today && m.ServiceDate >= lastWeek).Sum(m => m.service.ServiceCost);
        }
        private double? GetWeeklyConsulations()
        {
            return dbs.bill_info.Where(m => m.ServiceDate <= today && m.ServiceDate >= lastWeek).Count();
        }
        private void InsertEFTRecord(eft newEft)
        {
            dbs.eft.Add(newEft);
        }
    }
}
