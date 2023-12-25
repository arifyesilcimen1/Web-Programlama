using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneTakipSistemi.Models
{
    public class HastaYapilanIslemler
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(BarkodOlustur))]
        public int barkodId { get; set; }   
        public BarkodOlustur barkodOlustur { get; set; }  
    
        




    }
}
