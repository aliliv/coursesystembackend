using Core.Entities.Concrate;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFreamwork.Contexts
{   
    public class CourseSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           // optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
            optionsBuilder.UseMySql(connectionString: @"server=localhost;userid=root;password=3453;database=coursesystemdb");

  
        }

       // public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleOperationClaim> RoleOperationClaims { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public  DbSet<Role> Roles { get; set; }
        public DbSet<UserBranch> UserBranchs { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<EvaluationAssessment> EvaluationAssessments { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Visatype> Visatypes { get; set; }
        public DbSet<StudentFile> StudentFiles { get; set; }
        public DbSet<StudentFilesType> StudentFilesTypes { get; set; }
        public DbSet<CourseFileType> CourseFileTypes { get; set; }
        public DbSet<CourseFile> CourseFiles { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

    }
}
