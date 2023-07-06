using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace General_Learning
{
    public class VideoPost : Post
    {
        protected string VideoUrl { get; set; }
        protected int Length { get; set; }
        protected bool IsPlaying { get; set; }
        protected int CurrDuration { get; set; }
        protected Timer timer { get; set; }

        public VideoPost()
        {
            // empty constructor
            // Implicitly call parent class's (Post) default controller
            IsPlaying = false;
        }

        public VideoPost(string setTitle, string setSentBy, string setVideoUrl, int setLength, bool setIsPublic)
            : base(setTitle, setSentBy, setIsPublic)
        {
            VideoUrl = setVideoUrl;
            Length = setLength;
            IsPlaying = false;
        }

        private void TimerCallback(Object o)
        {
            if (CurrDuration < Length)
            {
                CurrDuration++;
                Console.WriteLine("Video at {0} seconds", CurrDuration);
                GC.Collect();
            }
            else
            {
                Stop();
            }
        }

        public void Stop()
        {
            if (IsPlaying)
            {
                Console.WriteLine("Stopped at {0} seconds", CurrDuration);
                CurrDuration = 0;
                timer.Dispose();
                IsPlaying = false;
            }
        }


        public override string ToString() // Can override an overriding method
        {
            //return base.ToString();
            return string.Format("{0} - {1} - by {2}\nURL: {3}\nLength: {4}", Id, Title, SentBy, VideoUrl, Length);
        }

        public void Play()
        {
            if (!IsPlaying)
            {
                Console.WriteLine("Playing");
                timer = new Timer(TimerCallback, null, 0, 1000); // run the function TimerCallback every 1000 milliseconds.
                IsPlaying = true;
            }
        }
    }
}
