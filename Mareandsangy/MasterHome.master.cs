using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

public partial class MasterHome : System.Web.UI.MasterPage {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            if (Session["username"] == null) {
                Response.Redirect("Login.aspx");
            }
            HyperLink1.Text = Session["username"].ToString();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
       // bool exists = true;
        if (tbSearch.Text != "") {
            string checkUser = tbSearch.Text.ToLower();
            if(checkUser == Session["username"].ToString()) {
                Response.Redirect("MyPage.aspx");
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            string sqlString = "Select * From Users";
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@username", checkUser);

            try {
                connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    if (reader["Username"].ToString().Equals(checkUser)) {
                        Session["otherUser"] = checkUser;
                        Response.Redirect("OtherUserPage.aspx");
                       // exists = true;
                       // break;
                    }
                    else {
                        //lblError.Visible = true;
                        //exists = false;

                    }
                }
                 Response.Redirect("NotFound.aspx");
            }
            catch (Exception err) {
               
            }
            finally {
                
                connection.Close();
            }
        }
    }

    protected void btnSignOut_Click(object sender, EventArgs e) {
        Response.Redirect("Login.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e) {
        Response.Redirect("MyPage.aspx");
    }
}

