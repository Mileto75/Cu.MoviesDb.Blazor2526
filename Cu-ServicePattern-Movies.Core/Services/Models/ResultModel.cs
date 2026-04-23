using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cu_ServicePattern_Movies.Core.Services.Models
{
    public class ResultModel<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
