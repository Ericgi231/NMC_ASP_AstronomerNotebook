using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstronomerNotebook.Models
{
    public class Cluster
    {

        public virtual ICollection<Star> Stars { get; set; }
    }
}