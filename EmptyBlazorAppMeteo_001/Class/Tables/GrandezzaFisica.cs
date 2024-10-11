using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmptyBlazorAppMeteo_001.Class.Tables
{
    public class GrandezzaFisica : ITables
    {
        [Key]
        [DisplayName("Id Grandeza Fisica")]
        public int IdGrandezzaFisica_ { get; set; }

        [StringLength(20, ErrorMessage = "Lunghezza stringa GrandezzaFisica mancante non idonea, max 20 caratteri")]
        [Required(ErrorMessage = "Grandezza fisica mancante.")]
        [DisplayName("Grandezza Fisica")]
        public string GrandezzaFisica_ { get; set; }

        [StringLength(6, ErrorMessage = "Lunghezza stringa Simbolo mancante non idonea, max 6 caratteri")]
        [DisplayName("Simbolo")]
        public string Simbolo_ { get; set; }

        [StringLength(6, ErrorMessage = "Lunghezza stringa Simbolo unità di misura adottato non idonea, max 6 caratteri")]
        [Required(ErrorMessage = "Simbolo Unità di Misura mancante.")]
        [DisplayName("Simbolo Unità di Misura")]
        public string SimboloUnitaMisuraAdottato_ { get; set; }

        [StringLength(45, ErrorMessage = "Lunghezza stringa Note non idonea, max 45 caratteri")]
        [DisplayName("Note")]
        public string Note_ { get; set; }

        public GrandezzaFisica(int id, string gf, string s, string sud, string n)
        {
            IdGrandezzaFisica_ = id;
            GrandezzaFisica_ = gf;
            Simbolo_ = sud;
            SimboloUnitaMisuraAdottato_ = sud;
            Note_ = n;
        }

        public GrandezzaFisica()
        {
            
        }

    }
}
