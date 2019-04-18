using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstronomerNotebook.Models
{
    public enum Constellation
    {
        CANIS_MAJOR,
        CARINA,
        CENTAURUS,
        BOOTES,
        LYRA,
        AURIGA,
        ORION,
        CANIS_MINOR,
        ERIDANUS
    }

    public class Star
    {
        public int StarId { get; set; }
        public string Name { get; set; }
        public Constellation Constellation { get; set; }
        public double ApparentMagnitude { get; set; }

        public int ClusterId { get; set; }

        public virtual Cluster Cluster { get; set; }
    }
}