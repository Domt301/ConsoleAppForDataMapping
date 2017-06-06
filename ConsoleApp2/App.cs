using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp2
{
    internal class App
    {
       // string strPathToCsvFile = @"C:\\curl\Names.csv";

        string CsvFileLocation { get; set; }

        DataTable HeaderMappingsAsDataTable { get; set; }

        public App()
        {
           
            Debug.WriteLine(CsvFileLocation);
            HeaderMappingsAsDataTable = CreateMappingsTable();
            ChangeCsvFileHeaders();
        }

     

        public void Run()
        {
            ChangeCsvFileHeaders();
        }

        public string[] ChangeCsvFileHeaders()
        {
            // get the headers from the csv file
            string[] headers = GetHeadersFromCsvFile();
            Debug.WriteLine(headers);
            Console.WriteLine(headers);


            // match them to the data table mappings
            foreach (string currentHeader in headers)
            {
                Debug.WriteLine(currentHeader);
                foreach (DataRow row in HeaderMappingsAsDataTable.Rows)
                {
                    Debug.WriteLine("{0}, {1}", row[0], row[1]);
                    Console.WriteLine("{0}, {1}", row[0], row[1]);

                    FinalModel newModel = new FinalModel
                    {
                        FirstName = row[1].ToString(),
                        LastName = row[2].ToString()
                    };
                    Console.WriteLine(newModel.ToString());
                }
            }

            // update the header array with the value that matched in the data table

            return headers;
        }

        public string[] GetHeadersFromCsvFile()
        {
            string[] items = System.IO.File.ReadAllLines(@"C:\Curl\Names.csv");
            string[] headers = items[0].Split(',');
            return headers;
        }

        private DataTable CreateMappingsTable()
        {
            DataTable mappingsTable = new DataTable("Mappings");
            mappingsTable.Clear();
            mappingsTable.Columns.Add("ConfigId");
            mappingsTable.Columns.Add("FirstName");
            mappingsTable.Columns.Add("LastName");
            mappingsTable.Rows.Add(new object[] { 1, "F.Name", "L.Name" });
            return mappingsTable;
        }
    }
}
