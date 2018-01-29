using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Home : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            loadContentOther();
            loadContentRecommended();
            if (Session["username"] == null) {
                Response.Redirect("Login.aspx");
            }
        }
    }

    protected void loadContentRecommended() {
        List<Movie> movies = new List<Movie>();
        for (int i = 0; i < 3; i++) {
            movies.Add(new Movie());
        }
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "Select TOP 3 * FROM Movies ORDER BY CHECKSUM(NEWID())";
        SqlCommand command = new SqlCommand(sqlString, connection);

        try {
            connection.Open();
            command.ExecuteNonQuery();
            int i = 0;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {

                movies[i].Title = reader["Title"].ToString();
                movies[i].Poster = reader["Poster"].ToString();
                movies[i].Plot = reader["Plot"].ToString();
                movies[i].Year = " (" + reader["Year"].ToString() + ")";
                movies[i].imdbID = reader["imdbID"].ToString();
                i++;
                if (i == 3) {
                    break;
                }
            }

            img1.ImageUrl = movies[0].Poster;
            img2.ImageUrl = movies[1].Poster;
            img3.ImageUrl = movies[2].Poster;
            lblCD1.Text = movies[0].Plot;
            lblCD2.Text = movies[1].Plot;
            lblCD3.Text = movies[2].Plot;
            lblCT1.Text = movies[0].Title;
            lblCT2.Text = movies[1].Title;
            lblCT3.Text = movies[2].Title;
            lblYear1.Text = movies[0].Year;
            lblYear2.Text = movies[1].Year;
            lblYear3.Text = movies[2].Year;
            ViewState["movieListR"] = movies;

        }
        catch (Exception err) {
            lblError.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void loadContentOther() {
        List<Movie> movies = new List<Movie>();
        for (int i = 0; i < 3; i++) {
            movies.Add(new Movie());
        }
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        // string sqlString = "Select Distinct Top 3 *  From Movies,Watched,Favorites WHERE Movies.imdbID=Watched.MovieID OR Movies.imdbID=Favorites.MovieID ORDER BY imdbRating";
        string sqlString = "Select DISTINCT TOP 3 CHECKSUM(NEWID()),Watched.MovieID,Title,Year,Plot,Poster,imdbID FROM Movies,Watched,Favorites WHERE Movies.imdbRating=Watched.MovieID OR Movies.imdbID=Favorites.MovieID ORDER BY CHECKSUM(NEWID())";
        SqlCommand command = new SqlCommand(sqlString, connection);


        try {
            connection.Open();
            command.ExecuteNonQuery();
            int i = 0;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {

                movies[i].Title = reader["Title"].ToString();
                movies[i].Poster = reader["Poster"].ToString();
                movies[i].Plot = reader["Plot"].ToString();
                movies[i].Year = " (" + reader["Year"].ToString() + ")";
                movies[i].imdbID = reader["imdbID"].ToString();
                i++;

                if (i == 3) {
                    break;
                }
            }

            img11.ImageUrl = movies[0].Poster;
            img22.ImageUrl = movies[1].Poster;
            img33.ImageUrl = movies[2].Poster;
            lblCD11.Text = movies[0].Plot;
            lblCD22.Text = movies[1].Plot;
            lblCD33.Text = movies[2].Plot;
            lblCT11.Text = movies[0].Title;
            lblCT22.Text = movies[1].Title;
            lblCT33.Text = movies[2].Title;
            lblYear11.Text = movies[0].Year;
            lblYear22.Text = movies[1].Year;
            lblYear33.Text = movies[2].Year;
            ViewState["movieListO"] = movies;

        }
        catch (Exception err) {
            lblError.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void addToFavorites(string id) {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "INSERT INTO Favorites (MovieID, Username) values (@movieID, @username)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@movieID", id);
        command.Parameters.AddWithValue("@username", Session["username"].ToString());

        try {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception err) {
            lblError.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void addToWatch(string id) {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "INSERT INTO Watched (MovieID, Username, watched) values (@movieID, @username, @watched)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@movieID", id);
        command.Parameters.AddWithValue("@username", Session["username"].ToString());
        command.Parameters.AddWithValue("@watched", "false");

        try {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception err) {
            lblError.Text = err.Message;
        }
        finally {
            connection.Close();
        }
    }

    protected void btnFav1_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListR"] as List<Movie>;
        addToFavorites(movies[0].imdbID.ToString());
    }

    protected void btnFav2_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListR"] as List<Movie>;
        addToFavorites(movies[1].imdbID.ToString());
    }

    protected void btnFav3_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListR"] as List<Movie>;
        addToFavorites(movies[2].imdbID.ToString());
    }

    protected void btnFav4_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListO"] as List<Movie>;
        addToFavorites(movies[0].imdbID.ToString());
    }

    protected void btnFav5_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListO"] as List<Movie>;
        addToFavorites(movies[1].imdbID.ToString());
    }

    protected void btnFav6_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListO"] as List<Movie>;
        addToFavorites(movies[2].imdbID.ToString());
    }

    protected void btnWatch1_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListR"] as List<Movie>;
        addToWatch(movies[0].imdbID.ToString());
    }

    protected void btnWatch2_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListR"] as List<Movie>;
        addToWatch(movies[1].imdbID.ToString());
    }

    protected void btnWatch3_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListR"] as List<Movie>;
        addToWatch(movies[2].imdbID.ToString());
    }

    protected void btnWatch4_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListO"] as List<Movie>;
        addToWatch(movies[0].imdbID.ToString());
    }

    protected void btnWatch5_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListO"] as List<Movie>;
        addToWatch(movies[1].imdbID.ToString());
    }

    protected void btnWatch6_Click(object sender, EventArgs e) {
        List<Movie> movies = ViewState["movieListO"] as List<Movie>;
        addToWatch(movies[2].imdbID.ToString());
    }
}