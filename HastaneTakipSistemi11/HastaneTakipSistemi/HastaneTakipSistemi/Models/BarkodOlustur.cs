using System.ComponentModel.DataAnnotations;

namespace HastaneTakipSistemi.Models
{
    public class HastaOzellikleri
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string HastaAdi { get; set; }

        [StringLength(11)]
        public string tcNo { get; set; }

        public bool EngelDurumu { get; set; }

        [Required(ErrorMessage ="Bos geçmeyiniz")]
        public int Yas { get; set; }
    }
}
