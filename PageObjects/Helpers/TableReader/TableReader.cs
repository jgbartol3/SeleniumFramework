


using Driver.Helpers;

namespace PageObjects.PageHelpers.TableReader;


class TableReader : Commands
{
    IEnumerable<TableCell> GetTableCells(string headers, string cells)
    {
        List<string>
                    headersText = GetTextFromElements(headers).ToList(),
                    cellsText = GetTextFromElements(cells).ToList();

        int
            headersCount = headersText.Count,
            cellCount = cellsText.Count,
            rowCount = cellCount / headersCount;

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < headersCount; j++)
            {
                yield return new()
                {
                    RowIndex = i,
                    ColumnIndex = j,
                    ColumnName = headersText[j],
                    CellValue = cellsText[i * headersCount + j]
                };
            }
        }
    }

    public IEnumerable<T> GetTable<T>(string tableHeaders, string tableCells) where T : new()
    {
        List<TableCell> cells = GetTableCells(tableHeaders, tableCells).ToList();

        for (int i = 0; i <= cells.Max(x => x.RowIndex); i++)
        {
            T t = new();

            PropertyInfo[] properties = t.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                object? val = cells.Where(x => x.RowIndex == i && x.ColumnName == propertyInfo.Name)
                                   .First().CellValue;

                if (val != null)
                {
                    propertyInfo.SetValue(t, Convert.ChangeType(val, propertyInfo.PropertyType), null);
                }
            }

            yield return t;
        }
    }


}
