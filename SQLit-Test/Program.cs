using Microsoft.Data.Sqlite;

Console.WriteLine("Hello, World!");

using var connection = new SqliteConnection("Data Source=Test.db");
connection.Open();

CreateTable(connection);
InsertData(connection);
ReadData(connection);

static void CreateTable(SqliteConnection conn)
{

    SqliteCommand sqlite_cmd;
    string Createsql = "CREATE TABLE SampleTable (Col1 VARCHAR(20), Col2 INT)";
    sqlite_cmd = conn.CreateCommand();
    sqlite_cmd.CommandText = Createsql;
    sqlite_cmd.ExecuteNonQuery();
}

static void InsertData(SqliteConnection conn)
{
    SqliteCommand sqlite_cmd;
    sqlite_cmd = conn.CreateCommand();
    sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test Text ', 1); ";
    sqlite_cmd.ExecuteNonQuery();
    sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES('Test1 Text1 ', 2); ";
    sqlite_cmd.ExecuteNonQuery();
    sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test2 Text2 ', 3); ";
    sqlite_cmd.ExecuteNonQuery();
}

static void ReadData(SqliteConnection conn)
{
    SqliteDataReader sqlite_datareader;
    SqliteCommand sqlite_cmd;
    sqlite_cmd = conn.CreateCommand();
    sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

    sqlite_datareader = sqlite_cmd.ExecuteReader();
    while (sqlite_datareader.Read())
    {
        string myreader = sqlite_datareader.GetString(0);
        Console.WriteLine(myreader);
    }
    conn.Close();
}