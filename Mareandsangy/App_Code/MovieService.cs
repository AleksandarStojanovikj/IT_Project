using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for MovieService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MovieService : System.Web.Services.WebService {

    private string omdbAPIkey = "71ba156e";

    public MovieService() {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description ="This method returns a movie object from the imdb api")]
    public Movie getMovie(string title, string year) {

        Movie movie = new Movie();
        string url = "http://www.omdbapi.com/?apikey=" + omdbAPIkey + "&t=" + title;
        if (year.Length != 0) {
            url = url + "&y=" + year.Trim();
        }
        
        using (WebClient wc = new WebClient()) {
            var json = wc.DownloadString(url);

            JavaScriptSerializer oJS = new JavaScriptSerializer();

            movie = oJS.Deserialize<Movie>(json);
            if (movie.Response == "True") {
                return movie;
            }
            else {
                return new Movie();
            }
        }
    }

}
