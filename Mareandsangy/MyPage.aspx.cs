using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyPage : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            if (Session["username"] == null) {
                Response.Redirect("Login.aspx");
            }
        }
        
    }

    protected void btnFavorites_Click(object sender, EventArgs e) {
        // fillGVAll("fav");
        fillGV();
    }
    protected void fillGVAll(string mode) {
        /*
         *      mode = 0  => Movies To Watch
         *      mode = 1  => Watched Movies
         *      mode = 2  => Favorite Movies
         */
        gvMyFavs.Visible = true;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        
        SqlCommand command = new SqlCommand();
        // SqlCommand command = new SqlCommand(sqlCommand, connection);
        //command.Parameters.AddWithValue("@table", table);
        if (mode.Equals("fav")) {
            string sqlCommand = "SELECT Title FROM Favorites,Movies WHERE MovieID=imdbID AND Username=@username";
            command = new SqlCommand(sqlCommand, connection);
            command.Parameters.AddWithValue("@username", Session["username"].ToString());
        }
        else {
            string sqlCommand = "SELECT Title FROM Watched,Movies WHERE MovieID=imdbID AND Username=@username AND watched=@watched";
            command = new SqlCommand(sqlCommand, connection);
            if (mode.Equals("false")) {
                command.Parameters.AddWithValue("@watched", "false");
            }
            else {
                command.Parameters.AddWithValue("@watched", "true");
            }
            command.Parameters.AddWithValue("@username", Session["username"].ToString());
        }
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        DataSet ds = new DataSet();

        try {
            connection.Open();
            adapter.Fill(ds, "Favs");
            gvMyFavs.DataSource = ds;
            gvMyFavs.DataBind();
            ViewState["dataset"] = ds;
        }
        catch (Exception err) {
            Label1.Visible = true;
            Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }
    protected void fillGV() {
        gvMyFavs.Visible = true;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlCommand = "SELECT Title FROM Favorites,Movies WHERE MovieID=imdbID AND Username=@username";
        SqlCommand command = new SqlCommand(sqlCommand, connection);
        //command.Parameters.AddWithValue("@table", table);
        command.Parameters.AddWithValue("@username", Session["username"]);
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        DataSet ds = new DataSet();

        try {
            connection.Open();
            adapter.Fill(ds, "Favs");
            gvMyFavs.DataSource = ds;
            gvMyFavs.DataBind();
            ViewState["dataset"] = ds;
        }
        catch (Exception err) {
            //Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void btntoWatch_Click(object sender, EventArgs e) {
        //fillGVW("false");
        //fillGVAll("false");
        fillGVToWatch();
    }

    protected void fillGVToWatch() {
        gvToWatch.Visible = true;
        gvMyFavs.Visible = false;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlCommand = "SELECT Title FROM Watched,Movies WHERE MovieID=imdbID AND watched=@watched AND Username=@username";
        SqlCommand command = new SqlCommand(sqlCommand, connection);
        command.Parameters.AddWithValue("@username", Session["username"]);
        command.Parameters.AddWithValue("@watched", "false");
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        DataSet ds = new DataSet();

        try {
            connection.Open();
            adapter.Fill(ds, "Watch");
            gvToWatch.DataSource = ds;
            gvToWatch.DataBind();
            ViewState["dataset"] = ds;
        }
        catch (Exception err) {
            Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void fillGVW() {
        gvMyFavs.Visible = true;
        gvToWatch.Visible = false;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlCommand = "SELECT Title FROM Watched,Movies WHERE MovieID=imdbID AND watched=@watched AND Username=@username";
        SqlCommand command = new SqlCommand(sqlCommand, connection);
        command.Parameters.AddWithValue("@username", Session["username"]);
        command.Parameters.AddWithValue("@watched", "true");
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        DataSet ds = new DataSet();

        try {
            connection.Open();
            adapter.Fill(ds, "Watch");
            gvMyFavs.DataSource = ds;
            gvMyFavs.DataBind();
            ViewState["dataset"] = ds;
        }
        catch (Exception err) {
            Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void btnWatched_Click(object sender, EventArgs e) {
        // fillGVW("true");
        fillGVW();
    }

    protected void gvMyFavs_SelectedIndexChanged(object sender, EventArgs e) {
        pnlDetails.Visible = true;
        fillDetails();
    }

    protected void fillDetails() {
        gvMyFavs.Visible = true;
        gvToWatch.Visible = false;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "SELECT * FROM Movies";
        SqlCommand command = new SqlCommand(sqlString, connection);
        string movieTitle = gvMyFavs.DataKeys[gvMyFavs.SelectedIndex].Value.ToString();
        
        try {
            connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                if (reader["Title"].ToString().Equals(movieTitle)) {
                    // lblTitle.Text = reader["Title"].ToString();
                    Label2.Text += " " + reader["Title"].ToString();
                    lblDirector.Text = reader["Director"].ToString();
                    lblDuration.Text = reader["Runtime"].ToString();
                    lblPlot.Text = reader["Plot"].ToString();
                    imgPoster.ImageUrl = reader["Poster"].ToString();
                }
            }
        }
        catch (Exception err) {
            //Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void fillDetails2() {
        gvMyFavs.Visible = false;
        gvToWatch.Visible = true;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "SELECT * FROM Movies";
        SqlCommand command = new SqlCommand(sqlString, connection);
        string movieTitle = gvToWatch.DataKeys[gvToWatch.SelectedIndex].Value.ToString();

        try {
            connection.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                if (reader["Title"].ToString().Equals(movieTitle)) {
                    // lblTitle.Text = reader["Title"].ToString();
                    Label2.Text += " " + reader["Title"].ToString();
                    lblDirector.Text = reader["Director"].ToString();
                    lblDuration.Text = reader["Runtime"].ToString();
                    lblPlot.Text = reader["Plot"].ToString();
                    imgPoster.ImageUrl = reader["Poster"].ToString();
                }
            }
        }
        catch (Exception err) {
            Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }
    protected void gvToWatch_SelectedIndexChanged(object sender, EventArgs e) {
        fillDetails2();
    }

    protected void gvToWatch_RowDeleting(object sender, GridViewDeleteEventArgs e) {
        gvToWatch.SelectedIndex = e.RowIndex;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "UPDATE Watched SET watched=@watched WHERE Username=@username AND MovieID=(SELECT imdbID FROM Movies WHERE Movies.Title=@title)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@username", Session["username"].ToString());
        command.Parameters.AddWithValue("@watched", "true");
        command.Parameters.AddWithValue("@title",gvToWatch.DataKeys[gvToWatch.SelectedIndex].Value.ToString());
        
        try {
            connection.Open();
            command.ExecuteNonQuery();
            
           
        }
        catch (Exception err) {
            Label1.Text = err.Message;
        }
        finally {
            fillGVToWatch();
            connection.Close();
        }
    }

    protected void gvToWatch_RowEditing(object sender, GridViewEditEventArgs e) {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "UPDATE Watched SET watched=true WHERE Username=@username AND MovieID=(SELECT imdbID FROM Movies WHERE Movies.Title=Watched.Title)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@username", Session["username"].ToString());
        fillGVToWatch();
    }
}