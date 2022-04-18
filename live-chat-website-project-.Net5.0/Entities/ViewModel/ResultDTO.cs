using Entities.Abstract;
using System;

namespace Entities.ViewModel
{
    public class ResultDTO<T> : IDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
