using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos.SearchTableView;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfEvaluationDal : EfEntityRepositoryBase<Evaluation, CourseSystemContext>, IEvaluationDal
    {
        public ReturnEvaluationSearchDto GetListTableView(EvaluationSearchDto evaluationSearchDto)
        {
            ReturnEvaluationSearchDto returnEvaluationSearchDto = new ReturnEvaluationSearchDto();
            using (var context = new CourseSystemContext())
            {
                var result = (from evaluation in context.Evaluations
                              join userbranch in context.UserBranchs
                              on evaluation.BranchId equals userbranch.BranchId
                              join branch in context.Branchs
                              on evaluation.BranchId equals branch.Id
                              where evaluation.Status == evaluationSearchDto.Status && userbranch.UserId == evaluationSearchDto.UserId
                              && (evaluation.Name.Contains(evaluationSearchDto.SearchObj.SearchWord) || evaluation.Description.Contains(evaluationSearchDto.SearchObj.SearchWord))
                              select new EvaluationTableView
                              {
                                  Id = evaluation.Id,
                                  Name = evaluation.Name,
                                  Status = evaluation.Status,
                                  Branch = branch.Name,
                                  Description = evaluation.Description,
                                  PassingGrade = evaluation.PassingGrade

                              }).ToList();
                returnEvaluationSearchDto.TableView = result.Skip((evaluationSearchDto.Page - 1) * evaluationSearchDto.PageSize).Take(evaluationSearchDto.PageSize).ToList();
                returnEvaluationSearchDto.TotalCount = result.Count();
                returnEvaluationSearchDto.MaxPage = Convert.ToInt32(Math.Ceiling((double)returnEvaluationSearchDto.TotalCount / (double)evaluationSearchDto.PageSize));
            }
            return returnEvaluationSearchDto;
        }
    }
}

