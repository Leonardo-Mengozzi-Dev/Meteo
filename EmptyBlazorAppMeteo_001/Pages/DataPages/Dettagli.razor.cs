using EmptyBlazorAppMeteo_001.Class;
using Microsoft.AspNetCore.Components;

namespace EmptyBlazorAppMeteo_001.Pages.DataPages
{
    public partial class Dettagli
    {

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public DataBase Db { get; set; }
    }
}
