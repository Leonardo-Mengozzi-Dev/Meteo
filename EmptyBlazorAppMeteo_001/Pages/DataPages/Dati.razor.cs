using EmptyBlazorAppMeteo_001.Class;
using EmptyBlazorAppMeteo_001.Class.Tables;
using Microsoft.AspNetCore.Components;
using Microsoft.SqlServer.Server;

namespace EmptyBlazorAppMeteo_001.Pages.DataPages
{
    public partial class Dati
    {
        [Inject]
        public DataBase Db { get; set; }

        public Rilevamenti _rile = new Rilevamenti();

        public bool IsRilevamenti => Db.TableName == "Rilevamenti";

        private string Url(string azione, string parametro = null)
        {
            var url = $"/Dati/{azione}";
            if (parametro != null)
                url += "/" + parametro;
            return url;
        }
    }
}
