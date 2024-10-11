namespace EmptyBlazorAppMeteo_001.Class
{
    public class OutLinks<T>
    {
        public string SummaryName { get; set; }
        public T[] Links { get; set; }

        public OutLinks(string sn, T[] ol)
        {
            SummaryName = sn;
            Links = ol;
        }
        public OutLinks()
        {
            
        }
    }
}
