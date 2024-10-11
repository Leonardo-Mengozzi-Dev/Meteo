using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmptyBlazorAppMeteo_001.Class.Tables
{
    public class Sensori : ITables
    {
        [Key]
        [DisplayName("Id codice Sensore")]
        public int IdCodiceSensore_ { get; set; }
        [DisplayName("Camera")]
        public int Camera_ { get; set; }
        [StringLength(30, ErrorMessage = "Lunghezza stringa Nome non idonea, max 30 caratteri.")]
        [DisplayName("Nome")]
        public string Nome_ { get; set; }
        [StringLength(30, ErrorMessage = "Lunghezza stringa Tipo non idonea, max 30 caratteri")]
        [DisplayName("Tipo")]
        public string Tipo_ { get; set; }
        [StringLength(40, ErrorMessage = "Lunghezza stringa Caratteristiche non idonea, max 40 caratteri")]
        [DisplayName("Caratteristiche")]
        public string Caratteristiche_ { get; set; }
        [StringLength(50, ErrorMessage = "Lunghezza stringa Note non idonea, max 50 caratteri")]
        [DisplayName("Note")]
        public string Note_ { get; set; }
        [Required(ErrorMessage = "Codice Grandezza fisica mancante.")]
        [DisplayName("Id Grandezza Fisica")]
        public int IdGrandezzaFisica_ { get; set; }

        public Sensori(int idgf, int c, string n, string t, string car, string note)
        {
            IdGrandezzaFisica_ = idgf;
            Camera_ = c;
            Nome_ = n;
            Tipo_ = t;
            Caratteristiche_ = car;
            Note_ = note;
        }

        public Sensori()
        {
            
        }
    }
}
