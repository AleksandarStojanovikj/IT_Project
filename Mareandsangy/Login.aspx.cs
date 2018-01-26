using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnLogin_Click(object sender, EventArgs e) {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "Select * From Users WHERE Username=@username";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@username", tbUsername.Text);
        //bool exists = false;
        //string msg = "";

        try {
            connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                //if (reader["Username"].ToString().Equals(tbUsername.Text)) {
                // exists = true;
                if (reader["Password"].ToString().Equals(tbPassword.Text)) {
                    //    msg = "success"; //bi trebalo redirect na glavna strana
                    Session["username"] = tbUsername.Text;
                    Response.Redirect("Main.aspx");
                }
                else {
                    //     msg = "Wrong username or password";
                }
                // }
            }

        }
        catch (Exception err) {
            lblError.Visible = true;
        }
        finally {
            connection.Close();
        }
    }
}