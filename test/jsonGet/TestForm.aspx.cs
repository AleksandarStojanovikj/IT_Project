using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class TestForm : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnAddUser_Click(object sender, EventArgs e) {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "INSERT INTO Users (Username,Name,Password) values(@username,@name,@password)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@name", tbName.Text);
        command.Parameters.AddWithValue("@username", tbUsername.Text);
        command.Parameters.AddWithValue("@password", tbPassword.Text);  
    
        try {
            connection.Open();
            command.ExecuteNonQuery();
            Response.Redirect("Login.aspx");
        }
        catch (Exception err) {
            lblSuccess.Text = "Username already taken.";
        }
        finally {         
            connection.Close();
        }
    }
}