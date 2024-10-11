using EmptyBlazorAppMeteo_001.Class;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace EmptyBlazorAppMeteo_001.Components
{
    public partial class ExternalLink
    {
        [Parameter]
        public string Path { get; set; }

        public OutLinks<OutLink> Links { get; set; }

        private static OutLinks<OutLink> CodeToJson(string s)
        {
            StreamReader sr = File.OpenText(s);

            JsonSerializer serializer = new JsonSerializer();

            OutLinks<OutLink> obj = (OutLinks<OutLink>)serializer.Deserialize(sr, typeof(OutLinks<OutLink>));

            sr.Close();

            return obj;
        }

        protected override void OnParametersSet()
        {
            Links = CodeToJson(Path) ?? new OutLinks<OutLink>();

            base.OnParametersSet();
        }
    }
}
