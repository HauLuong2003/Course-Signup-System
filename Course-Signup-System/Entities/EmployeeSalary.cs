namespace Course_Signup_System.Entities
{
    public class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }

        public double Salary { get; set; }

        public double AllowanceName { get; set; }

        public double Allowance { get; set; }

        public double SalaryReal { get; set; }


        public bool IsClose { get; set; } = false;

        public string? Note { get; set; }

        public string UserId { get; set; } = null!;
        public Teacher Teacher { get; set; }= null!;
    }
}
