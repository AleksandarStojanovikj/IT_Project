using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hlNo.Visible = false;
        hlYes.Visible = false;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "Select * From Users";
        SqlCommand command = new SqlCommand(sqlString, connection);
       
        bool exists=false;
        string msg="";

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if(reader["Username"].ToString().Equals(tbUsername.Text)){
                     exists=true;
                     if (reader["Password"].ToString().Equals(tbPassword.Text))
                     {
                         msg = "success"; //bi trebalo redirect na glavna strana
                     }
                     else
                     {
                         msg = "incorrect pass";
                     }
                }
            }
            
        }
        catch (Exception err)
        {

        }
        finally
        {
            if (exists == false)
            {
                hlNo.Visible = true;
                hlYes.Visible = true;
                msg = "ne postoish, would you like to register?";
            }
            lblError.Text = msg;
            connection.Close();
        }
    
    }
}