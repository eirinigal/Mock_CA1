using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mock_CA1_Client.Models
{
    public enum Genres { Action, Adventure, Animation, Comedy, Crime, Drama, Fantasy, Family};
    public enum Certification { Universal, Twelve, Fifteen, Eighteen};

    public class Movie
    {
        //Attributes/Properties of a Movie Entry
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Movie title is required!")]
        public string Title { get; set; }
        public Genres Genre { get; set; }
        public DateTime Date { get; set; }

        [Range(1, 10)]
        public double AvgRating { get; set; }

        
        //ToString
        public override string ToString()
        {
            //Date.ToString("dd/MM/yyyy") works in the client!!
            return String.Format("Movie Details \nID: {0} \nTitle: {1} \nGenre: {2} \nDate: {3} \nAverage Rating: {4}", ID, Title, Genre, Date.ToString("dd/MM/yyyy"), AvgRating);
        }

       
    }
}
