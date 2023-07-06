using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Post
    {
        private static int currentPostId;

        // Properties
        // protected means that the property can be used by Post and any derived classes
        protected int Id { get; set; }
        protected string Title { get; set; }
        protected string SentBy { get; set; }
        protected bool IsPublic { get; set; }

        // If a derived class does not invoke a base-class constructor explicitly,
        // the default constructor is called implicitly.
        // So we want a default constructor here
        public Post()
        {
            Id = GetNextId();
            Title = "No Title";
            SentBy = "No Author";
            IsPublic = true;
        }

        public Post(string setTitle, string setSentBy, bool setIsPublic)
        {
            Id = GetNextId();
            Title = setTitle;
            SentBy = setSentBy;
            IsPublic = setIsPublic;
        }

        protected int GetNextId()
        {
            return ++currentPostId;
        }

        public void Update(string newTitle, bool setIsPublic)
        {
            Title = newTitle;
            IsPublic = setIsPublic;
        }

        public override string ToString() // Override this method from the Object class
        {
            //return base.ToString();
            return string.Format("{0} - {1} - by {2}", Id, Title, SentBy);
        }
    }
}
