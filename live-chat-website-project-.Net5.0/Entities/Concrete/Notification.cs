using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationDetails { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }

    }
}
