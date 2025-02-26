using System;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace SQLeditor
{
    public class DatabaseHelper
    {
        private string connectionString;
        public string ConnectionString { get { return connectionString; } }
        private readonly SemaphoreSlim dbSemaphore = new SemaphoreSlim(1, 1);

        public DatabaseHelper(string dbPath)
        {
            SetDatabase(dbPath);
        }

        public void SetDatabase(string dbPath)
        {
            connectionString = $"Data Source={dbPath};Version=3;";
        }

        public async Task<DataTable> ExecuteQueryAsync(string query, SQLiteParameter[] parameters = null)
        {
            await dbSemaphore.WaitAsync();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            finally
            {
                dbSemaphore.Release();
            }
        }

        public async Task ExecuteNonQueryAsync(string query, SQLiteParameter[] parameters = null)
        {
            await dbSemaphore.WaitAsync();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            finally
            {
                dbSemaphore.Release();
            }
        }
    }
}
