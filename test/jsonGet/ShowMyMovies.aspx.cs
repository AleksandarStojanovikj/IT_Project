using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowMyMovies : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            if (Session["username"] == null) {
                Response.Redirect("Login.aspx");
            }

            fillLB();
        }
    }


    void fillLB() {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlCommand = "SELECT Title FROM Movies m, Favorites f WHERE m.imdbID=f.MovieID AND f.Username=@username";
        SqlCommand command = new SqlCommand(sqlCommand, connection);
        command.Parameters.AddWithValue("@username", Session["username"].ToString());

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        DataSet ds = new DataSet();

        try {
            connection.Open();
            adapter.Fill(ds, "Movies");
            ListBox1.DataTextField = "title";
            ListBox1.DataValueField = "title";
            ListBox1.DataSource = ds;
            ListBox1.DataBind();
            //  ViewState["dataset"] = ds;
        }
        catch (Exception err) {
            Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }

    }

}