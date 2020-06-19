using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class StudentCourseManager: IStudentCourseService
    {
        private IStudentCourseDal _studentCourseDal;
        public StudentCourseManager(IStudentCourseDal studentCourseDal)
        {
            _studentCourseDal = studentCourseDal;
        }

        public IResult Add(StudentCourse studentCourse)
        {
            _studentCourseDal.Add(studentCourse);
            return new SuccessResult(Messages.StudentCorseRegisted);
        }
    }
}
