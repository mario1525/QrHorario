using System.Data.SqlClient;
using System.Data;


namespace Data.SQLClient
{
    public class SQLclient
    {

        private readonly string _connectionString;

        public SQLclient(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<DataTable> ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        Console.WriteLine(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}

