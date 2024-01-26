// Data/SeedData.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Students.Data;
using Students.Models;
using System;
using System.IO;
using System.Linq;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new StudentsContext(serviceProvider.GetRequiredService<DbContextOptions<StudentsContext>>()))
        {
            // Kiểm tra xem đã có dữ liệu trong cơ sở dữ liệu chưa
            if (context.Student.Any())
            {
                return; // Dữ liệu đã được thêm vào
            }

            // Thêm dữ liệu mẫu
            context.Student.AddRange(
                new Student
                {
                    Group = "A",
                    Rollnumber = "A001",
                    FullName = "Nguyen Van A",
                    Absent = false,
                    Comment = "Good student",
                    Thumbnail = "images/student1.jpg" // Thay thế bằng đường dẫn thực tế của hình ảnh nhỏ
                },
                new Student
                {
                    Group = "B",
                    Rollnumber = "B001",
                    FullName = "Tran Thi B",
                    Absent = true,
                    Comment = "Absent last week",
                    Thumbnail = "images/student2.jpg" // Thay thế bằng đường dẫn thực tế của hình ảnh nhỏ
                }
                // Thêm các bản ghi khác nếu cần
            );

            context.SaveChanges();
        }
    }
}
