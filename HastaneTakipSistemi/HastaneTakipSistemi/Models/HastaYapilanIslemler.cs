using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneTakipSistemi.Models
{
    public class HastaYapilanIslemler
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime giris { get; set; }

        public DateTime cikis { get; set; }

        [Display(Name ="Tedavi Açıklaması")]
        public string tedaviAciklamasi { get; set; }

        [ForeignKey("BarkodOlustur")]
        public int barkodOlusturId { get; set; }
        public BarkodOlustur barkodOlustur { get; set; }
    }
}
