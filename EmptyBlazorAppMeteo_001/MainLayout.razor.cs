using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace EmptyBlazorAppMeteo_001
{
    public partial class MainLayout
    {
        [Inject]
        public NavigationManager Nav { get; set; }

        public string PercorsoPaginaCorrente => Regex.Match(Nav.Uri, @"/([^/]+)$").Value;

        private static readonly string path = "./wwwroot/jsons/";

        private Dictionary<string, string> liks = new Dictionary<string, string>
        {
            {"", path + "Index.json"},
            {"/Anemometro", path + "Meteo_Anemometro.json"},
            {"/Banderuola", path + "Meteo_Banderuola.json"},
            {"/Pluviometro", path + "Meteo_Pluviometro.json"},
            {"/Veneziana", path + "Meteo_Veneziana.json"},
            {"/Centralina", path + "Centralina.json"},
            {"/Batteria", path + "Centralina_Batteria.json"} ,
            {"/FiltroAntiRimbalzo", path + "Centralina_FiltroAntiRimbalzo.json"},
            {"/PiCamera", path + "Centralina_PiCamera.json"},
            {"/Raspberry", path + "Centralina_Raspberry.json"},
            {"/StabilizzatoreDiTensione1", path + "Centralina_StabilizzatoriDiTensione.json"},
            {"/StabilizzatoreDiTensione2", path + "Centralina_StabilizzatoriDiTensione.json"},
            {"/Ups", path + "Centralina_Ups.json"},
            {"/Rilevazioni", path + "Rilevazioni.json"},
            {"/ChiSiamo", path + "ChiSiamo.json"}
        };

    }
}
