using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class ImagePost : Post
    {
        public string ImageUrl { get; set; }

        public ImagePost()
        {
            // empty constructor
            // Implicitly call parent class's (Post) default controller
        }

        public ImagePost(string setTitle, string setSentBy, string setImageUrl, bool setIsPublic) : base(setTitle, setSentBy, setIsPublic)
        {
            ImageUrl = setImageUrl;
        }

        public override string ToString() // Override this method from the Post class
        {
            //return base.ToString();
            return string.Format("{0} - {1} - {2} - by {3}", Id, Title, ImageUrl, SentBy);
        }
    }
}