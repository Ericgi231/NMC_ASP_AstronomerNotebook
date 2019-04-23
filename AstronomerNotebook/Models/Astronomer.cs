using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AstronomerNotebook.Models
{
    public class Astronomer
    {
        [Key]
        [Column(name: "AstronomerId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for this astronomer.")]
        [Display(Name = "Astronomer Name")]
        public string Name { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
        public virtual ICollection<Cluster> Clusters { get; set; }
        public virtual ICollection<Galaxy> Galaxies { get; set; }
    }
}