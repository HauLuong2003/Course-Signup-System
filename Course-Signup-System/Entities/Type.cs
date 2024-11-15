using System.ComponentModel;

namespace Course_Signup_System.Entities
{
    public enum Type
    {
        [Description("Nhập theo học sinh")]
        NhapTheoHocSinh = 1,
        [Description("Nhập theo lớp")]
        NhapTheoLop = 2,
    }
}
