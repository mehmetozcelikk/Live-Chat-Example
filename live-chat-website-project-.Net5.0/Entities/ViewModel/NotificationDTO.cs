using Entities.Abstract;
using System;

namespace Entities.ViewModel
{
    public class NotificationDTO : BaseDTO, IDTO
    {
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationDetails { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }
    }
}
