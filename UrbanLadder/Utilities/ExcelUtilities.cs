using ExcelDataReader;
using System.Data;
using System.Text;
using UrbanLadder.Utilities;

namespace UrbanLadder.Utilities
{
    internal class ExcelUtilities
    {
        public static List<ExcelData> ReadExcelData(string excelFilePath, string sheetname)
        {
            List<ExcelData> productDatalist = new List<ExcelData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var datatable = result.Tables[sheetname];
                    if (datatable != null)
                    {
                        foreach (DataRow row in datatable.Rows)
                        {
                            ExcelData productData = new ExcelData
                            {
                                ProductName = GetValueOrDefault(row, "productname")

                            };
                            productDatalist.Add(productData);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"sheet'{sheetname}' not found in the excel file");
                    }
                }
            }

            return productDatalist;
        }
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "" + columnName);
            return row.Table.Columns.Contains(columnName) ?
                row[columnName]?.ToString() : null;
        }
    }
}