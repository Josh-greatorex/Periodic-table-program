using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Please enter either a symbol or a number of the element on the periodic table");
string userInput;
userInput = Console.ReadLine();
DataTable elementsTable = new DataTable("elements");
try
{
    using (SqlConnection _con = new SqlConnection("Server=localhost;Database=pTable;Integrated Security=True"))
    {
        int atomicNumber;
        string queryStatement;
        if (int.TryParse(userInput, out atomicNumber))
        {
            queryStatement = $"SELECT * FROM [pTable].[dbo].[elements] WHERE [atomic_number] = {userInput}";
        }
        else
        {
            queryStatement = $"SELECT * FROM [pTable].[dbo].[elements] WHERE [symbol] = \'{userInput}\'";
        }
         
        using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
        {
            
            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

            _con.Open();
            _dap.Fill(elementsTable);
            _con.Close();
        }
    }
}
catch (SqlException e)
{
    Console.WriteLine(e.ToString());
}

Console.WriteLine(elementsTable.Rows.Count);
foreach (DataRow dataRow in elementsTable.Rows)
{
    foreach (var item in dataRow.ItemArray)
    {
        Console.WriteLine(item);
    }
}

Console.ReadLine();
