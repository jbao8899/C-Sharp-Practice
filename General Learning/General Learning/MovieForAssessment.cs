using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class MovieForAssessment
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }

        public MovieForAssessment(string setTitle, string setGenre, int setRating)
        {
            Title = setTitle;
            Genre = setGenre;
            Rating = setRating;
        }
    }
}
