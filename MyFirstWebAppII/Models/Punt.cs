using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAppII.Models
{
    public class Punt
    {
        public int Id { get; set; }
        public string Leerling { get; set; }
        //public string Achternaam { get; set; }
        public string Klas { get; set; }

        [Display(Name = "Minimum")]
        public int Min { get; set; }

        [Display(Name = "Maximum")]
        public int Max { get; set; }
    }
}