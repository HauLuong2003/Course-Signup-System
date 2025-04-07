namespace Course_Signup_System.Domain.Entities
{
    public class GradeColumn
    {
        public int Id { get; set; }
        public double Score { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; } = null!;
    }
}
