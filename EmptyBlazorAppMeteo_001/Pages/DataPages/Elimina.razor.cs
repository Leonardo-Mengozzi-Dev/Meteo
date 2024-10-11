using Microsoft.AspNetCore.Components;

namespace EmptyBlazorAppMeteo_001.Pages.DataPages
{
    public partial class Elimina
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
            Db.TableQuery.DeleteTab(Id);

            NavigationManager.NavigateTo("/Dati");
        }
    }
}
