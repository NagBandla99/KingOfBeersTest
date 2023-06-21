namespace NB.KingOfBeers.Database.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BarBeers
    {
        [Key]
        public int BarBeerId { get; set; }

        public int BarId { get; set; }

        public int BreweryId { get; set; }

        public int BeerId { get; set; }

        public virtual Beer Beer { get; set; }

        public virtual Bar Bar { get; set; }
    }
}
