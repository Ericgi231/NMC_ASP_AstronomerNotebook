using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AstronomerNotebook.Models;

namespace AstronomerNotebook.ViewModels
{
    public class AstronomerIndexData
    {
        public IEnumerable<Astronomer> Astronomers { get; set; }
        public IEnumerable<Galaxy> Galaxies { get; set; }
        public IEnumerable<Cluster> Clusters { get; set; }
        public IEnumerable<Star> Stars { get; set; }
    }
}