using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cu_ServicePattern_Movies.Core.Entities
{
    public class Director : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        //many to many movies
        public ICollection<Movie> Movies{ get; set; }
    }
}
