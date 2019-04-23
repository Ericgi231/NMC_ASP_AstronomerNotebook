using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AstronomerNotebook.Models
{
    public class Cluster
    {
        [Key]
        [Column(name:"ClusterId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for this object.")]
        [Display(Name = "Cluster Name")]
        public string Name { get; set; }
        public Constellation Constellation { get; set; }
        [Display(Name = "Cluster Type")]
        public ClusterType ClusterType { get; set; }
        [Display(Name = "Apparent Magnitude")]
        public double? ApparentMagnitude { get; set; }
        [Display(Name = "Right Ascension")]
        [Range(1, 2459)]
        public double? RightAscension { get; set; }
        [Range(-90, 90)]
        public double? Declination { get; set; }

        [Display(Name = "Astronomer")]
        public int? AstronomerId { get; set; }
        [Display(Name = "Galaxy")]
        public int? GalaxyId { get; set; }


        public virtual Galaxy Galaxy { get; set; }
        public virtual Astronomer Astronomer { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
    }
}