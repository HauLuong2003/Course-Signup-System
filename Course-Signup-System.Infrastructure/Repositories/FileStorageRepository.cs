using Course_Signup_System.Infrastructure.Data;
using Course_Signup_System.Application.DTO.Reponse;
using Course_Signup_System.Domain.Entities;
using Course_Signup_System.Application.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.IO.IsolatedStorage;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Course_Signup_System.Infrastructure.Repositories
{
    public class FileStorageRepository : IFileStorageService
    {
        private readonly CourseSystemDB _courseSystemDB;
        public FileStorageRepository(CourseSystemDB courseSystemDB)
        {
            _courseSystemDB = courseSystemDB;
        }
        public async Task<string> UploadFile(byte[] fileData, string fileName, string contentType)
        {
            try
            {
                var folderPath = Path.Combine("wwwroot", "Image");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                // Ghi file vào đường dẫn đã chỉ định
                var path = Path.Combine(folderPath, fileName);
                await File.WriteAllBytesAsync(path, fileData);
                var relativePath = Path.Combine("Image", fileName); // Đường dẫn tương đối
                return relativePath;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<byte[]> GeneratePDF(string studentId)
        {
            var student = await _courseSystemDB.Students.Include(st => st.StudentClasses).ThenInclude(st=>st.PayTuitions).ThenInclude(st=>st.TuitionType)
                                                        .Include(st => st.StudentClasses)
                                                        .ThenInclude(st =>st.Class)
                                                        .FirstOrDefaultAsync(st => st.UserId == studentId);
            if (student == null)
            {
                throw new Exception("student is null");
            }
            var document = new PdfDocument();

            string content = "<!DOCTYPE html>";
            content += "<html lang='vi'>";
            content += "<head>";
            content += "    <meta charset='UTF-8'>";
            content += "    <meta name='viewport' content='width=device-width, initial-scale=1.0'>";
            content += "    <title>Biên Lai Thu Tiền</title>";
            content += "    <style>";
            content += "        body { font-family: 'Times New Roman', Times, serif; font-size: 14px; line-height: 1.6; margin: 0; padding: 20px; }";
            content += "        .header, .footer { text-align: center; }";
            content += "        .header h3, .header p { margin: 0; }";
            content += "        .title { text-align: center; text-transform: uppercase; font-size: 18px; margin: 20px 0; }";
            content += "        .details { margin: 20px 0; }";
            content += "        .details p { margin: 5px 0; }";
            content += "        .signature { display: flex; justify-content: space-between; margin-top: 40px; }";
            content += "        .signature div { text-align: center; }";
            content += "    </style>";
            content += "</head>";
            content += "<body>";
            content += "    <div class='header'>";
            content += "        <h3>Đơn vị: NHÀ THIẾU NHI QUẬN 10</h3>";
            content += "        <p>Mã QHNS: 1011365</p>";
            content += "        <div style='text-align: right; margin-top: -20px;'>";
            content += "            <p>Mẫu số: C45-BB</p>";
            content += "            <p>(Ban hành kèm theo TT số 107/2017/TT-BTC)</p>";
            content += "            <p>ngày 10/10/2017 của Bộ Tài chính</p>";
            content += "        </div>";
            content += "    </div>";
            content += "    <div class='title'>";
            content += "        <h2>Biên Lai Thu Tiền</h2>";
            content += $"        <p style='margin: 0;'>Ngày: <strong>{DateTime.Now:dd/MM/yyyy}</strong></p>";
            content += "    </div>";
            content += "    <div class='details'>";
            content += $"        <p><strong>Họ và tên người nộp:</strong> {student.LastName} {student.FirstName}</p>";
            content += "        <p><strong>Địa chỉ:</strong> TP. Hồ Chí Minh</p>";
            content += "        <p><strong>Quyển số:</strong> 202010</p>";
            content += "        <p><strong>Số biên lai:</strong> 52</p>";
            content += $"        <p><strong>- Lớp:</strong> {student.StudentClasses.Select(st => st.Class.ClassName)}</p>";
            content += $"        <p style='margin-left: 20px;'>Học phí: <strong>{student.StudentClasses.Select(st => st.Class.Tuition):N0} VNĐ</strong></p>";
            foreach (var studentClass in student.StudentClasses)
            {

                foreach (var payTuition in studentClass.PayTuitions)
                {
                    content += $"        <p style='margin-left: 20px;'>Ngày thanh toán: <strong>{payTuition.CreateAt:dd/MM/yyyy}</strong></p>";
                    content += $"        <p style='margin-left: 20px;'>Thu: <strong>{payTuition.Tuition:N0} VNĐ</strong> ({payTuition.TuitionType.TuitionName})</p>";
                    content += $"        <p style='margin-left: 20px;'>Giảm giá: <strong>{payTuition.Discount:N0} VNĐ</strong></p>";
                    content += $"        <p style='margin-left: 20px;'>Phụ thu: <strong>{payTuition.Surcharge:N0} VNĐ</strong></p>";
                    content += $"        <p style='margin-left: 20px;'>Số tiền thực thu: <strong>{payTuition.EffectiveChargeRate:N0} VNĐ</strong></p>";
                }
            }
            content +=$"        <p>(Viết bằng chữ): <em>Một triệu ba trăm năm mươi nghìn đồng</em></p>";
            content += "    </div>";
            content += "    <div class='signature' style='font-family: Times New Roman, Arial, sans-serif; display: flex; justify-content: space-between; margin-top: 40px;'>";

            content += "        <div style='text-align: center;'>";
            content += "            <p><strong>Người Nộp Tiền</strong></p>";
            content += "            <p>(Ký, họ tên)</p>";
            content += "        </div>";

            content += "        <div style='text-align: center;'>";
            content += "            <p><strong>Người Thu Tiền</strong></p>";
            content += "            <p>(Ký, họ tên)</p>";
            content += "        </div>";

            content += "    </div>";

            content += "</body>";
            content += "</html>";


            PdfGenerator.AddPdfPages(document, content,PageSize.A4);
            // Chuyển tài liệu PDF thành byte array
            byte[]? fileBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                 document.Save(memoryStream);
                 fileBytes = memoryStream.ToArray();

                // Trả về FileResult dưới dạng PDF
                return fileBytes;
            }
        }

        public async Task<byte[]> GenerateRevenue(DateTime dateTime)
        {
            var revenue = await _courseSystemDB.PayTuitions.Include(p => p.StudentClass).ThenInclude(p=>p.Class)
                                                .Include(p => p.StudentClass).ThenInclude(p=>p.Student)
                                                .Where(p => p.CreateAt.Date == dateTime.Date).ToListAsync();
            if(revenue is null)
            {
                throw new Exception("revenue is null");
            }
            int i = 0;
            var content = "<div style='text-align: center;'>";
            content += "    <h2>BÁO CÁO HỌC PHÍ</h2>";
            content += $"    <p>Ngày:{DateTime.Now:dd/mm,yyyy} </p>";
            content += "</div>";

            content += "<table style='width: 100%; border-collapse: collapse;'>";
            content += "    <tr>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>TT</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Mã học sinh</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Họ tên</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Điện thoại</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Ngày sinh</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Họ tên phụ huynh</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Địa chỉ</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Lớp học đăng ký</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Ngày nhập học</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Giảm giá</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Phí phụ thu</th>";

            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Tổng học phí</th>";
            content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Số học phí đã thu</th>";
            //content += "        <th style='border: 1px solid #ddd; padding: 8px; background-color: #f2f2f2;'>Số học phí chưa thu</th>";
            content += "    </tr>";
            foreach (var item in revenue)
            {
                content += "    <tr>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{i++}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.StudentClass.Student.UserId}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.StudentClass.Student.LastName + " " + item.StudentClass.Student.FirstName}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.StudentClass.Student.PhoneNumber}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.StudentClass.Student.BirthDay}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.StudentClass.Student.Parents}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.StudentClass.Student.Address}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.StudentClass.Class.ClassName}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.StudentClass.CreateAt}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.Discount}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.Surcharge}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.EffectiveChargeRate}</td>";
                content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>{item.EffectiveChargeRate}</td>";
            
            //content += $"        <td style='border: 1px solid #ddd; padding: 8px;'>1.100.000</td>";
            content += "    </tr>";
            }
            content += "</table>";

            content += "<div style='margin-top: 20px;'>";
            content += "    <table style='width: 100%; border-collapse: collapse;'>";
            content += "        <tr>";
            content += "            <td style='background-color: #f9f9f9; font-weight: bold; border: 1px solid #ddd; padding: 8px;' colspan='12'>Tổng cộng</td>";
            content += $"            <td style='background-color: #f9f9f9; font-weight: bold; border: 1px solid #ddd; padding: 8px;'>{revenue.Sum(r => r.EffectiveChargeRate)}</td>";
            //content += "            <td style='background-color: #f9f9f9; font-weight: bold; border: 1px solid #ddd; padding: 8px;'>27.700.000</td>";
            //content += "            <td style='background-color: #f9f9f9; font-weight: bold; border: 1px solid #ddd; padding: 8px;'>30.900.000</td>";
            content += "        </tr>";
            
            content += "    </table>";
           
            content += "</div>";
            var document = new PdfDocument();
            PdfGenerator.AddPdfPages(document, content, PageSize.A0);
            using(MemoryStream memory =  new MemoryStream())
            {
                document.Save(memory);
                byte[] data = memory.ToArray();
                return data;
            }

        }
    }
}
