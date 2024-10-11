using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmptyBlazorAppMeteo_001.Class.Tables
{
    public class SensoriInstallati : ITables
    {
        [Key]
        [DisplayName("Id Sensori Installati")]
        public int IdSensoriInstallati_ { get; set; }

        [StringLength(50, ErrorMessage = "Lunghezza stringa Note non idonea, max 50 caratteri")]
        [DisplayName("Note")]
        public string Note_ { get; set; }
        [Required(ErrorMessage ="Id Codice sensore mancante.")]
        [DisplayName("Id Codice Sensore")]
        public int IdCodiceSensore_ { get; set; }

        [Required(ErrorMessage ="Id Nome stazione assente.")]
        [DisplayName("Id Nome Stazione")]
        public string IdNomeStazione_ { get; set; }


        public SensoriInstallati(int id, int idCS, string idNS, string n)
        {
            IdSensoriInstallati_ = id;
            IdCodiceSensore_ = idCS;
            IdNomeStazione_ = idNS;
            Note_ = n;
        }
        public SensoriInstallati()
        {
            
        }
    }
}
