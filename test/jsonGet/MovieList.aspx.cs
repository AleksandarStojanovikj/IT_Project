using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovieList : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            if (Session["username"] == null) {
                Response.Redirect("Login.aspx");
            }

            fillGV();
            fillLB();
        }
        
    }

    void fillGV() {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlCommand = "SELECT Title FROM Movies";
        SqlCommand command = new SqlCommand(sqlCommand, connection);

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        DataSet ds = new DataSet();

        try {
            connection.Open();
            adapter.Fill(ds, "Movies");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            ViewState["dataset"] = ds;
        }
        catch (Exception err) {
            Label1.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    void fillLB() {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlCommand = "SELECT Title FROM Movies";
        SqlCommand command = new SqlCommand(sqlCommand, connection);

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



    protected void btnAddToFav_Click(object sender, EventArgs e) {
        if (ListBox1.SelectedIndex != -1) {          
            string movieTitle = ListBox1.SelectedItem.ToString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            string sqlString = "SELECT * FROM Movies WHERE Title=@title";
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@title", movieTitle);

            Movie tempMovie = new Movie();

            try {
                connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    tempMovie.Title = reader["Title"].ToString();
                    tempMovie.imdbID = reader["imdbID"].ToString();
       
                }                
            }
            catch (Exception err) {
                Label1.Text = err.Message;
            }
            finally {
                Label1.Text = tempMovie.imdbID;
                connection.Close();
            }

            sqlString = "INSERT INTO Favorites (MovieID, Username) VALUES (@MovieID, @Username)";
            SqlCommand command2 = new SqlCommand(sqlString, connection);
            command2.Parameters.AddWithValue("@MovieID", tempMovie.imdbID);
            command2.Parameters.AddWithValue("@Username", Session["username"]);
            
            try {
                connection.Open();
                command2.ExecuteNonQuery();
            }
            catch(Exception err) {
                Label1.Text = err.Message;
            }
            finally {
                Label1.Text = "Added to fav";
                connection.Close();
            }


        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e) {
        Label1.Text = "changed";
        if (ListBox1.SelectedIndex != -1) {
            
            string movieTitle = ListBox1.SelectedIndex.ToString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            //string sqlString = "SELECT * FROM Movies WHERE Title=@title";
            string sqlString = "SELECT * FROM Movies";
            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@title", movieTitle);

            Movie tempMovie = new Movie();

            try {
                connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    if (reader["Title"].ToString().Equals(movieTitle)) {
                        tempMovie.Title = reader["Title"].ToString();
                        tempMovie.imdbID = reader["imdbID"].ToString();
                        ViewState["tempMov"] = tempMovie;
                        Label1.Text = tempMovie.Title;
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
    }
}