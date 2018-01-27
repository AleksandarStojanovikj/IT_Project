using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            Session.Abandon();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e) {

        if (tbUsername.Text == "" || tbPassword.Text == "") {
            lblError.Text = "Please fill in all the fields";
            lblError.Visible = true;
        }
        else {
            lblError.Text = "Oops! Wrong credentials...";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            string sqlString = "Select * From Users";
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@username", tbUsername.Text);

            try {
                connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    if (reader["Username"].ToString().Equals(tbUsername.Text)) {
                        if (reader["Password"].ToString().Equals(tbPassword.Text)) {
                            Session["username"] = tbUsername.Text;
                            Response.Redirect("Home.aspx");
                        }
                        else {
                            lblError.Visible = true;
                        }
                    }
                    else {
                        lblError.Visible = true;
                    }
                }

            }
            catch (Exception err) {
                lblError.Text = err.Message;
                lblError.Visible = true;
            }
            finally {
                connection.Close();
            }
        }
    }
}
