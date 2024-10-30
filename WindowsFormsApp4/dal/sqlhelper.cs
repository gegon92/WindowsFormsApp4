using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

public class SqlHelper
{
    private string connectionString;

    public SqlHelper(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void CreateTable()
    {
        string sql = @"CREATE TABLE IF NOT EXISTS users (
            id INTEGER PRIMARY KEY,
            name TEXT NOT NULL,
            email TEXT NOT NULL,
            phone TEXT
        )";

        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Table 'users' created successfully.");
        }
        catch (SQLiteException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void AddUser(string name, string email, string phone)
    {
        string sql = @"INSERT INTO users (name, email, phone) VALUES (@name, @email, @phone)";
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("User added successfully.");
        }
        catch (SQLiteException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void EditUser(int id, string name, string email, string phone)
    {
        string sql = @"UPDATE users SET name = @name, email = @email, phone = @phone WHERE id = @id";
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("User updated successfully.");
        }
        catch (SQLiteException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void DeleteUser(int id)
    {
        string sql = @"DELETE FROM users WHERE id = @id";
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("User deleted successfully.");
        }
        catch (SQLiteException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void ClearUsers()
    {
        string sql = @"DELETE FROM users";
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("All users cleared successfully.");
        }
        catch (SQLiteException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public DataTable GetUsers()
    {
        string sql = @"SELECT * FROM users";
        DataTable table = new DataTable();
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
        }
        catch (SQLiteException ex)
        {
            MessageBox.Show(ex.Message);
        }
        return table;
    }
}