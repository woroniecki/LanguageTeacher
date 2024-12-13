using LanguageTeacher.Domain.Aggregates.Courses;
using Microsoft.EntityFrameworkCore;

namespace LanguageTeacher.Domain;
public class LanguageTeacherDbContext : DbContext
{
    // public LanguageTeacherDbContext() { }

    public LanguageTeacherDbContext(DbContextOptions<LanguageTeacherDbContext> options)
    : base(options) { }

    public DbSet<Course> Courses { get; set; }
}
