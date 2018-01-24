using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Web.Script.Serialization;

public partial class _Default : System.Web.UI.Page {

    private string omdbAPIkey = "71ba156e";
    private string theMovieDBAPIkey = "9f5e9273621976e8df819f7325941b75";
    Movie obj = new Movie();

    protected void Page_Load(object sender, EventArgs e) {
        btnSaveMovie.Visible = false;
    }

    protected void btnSearch_Click1(object sender, EventArgs e) {
        string Title = tbMovieName.Text.Trim();

        string url = "http://www.omdbapi.com/?apikey=" + omdbAPIkey + "&t=" + Title;
        string url2 = "http://www.omdbapi.com/?apikey=" + omdbAPIkey + "&s=" + Title;
        
        if (tbYear.Text.Length != 0) {
            url = url + "&y=" + tbYear.Text.Trim();
        }

        using (WebClient wc = new WebClient()) {
            var json2 = wc.DownloadString(url2);
            var json = wc.DownloadString(url);

            Label4.Text = json2.ToString();
            JavaScriptSerializer oJS = new JavaScriptSerializer();
            
            obj = oJS.Deserialize<Movie>(json);
            if(obj.Response == "True") {
                Label1.Text = obj.ToString();
                Label2.Text = obj.Title;
                Label3.Text = obj.Type;
                btnSaveMovie.Visible = true;
            }
            else {
                Label1.Text = "Not found";
            }
            Image1.ImageUrl = obj.Poster;
            Session["object"] = obj;
        }
    }

    protected void saveMovie_Click(object sender, EventArgs e) {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        string sqlString = "INSERT INTO Movies (Title, Stars, Year, Rated, Released, Runtime, Genre, Director, Writer, " +
            "Actors, Plot, Language, Country, Awards, Poster, Metascore, imdbRating, imdbVotes, imdbID, Type, Response) " +
            "values(@Title, @Stars, @Year, @Rated, @Released, @Runtime, @Genre, @Director, @Writer, " +
            "@Actors, @Plot, @Language, @Country, @Awards, @Poster, @Metascore, @imdbRating, @imdbVotes, @imdbID, @Type, @Response)";
        SqlCommand command = new SqlCommand(sqlString, connection);
        obj = Session["object"] as Movie;
        command.Parameters.AddWithValue("@Title", obj.Title);
        command.Parameters.AddWithValue("@Stars", obj.imdbRating);
        command.Parameters.AddWithValue("@Year", obj.Year);
        command.Parameters.AddWithValue("@Rated", obj.Rated);
        command.Parameters.AddWithValue("@Released", obj.Released);
        command.Parameters.AddWithValue("@Runtime", obj.Runtime);
        command.Parameters.AddWithValue("@Genre", obj.Genre);
        command.Parameters.AddWithValue("@Director", obj.Director);
        command.Parameters.AddWithValue("@Writer", obj.Writer);
        command.Parameters.AddWithValue("@Actors", obj.Actors);
        command.Parameters.AddWithValue("@Plot", obj.Plot);
        command.Parameters.AddWithValue("@Language", obj.Language);
        command.Parameters.AddWithValue("@Country", obj.Country);
        command.Parameters.AddWithValue("@Awards", obj.Awards);
        command.Parameters.AddWithValue("@Poster", obj.Poster);
        command.Parameters.AddWithValue("@Metascore", obj.Metascore);
        command.Parameters.AddWithValue("@imdbRating", obj.imdbRating);
        command.Parameters.AddWithValue("@imdbVotes", obj.imdbVotes);
        command.Parameters.AddWithValue("@imdbID", obj.imdbID);
        command.Parameters.AddWithValue("@Type", obj.Type);
        command.Parameters.AddWithValue("@Response", obj.Response);

        try {
            connection.Open();
            command.ExecuteNonQuery();
            Label4.Text = "Movie saved";
        }
        catch(Exception err) {
            Label4.Text = err.ToString();
        }
        finally {
            connection.Close();
        }
    }
}




/* var json = new WebClient().DownloadString("http://www.omdbapi.com/?apikey=" + omdbAPIkey + "&t=" + Title);
  Label1.Text = "test";
  //Movie jsonSer = JsonConvert.DeserializeObject<Movie>(json);
  JObject test = JObject.Parse(json);
  IList<JToken> results = test;
  IList<JToken> rez = results.Children().ToList();   
  // Movie mov = results.ToObject<Movie>();
  IList<Movie> seachMovie = new List<Movie>();
  foreach(JToken result in results) {
      Movie sMovie = result.ToObject<Movie>();
      seachMovie.Add(sMovie);
  }

  Label2.Text = seachMovie.ToString();

*/



// wc.DownloadFile(obj.Poster, @"c:\temp\testimg.jpg");
//wc.DownloadFile(new Uri(obj.Poster), @"c:\testimg.jpg");
//Image1.ImageUrl = @"c:\testimg.jpg";