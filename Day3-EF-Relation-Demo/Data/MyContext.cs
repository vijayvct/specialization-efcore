using System;
using Microsoft.EntityFrameworkCore;
using Day3_EF_Relation_Demo.Model;

namespace Day3_EF_Relation_Demo.Data;

public class MyContext:DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
    public DbSet<Department> Departments{get;set;}

    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("data source=CTAADPG02MWBG;initial catalog=EFRelationDemo;user id=sa;password=Password_123");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        //Setting up Primary key 
        //modelBuilder.Entity<Publisher>().HasKey(p=>p.PubId);

        //One to One 
        // modelBuilder.Entity<Employee>()
        //             .HasOne<EmployeeAddress>(p=>p.EmployeeAddress)
        //             .WithOne(e=>e.Employee)
        //             .HasForeignKey<EmployeeAddress>(s=>s.EmployeeId);

        // //One to Many 
        // modelBuilder.Entity<Book>()
        //             .HasOne<Publisher>(p=>p.Publisher)
        //             .WithMany(b=>b.Books)
        //             .HasForeignKey(d=>d.PubId);

        //Many to Many 
        //Creating a Composite Key
        modelBuilder.Entity<StudentCourse>()
                    .HasKey(s=>new {s.StudentId,s.CourseId});

        modelBuilder.Entity<StudentCourse>()
                    .HasOne<Student>(s=>s.Student)
                    .WithMany(c=>c.StudentCourses)
                    .HasForeignKey(sc=>sc.StudentId);

        modelBuilder.Entity<StudentCourse>()
                    .HasOne<Course>(c=>c.Course)
                    .WithMany(s=>s.StudentCourses)
                    .HasForeignKey(sc=>sc.CourseId);
    }
}