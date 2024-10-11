using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmptyBlazorAppMeteo_001.Class.Tables
{
    public class Stazioni : ITables
    {
        [Key]
        [Required(ErrorMessage ="Nome stazione mancante.")]
        [StringLength(10, ErrorMessage = "Lunghezza stringa Nome stazione non idonea, max 10 caratteri")]
        [DisplayName("Nome Stazione")]
        public string IdNomeStazione_ { get; set; }

        [StringLength(10, ErrorMessage = "Lunghezza stringa Ip stazione non idonea, max 39 caratteri")]
        [DisplayName("Ip Statico")]
        public string Ip_Statico_ { get; set; }

        [StringLength(50, ErrorMessage = "Lunghezza stringa Località indirizzo non idonea, max 50 caratteri.")]
        [DisplayName("Località Indirizzo")]
        public string LocalitaIndirizzo_ { get; set; }

        [DisplayName("Latitudine")]
        public string Latitudine_ { get; set; }

        [DisplayName("Longitudine")]
        public string Longitudine_ { get; set; }

        [DisplayName("Altitudine")]
        public string Altitudine_ { get; set; }

        [StringLength(50, ErrorMessage = "Lunghezza stringa Descrizione non idonea, max 50 caratteri.")]
        [DisplayName("Descrizione")]
        public string Descrizione_ { get; set; }

        [StringLength(50, ErrorMessage = "Lunghezza stringa Note non idonea, max 50 caratteri.")]
        [DisplayName("Note")]
        public string Note_ { get; set; }

        public Stazioni(string id, string ip, string l, string lat, string lon, string alt, string desc, string note)
        {
            IdNomeStazione_ = id;
            Ip_Statico_ = ip;
            LocalitaIndirizzo_ = l;
            Longitudine_ = lon;
            Altitudine_ = alt;
            Descrizione_ = desc;
            Note_ = note;
        }

        public Stazioni()
        {
            
        }
    }
}
