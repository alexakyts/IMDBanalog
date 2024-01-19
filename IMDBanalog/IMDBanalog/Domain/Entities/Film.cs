using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Domain.Entities
{
    public class Film
    {
        public  int Id {get;set;}


        public  string Name { get; set; }

        public  string ReleaseDate { get; set; }

        public  string Director { get; set; }

        public  string Genres { get; set; }

        public  string Rating { get; set; }

        public  int Runtime { get; set; }

        public  int Metacritics { get; set; }

        public  int RottenTomatoes { get; set; }

        public string image { get; set; }

        public string Summary { get; set; }

        public virtual ICollection<Comment> UserRate { get; set; }
    }
}
