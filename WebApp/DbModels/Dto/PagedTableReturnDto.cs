namespace WebApp.DbModels.Dto
{
    public class PagedTableReturnDto<T>
    {

        public List<T> Result { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }

    }
}
