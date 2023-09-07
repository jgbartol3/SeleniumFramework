using Microsoft.VisualBasic.FileIO;




namespace PageObjects.PageHelpers.DocReaders;

class CsvDocReader : BaseDocReader
{
    public List<TableCell> ReadCsv(string documentTitle, int headerRowNumber)
    {
        List<TableCell> tableCells = new();

        using (TextFieldParser textFieldParser = new TextFieldParser(SetFullFilePathAndWait(documentTitle)))
        {
            textFieldParser.TextFieldType = FieldType.Delimited;

            textFieldParser.SetDelimiters(",");

            List<string> headerFields = new();

            while (!textFieldParser.EndOfData)
            {
                List<string> cellFields = textFieldParser.ReadFields().ToList();

                int rowNumber = headerRowNumber + 1;

                if (textFieldParser.LineNumber == rowNumber)
                {
                    headerFields.AddRange(cellFields);
                }
                else if (textFieldParser.LineNumber > rowNumber)
                {
                    for (int j = 0; j < headerFields.Count; j++)
                    {
                        tableCells.Add(new TableCell()
                        {
                            RowIndex = rowNumber - headerRowNumber - 1,
                            ColumnName = headerFields[j].Trim(),
                            CellValue = cellFields[j].Trim()
                        });
                    }
                }
            }
        }

        DeleteFile(documentTitle);

        return tableCells;
    }
}

