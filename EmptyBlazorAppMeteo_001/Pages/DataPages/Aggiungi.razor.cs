namespace EmptyBlazorAppMeteo_001.Pages.DataPages
{
    public partial class Aggiungi
    {
        private void Submit()
        {
            Db.TableQuery.AddRow(Table);

            NavigationManager.NavigateTo("/Dati");
        }
    }
}
