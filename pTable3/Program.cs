using System.Data;
using System.Data.SqlClient;
//Take an inoput
Console.WriteLine("Please enter either a symbol or a number of the element on the periodic table");
string userInput;
userInput = Console.ReadLine(); // waint from an imput from command line
DataTable elementsTable = new DataTable("elements"); //creates a new instance of a data table object
try
{
    using (SqlConnection _con = new SqlConnection("Server=localhost;Database=pTable;Integrated Security=True")) // connect to the database
    {
        int atomicNumber; //var for the inputted atomic number
        string queryStatement; //var for 
        if (int.TryParse(userInput, out atomicNumber)) //check if it is a number (ATOMKIC NUMBER)
        {
            queryStatement = $"SELECT * FROM [pTable].[dbo].[elements] WHERE [atomic_number] = {userInput}";
        }
        else // if its not a number (SYMBOL)
        {
            queryStatement = $"SELECT * FROM [pTable].[dbo].[elements] WHERE [symbol] = \'{userInput}\'";
        }
         
        using (SqlCommand _cmd = new SqlCommand(queryStatement, _con)) //takes sql connection object and sql query string
        {
            
            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

            _con.Open();
            _dap.Fill(elementsTable); //populates the datatable object
            _con.Close();
        }
    }
}
catch (SqlException e)
{
    Console.WriteLine(e.ToString());
}

Console.WriteLine("Database returned " + elementsTable.Rows.Count + " rows."); //prints the number of rows returned

elementsTable.PrintToConsole(); //printing reslults

Console.ReadLine();
