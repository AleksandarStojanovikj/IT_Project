using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

public partial class MovieSearch : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
            if (Session["username"] == null) {
                Response.Redirect("Login.aspx");
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        pnlMovie.Visible = true;
        string title = tbTitle.Text.Trim().ToString();
        string year = tbYear.Text.Trim().ToString();
        webServiceMovieSearch.MovieService movieService = new webServiceMovieSearch.MovieService();
        webServiceMovieSearch.Movie movie = movieService.getMovie(title, year);
        imgPoster.ImageUrl = movie.Poster;
        lblTitle.Text = " " + movie.Title;
        lblRuntime.Text = " " + movie.Runtime;
        lblActors.Text = " " + movie.Actors;
        lblDirector.Text = " " + movie.Director;
        lblWriter.Text = " " + movie.Writer;
        lblRating.Text = " " + movie.imdbRating;
        lblPlot.Text = " " + movie.Plot;
        lblGenre.Text = " " + movie.Genre;

        ViewState["imdbID"] = movie.imdbID;

        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "INSERT INTO Movies (Title, Stars, Year, Rated, Released, Runtime, Genre, Director, Writer, " +
            "Actors, Plot, Language, Country, Awards, Poster, Metascore, imdbRating, imdbVotes, imdbID, Type, Response) " +
            "values(@Title, @Stars, @Year, @Rated, @Released, @Runtime, @Genre, @Director, @Writer, " +
            "@Actors, @Plot, @Language, @Country, @Awards, @Poster, @Metascore, @imdbRating, @imdbVotes, @imdbID, @Type, @Response)";
        SqlCommand command = new SqlCommand(sqlString, connection);

        command.Parameters.AddWithValue("@Title", movie.Title);
        command.Parameters.AddWithValue("@Stars", movie.imdbRating);
        command.Parameters.AddWithValue("@Year", movie.Year);
        command.Parameters.AddWithValue("@Rated", movie.Rated);
        command.Parameters.AddWithValue("@Released", movie.Released);
        command.Parameters.AddWithValue("@Runtime", movie.Runtime);
        command.Parameters.AddWithValue("@Genre", movie.Genre);
        command.Parameters.AddWithValue("@Director", movie.Director);
        command.Parameters.AddWithValue("@Writer", movie.Writer);
        command.Parameters.AddWithValue("@Actors", movie.Actors);
        command.Parameters.AddWithValue("@Plot", movie.Plot);
        command.Parameters.AddWithValue("@Language", movie.Language);
        command.Parameters.AddWithValue("@Country", movie.Country);
        command.Parameters.AddWithValue("@Awards", movie.Awards);
        command.Parameters.AddWithValue("@Poster", movie.Poster);
        command.Parameters.AddWithValue("@Metascore", movie.Metascore);
        command.Parameters.AddWithValue("@imdbRating", movie.imdbRating);
        command.Parameters.AddWithValue("@imdbVotes", movie.imdbVotes);
        command.Parameters.AddWithValue("@imdbID", movie.imdbID);
        command.Parameters.AddWithValue("@Type", movie.Type);
        command.Parameters.AddWithValue("@Response", movie.Response);

        try {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception err) {

        }
        finally {
            connection.Close();
        }
    }

    protected void btnFav_Click(object sender, EventArgs e) {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "INSERT INTO Favorites (MovieID, Username) values (@movieID, @username)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@movieID", ViewState["imdbID"].ToString());
        command.Parameters.AddWithValue("@username", Session["username"]);

        try {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception err) {

        }
        finally {
            connection.Close();
        }
    }

    protected void btnWatch_Click(object sender, EventArgs e) {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "INSERT INTO Watched (MovieID, Username, watched) values (@movieID, @username, @watched)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        command.Parameters.AddWithValue("@movieID", ViewState["imdbID"].ToString());
        command.Parameters.AddWithValue("@username", Session["username"]);
        command.Parameters.AddWithValue("@watched", "false");

        try {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception err) {

        }
        finally {
            connection.Close();
        }
    }
}