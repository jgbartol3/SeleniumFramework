namespace PageObjects.PageHelpers.TableReader;

public class TableCell
{
    public int ColumnIndex { get; set; }
    public int RowIndex { get; set; }
    public string? ColumnName { get; set; }
    public object? CellValue { get; set; }


}
