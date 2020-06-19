using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Concrete.EntityFreamwork;
using DataAccess.Abstract;
using Core.Utilities.Security.Jwt;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinesModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            
            builder.RegisterType<UserBranchManager>().As<IUserBranchService>();
            builder.RegisterType<EfUserBranchDal>().As<IUserBranchDal>();

            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>();

            builder.RegisterType<SessionManager>().As<ISessionService>();
            builder.RegisterType<EfSessionDal>().As<ISessionDal>();

            builder.RegisterType<ClassroomManager>().As<IClassroomService>();
            builder.RegisterType<EFClassroomDal>().As<IClassroomDal>();

            builder.RegisterType<CourseManager>().As<ICourseService>();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>();

            builder.RegisterType<EvaluationManager>().As<IEvaluationService>();
            builder.RegisterType<EfEvaluationDal>().As<IEvaluationDal>();
            
            builder.RegisterType<EvaluationAssessmentManager>().As<IEvaluationAssessmentService>();
            builder.RegisterType<EfEvaluationAssessmentDal>().As<IEvaluationAssessmentDal>();

            builder.RegisterType<AssessmentManager>().As<IAssessmentService>();
            builder.RegisterType<EfAssessmentDal>().As<IAssessmentDal>();

            builder.RegisterType<BranchManager>().As<IBranchService>();
            builder.RegisterType<EfBranchDal>().As<IBranchDal>();

            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();

            builder.RegisterType<AgencyManager>().As<IAgencyService>();
            builder.RegisterType<EfAgencyDal>().As<IAgencyDal>();

            builder.RegisterType<VisatypeManager>().As<IVisatypeService>();
            builder.RegisterType<EfVisatypeDal>().As<IVisatypeDal>();

            builder.RegisterType<StudentManager>().As<IStudentService>();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>();

            builder.RegisterType<CourseFileTypeManager>().As<ICourseFileTypeService>();
            builder.RegisterType<EfCourseFileTypeDal>().As<ICourseFileTypeDal>();
          
            builder.RegisterType<CourseFileManager>().As<ICourseFileService>();
            builder.RegisterType<EfCourseFileDal>().As<ICourseFileDal>();

            builder.RegisterType<AssignmentManager>().As<IAssignmentService>();
            builder.RegisterType<EfAssignmentDal>().As<IAssignmentDal>();

            builder.RegisterType<StudentFilesTypeManager>().As<IStudentFilesTypeService>();
            builder.RegisterType<EfStudentFilesTypeDal>().As<IStudentFilesTypeDal>();

            builder.RegisterType<StudentFileManager>().As<IStudentFileService>();
            builder.RegisterType<EfStudentFileDal>().As<IStudentFileDal>();

            builder.RegisterType<StudentCourseManager>().As<IStudentCourseService>();
            builder.RegisterType<EfStudentCourseDal>().As<IStudentCourseDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        }
    }
}
