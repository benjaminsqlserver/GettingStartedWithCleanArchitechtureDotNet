using Movies.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Entities
{
    public class Movie:Entity
    {
        public string MovieName { get; set; }
        public string DirectorName { get; set; }

        public string ReleaseYear { get; set; }
    }
}
