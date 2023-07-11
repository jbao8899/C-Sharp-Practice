using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class VideoEncoder
    {
        // Better to use interface here, for testability
        //private readonly MailService _mailService;

        private readonly IList<INotificationChannel> _notificationChannels;

        public VideoEncoder()
        {
            //_mailService = new MailService();

            _notificationChannels = new List<INotificationChannel>();
        }

        public void RegisterNotificationChannel(INotificationChannel channel)
        {
            _notificationChannels.Add(channel);
        }

        public void Encode(Video video)
        {
            //_mailService.Send(new Mail());

            foreach (INotificationChannel channel in _notificationChannels)
            {
                channel.Send(new Message());
            }
        }
    }
}
