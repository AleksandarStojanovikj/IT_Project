using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Register : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            Session.Abandon();
            // lblAlreadyTaken.Visible = false;
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e) {
        if (tbName.Text == "" || tbUsername.Text == "" || tbPassword.Text == "") {
            lblAlreadyTaken.Text = "Please fill in all the fields";
            lblAlreadyTaken.Visible = true;
        }
        else {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            string sqlString = "INSERT INTO Users (Username,Name,Password) values(@username,@name,@password)";
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@name", tbName.Text);
            command.Parameters.AddWithValue("@username", tbUsername.Text.ToLower());
            command.Parameters.AddWithValue("@password", tbPassword.Text);
            

            try {
                connection.Open();
                command.ExecuteNonQuery();

               // lblAlreadyTaken.Text = "Account created! Taking you to login page";
              //  lblAlreadyTaken.Visible = true;

               // System.Threading.Thread.Sleep(3000);
                Response.Redirect("Login.aspx");
            }
            catch (Exception err) {
                lblAlreadyTaken.Text = "Username already taken!";
                lblAlreadyTaken.Visible = true;
            }
            finally {


                connection.Close();
            }
        }
    }
} //