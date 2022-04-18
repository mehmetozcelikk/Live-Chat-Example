using Entities.Abstract;
using System;

namespace Entities.ViewModel
{
    public class MessageDTO : BaseDTO, IDTO
    {
        public int ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; }
    }
}
