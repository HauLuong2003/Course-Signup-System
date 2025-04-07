namespace Course_Signup_System.Application.DTO.Reponse
{
    public class PageResult<T>
    {
        public int TotalRecoreds { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; } = new List<T>();
    }
}
