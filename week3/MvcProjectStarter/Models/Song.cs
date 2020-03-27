using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectStarter.Models
{
    public class Song
    {   
        public int id { get; set; }
        
           [StringLength(60, MinimumLength = 3)]
            [Required]
        public string title { get; set; }

        public string genre { get; set; }
        public string artist { get; set; }
        public string album { get; set; }

        //annotation
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

    }
}
