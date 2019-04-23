using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AstronomerNotebook.Models
{
    public class Star
    {
        [Key]
        [Column(name: "StarId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for this object.")]
        public string Name { get; set; }
        public Constellation Constellation { get; set; }
        [Display(Name = "Apparent Magnitude")]
        public double ApparentMagnitude { get; set; }
        [Display(Name = "Right Ascension")]
        public double RightAscension { get; set; }
        public double Declination { get; set; }
        
        public int? AstronomerId { get; set; }
        public int? ClusterId { get; set; }

        public virtual Cluster Cluster { get; set; }
        public virtual Astronomer Astronomer { get; set; }
    }
}