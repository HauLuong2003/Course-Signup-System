namespace Course_Signup_System.Application.DTO.Reponse
{
    public class PageResult<T>
    {
        public int TotalRecoreds { get; set; } // Tổng số bản ghi
        public int Page { get; set; } // trang hien tai
        public int PageSize { get; set; } // so luong tren moi bang ghi
        public int TotalPages { get; set; }  //  tong so trang
        public List<T> Data { get; set; } = new List<T>();
    }
}
