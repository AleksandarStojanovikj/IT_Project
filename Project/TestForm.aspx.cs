using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "INSERT INTO Users (Name,Username,Password) values(@name,@username,@password)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@name", tbName.Text);
        command.Parameters.AddWithValue("@username", tbUsername.Text);
        command.Parameters.AddWithValue("@password", tbPassword.Text);
        string fill = "SELECT * FROM Users";
        SqlCommand fillCommand = new SqlCommand(fill, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(fillCommand);
        DataSet ds = new DataSet();
        bool available = true;
        string pass = tbPassword.Text;
        string username = tbUsername.Text;

        try
        {
            connection.Open();
            
            SqlDataReader reader = fillCommand.ExecuteReader();
            /*while (reader.Read())
            {
                if (reader["Username"].ToString().Equals(username))
                {
                    available = false;
                }
                
                if (reader["Password"].ToString().Equals(pass))
                {
                    available = false;
                }
                
            }*/
           // if (available == true)
            //{
                command.ExecuteNonQuery();
                lblSuccess.Text = "Success";

                adapter.Fill(ds, "Users");
                gvData.DataSource = ds;
                gvData.DataBind();
            //}
        }
        catch (Exception err)
        {

        }
        finally
        {
            //if (available == false)
            //{
               // lblSuccess.Text = "Unsuccessful boohoo";
            //}
            //else
            //{
                //Response.Redirect("Login.aspx");
            //}
            connection.Close();
            
        }
    }
}