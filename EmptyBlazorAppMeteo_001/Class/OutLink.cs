namespace EmptyBlazorAppMeteo_001.Class
{
    public class OutLink
    {
        public string Name { get; set; }
        public string Link { get; set; }

        /// <summary>
        /// Link a siti esterni
        /// </summary>
        /// <param name="n">Testo visualizzato</param>
        /// <param name="l">link al sito</param>
        public OutLink(string n, string l)
        {
            Name = n;
            Link = l;
        }

        public OutLink()
        {
            
        }
    }
}
