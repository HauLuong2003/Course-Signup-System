namespace Course_Signup_System.Entities
{
    public class StudentClass
    {
        public string UserId { get; set; }
        public Student Student { get; set; }

        public string ClassId { get; set; }
        public Class Class { get; set; }
    }
}
