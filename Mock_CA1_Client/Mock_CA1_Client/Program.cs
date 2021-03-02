using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Mock_CA1_Client.Models;
namespace Mock_CA1_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllMovies().Wait();
            Console.WriteLine();
            GetAMovie().Wait();
            Console.WriteLine();
            GetKeyword().Wait();
        }


        //Async methods to communicate with the restFul APIs
        //Get all movies
        private static async Task GetAllMovies()    //an async method returns a Task pr Task<T> 
        {

            try
            {
                //1. Class HTTP Client to talk to restFul API
                HttpClient client = new HttpClient();

                //2.  Base URL for API controller eg. restFull service
                client.BaseAddress = new Uri("http://localhost:63290/");

                //3. Adding a accept header eg. application/json
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //4. HTTP response from the GET API -- async call, await suspends until task finished
                HttpResponseMessage response = await client.GetAsync("api/Movie");


                response.EnsureSuccessStatusCode(); //Throw exception if not success

                List<Movie> movies = await response.Content.ReadAsAsync<List<Movie>>();

                foreach (Movie m in movies)
                {
                    Console.WriteLine("\n" + m.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }


        //Get a specific movie
        private static async Task GetAMovie()    //an async method returns a Task pr Task<T> 
        {

            try
            {
                //1. Class HTTP Client to talk to restFul API
                HttpClient client = new HttpClient();

                //2.  Base URL for API controller eg. restFull service
                client.BaseAddress = new Uri("http://localhost:63290/");

                //3. Adding a accept header eg. application/json
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //4. HTTP response from the GET API -- async call, await suspends until task finished
                HttpResponseMessage response = await client.GetAsync("api/Movie/2");


                response.EnsureSuccessStatusCode(); //Throw exception if not success

                Movie aMovie = await response.Content.ReadAsAsync<Movie>();

                Console.WriteLine(aMovie.ToString());


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }


        //Get list of movies containing a keyword
        private static async Task GetKeyword()    //an async method returns a Task pr Task<T> 
        {

            try
            {
                //1. Class HTTP Client to talk to restFul API
                HttpClient client = new HttpClient();

                //2.  Base URL for API controller eg. restFull service
                client.BaseAddress = new Uri("http://localhost:63290/");

                //3. Adding a accept header eg. application/json
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //4. HTTP response from the GET API -- async call, await suspends until task finished
                HttpResponseMessage response = await client.GetAsync("api/Movie/GetMovies/r");


                response.EnsureSuccessStatusCode(); //Throw exception if not success

                List<Movie> movies = await response.Content.ReadAsAsync<List<Movie>>();

                foreach (Movie m in movies)
                {
                    Console.WriteLine("\n" + m.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

        }

    }
}