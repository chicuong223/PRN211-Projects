using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")]    //Display 'Release Date' instead of 'ReleasedDate'
        [DataType(DataType.Date)]   //let user enter date only
        public DateTime ReleasedDate { get; set; }
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18,2)")]    //Format number for Price
        public decimal Price { get; set; }

    }
}
