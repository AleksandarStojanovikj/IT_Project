using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class OtherUserPage : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            if (Session["username"] == null) {
                Response.Redirect("Login.aspx");
            }
            if (Session["otherUser"] == null) {
                Response.Redirect("Home.aspx");
            }
            btnFavorites.Text = Session["otherUser"].ToString() + "'s favorites";
            btntoWatch.Text = Session["otherUser"].ToString() + "'s to watch";
            btnWatched.Text = Session["otherUser"].ToString() + "'s watched";
        }
    }

    protected void btnFavorites_Click(object sender, EventArgs e) {
        fillGV();
    }

    protected void btntoWatch_Click(object sender, EventArgs e) {
        fillGVW(0);
    }

    protected void btnWatched_Click(object sender, EventArgs e) {
        fillGVW(1);
    }

    protected void gvMyFavs_SelectedIndexChanged(object sender, EventArgs e) {
        pnlDetails.Visible = true;
        fillDetails();
    }

    protected void fillGV() {
        gvMyFavs.Visible = true;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlCommand = "SELECT Title FROM Favorites,Movies WHERE MovieID=imdbID AND Username=@username";
        SqlCommand command = new SqlCommand(sqlCommand, connection);
        //command.Parameters.AddWithValue("@table", table);
        command.Parameters.AddWithValue("@username", Session["otherUser"]);
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
            Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void fillGVW(int mode) {
        /*
         *  mode = 0 => watched=FALSE
         *  mode = 1 => watched=TRUE
         */

        gvMyFavs.Visible = true;
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlCommand = "SELECT Title FROM Watched,Movies WHERE MovieID=imdbID AND watched=@watched AND Username=@username";
        SqlCommand command = new SqlCommand(sqlCommand, connection);
        command.Parameters.AddWithValue("@username", Session["otherUser"]);
        if (mode == 0) {
            command.Parameters.AddWithValue("@watched", "false");
        }
        else {
            command.Parameters.AddWithValue("@watched", "true");
        }

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



    protected void fillDetails() {
        gvMyFavs.Visible = true;
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
            Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void gvMyFavs_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e) {
        gvMyFavs.PageIndex = e.NewPageIndex;
        gvMyFavs.SelectedIndex = -1;
        DataSet ds = (DataSet)ViewState["dataset"];
        gvMyFavs.DataSource = ds;
        gvMyFavs.DataBind();
        gvMyFavs.Visible = true;
        pnlDetails.Visible = false;
    }
}
