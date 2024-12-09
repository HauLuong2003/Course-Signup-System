namespace Course_Signup_System.DTO
{
    public class PaytuitionDTO
    {
        public int PayTuitionId { get; set; }

        public string? Name { get; set; }

        public string? ClassName { get; set; }

        public double Tuition { get; set; } // học phí

        public double Discount { get; set; }// giảm giá

        public double Surcharge { set; get; }// phí phụ thu

        public double EffectiveChargeRate => (Tuition - (Tuition * Discount) / 100) + Surcharge;

        public string? Note { get; set; } = null!;

        public int TuitionTypeId { get; set; }

        public int StudentClassId { get; set; }

    }
}
