using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmptyBlazorAppMeteo_001.Class.Tables
{
    public class Rilevamenti : ITables
    {
        [Key]
        [DisplayName("Id Rilevazione")]
        public int IdRilevamenti_ { get; set; }

        [DisplayName("Data e Ora")]
        public DateTime DataOra_ { get; set; }

        [StringLength(15, ErrorMessage = "Lunghezza stringa Dato non idonea, max 15 caratteri")]
        [DisplayName("Dato")]
        public string Dato_ { get; set; }

        [Required(ErrorMessage = "Id sensore installato mancante")]
        [DisplayName("Id Sensori Installati")]
        public int IdSensoriInstallati_ { get; set; }

        public Rilevamenti(int idR, DateTime d, string dato, int idSI)
        {
            IdRilevamenti_ = idR;
            DataOra_ = d;
            Dato_ = dato;
            IdSensoriInstallati_ = idSI;
        }
        public Rilevamenti()
        {
            
        }
    }
}
