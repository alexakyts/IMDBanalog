using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string User { get; set; }

        public int Rate { get; set; }
        
        public virtual Film Film { get; set; }
    }
}
