using System.ComponentModel;


namespace PageObjects.PageHelpers.DocReaders;

/*
class ExcelDocReaderBaseDocReader : BaseDocReader
{
    public List<ExcelSheet> ReadExcel(string documentTitle, int headersRowNumber, int endRowNumber = 1000)
    {
        List<ExcelSheet> excelSheets = new();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (ExcelPackage package = new ExcelPackage(new FileInfo(SetFullFilePathAndWait(documentTitle))))
        {
            foreach (ExcelWorksheet excelWorksheet in package.Workbook.Worksheets)
            {
                int
                    columnCount = excelWorksheet.Dimension.End.Column,
                    rowCount = excelWorksheet.Dimension.End.Row > endRowNumber ? endRowNumber : excelWorksheet.Dimension.End.Row;

                List<TableCell> cells = new();

                for (int row = headersRowNumber + 1; row <= rowCount; row++)
                {
                    for (int column = 1; column <= columnCount; column++)
                    {
                        if (excelWorksheet.Cells[headersRowNumber, column].Value != null && excelWorksheet.Cells[row, column].Value != null)
                        {
                            cells.Add(new TableCell()
                            {
                                RowIndex = row - headersRowNumber,
                                ColumnIndex= column,
                                ColumnName = excelWorksheet.Cells[headersRowNumber, column].Value.ToString().Trim(),
                                CellValue = excelWorksheet.Cells[row, column].Value.ToString().Trim()
                            });
                        }
                    }
                }

                excelSheets.Add(new ExcelSheet()
                {
                    Name = excelWorksheet.Name,
                    Cells = cells,
                    IsEncrypted = package.Encryption.IsEncrypted,
                    Password = package.Encryption.Password
                });
            }
        }

        DeleteFile(documentTitle);

        return excelSheets;
    }



}


*/

public class ExcelSheet
{
    public string Name { get; set; }
    public List<TableCell> Cells { get; set; }
    public bool IsEncrypted { get; set; }
    public string Password { get; set; }
}

