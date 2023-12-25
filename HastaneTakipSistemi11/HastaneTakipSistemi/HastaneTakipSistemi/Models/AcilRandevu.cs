using System.ComponentModel.DataAnnotations;

namespace HastaneTakipSistemi.Models
{
    public class AcilRandevu
    {
        [Key]
        public int Id { get; set; }

        public enum Kod { 
        yesil=1,
        sari=2,
        kirmizi=3,
        }

        public int barkodNumarasi { get; set; }


    }
}
