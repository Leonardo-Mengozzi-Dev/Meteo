using Microsoft.AspNetCore.Components;

namespace EmptyBlazorAppMeteo_001.Pages.DataPages
{
    public partial class Modifica
    {
        [Parameter]
        public string Id { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            InizializzaTabella(Id);
        }

        private void Submit()
        {
            Db.TableQuery.UpdateTab(Table, Id);

            NavigationManager.NavigateTo("/Dati");
        }
    }
}
