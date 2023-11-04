namespace Application.Models.General
{
    public class ResponeFromAviationstack<TData>
    {
        public Pagination pagination { get; set; }
        public List<TData> data { get; set; }
    }
    public class Pagination
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public int total { get; set; }
    }

}
