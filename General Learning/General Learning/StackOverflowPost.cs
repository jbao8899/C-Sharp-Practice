using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class StackOverflowPost
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; private set; }
        public int Score { get; private set; }

        public StackOverflowPost(string setTitle, string setBody)
        {
            Title = setTitle;
            Body = setBody;
            CreationTime = DateTime.Now;
            Score = 0;
        }

        public void Upvote()
        {
            Score++;
        }

        public void Downvote() 
        {
            Score--;
        }
    }
}
