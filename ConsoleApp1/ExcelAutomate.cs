using OfficeOpenXml;
using System;
using System.IO;

namespace ConsoleApp1
{
  public class ExcelAutomate
  {
    public void readExcel(String inputFile)
    {
      FileInfo fileInfo = new FileInfo(inputFile);
      using (ExcelPackage package = new ExcelPackage(fileInfo))
      {
        for (Int32 workSheetCount = 1; workSheetCount <= package.Workbook.Worksheets.Count; workSheetCount++)
        {
          ExcelWorksheet excelWorkSheet = package.Workbook.Worksheets[workSheetCount];
          ExcelWorksheet newExcelWorkSheet = package.Workbook.Worksheets.Add(excelWorkSheet.Name + workSheetCount);
          for (Int32 columnCount = excelWorkSheet.Dimension.Start.Column;
                columnCount <= excelWorkSheet.Dimension.End.Column;
                columnCount++)
          {
            for (Int32 rowCount = excelWorkSheet.Dimension.Start.Row;
                    rowCount <= excelWorkSheet.Dimension.End.Row;
                    rowCount++)
            {
              newExcelWorkSheet.Cells[columnCount, rowCount].Value = excelWorkSheet.Cells[columnCount, rowCount].Value;
            }
            if (columnCount > 1)
            {
              newExcelWorkSheet.Cells[columnCount, excelWorkSheet.Dimension.End.Row + 1].Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
              newExcelWorkSheet.Cells[columnCount, excelWorkSheet.Dimension.End.Row + 1].Value = "Date";
            }
          }
          package.Workbook.Worksheets.Delete(excelWorkSheet);
          newExcelWorkSheet.Name = excelWorkSheet.Name;
        }
        package.Save();
      }
    }
  }
}
