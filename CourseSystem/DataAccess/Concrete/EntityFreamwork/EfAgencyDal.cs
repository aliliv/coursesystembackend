using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFreamwork
{
   public class EfAgencyDal : EfEntityRepositoryBase<Agency, CourseSystemContext>, IAgencyDal
    {
        public ReturnAgencySearchDto GetListTableView(AgencySearchDto agencySearchDto)
        {
            ReturnAgencySearchDto returnAgencySearchDto = new ReturnAgencySearchDto();
            using (var context = new CourseSystemContext())
            {
                var result = (from agency in context.Agencies
                              join country in context.Countries
                              on agency.CountryId equals country.Id
                              where agency.Status == agencySearchDto.Status && (agencySearchDto.SearchObj.CountryId==0 || agency.CountryId==agencySearchDto.SearchObj.CountryId)
                              && (agency.Name.Contains(agencySearchDto.SearchObj.SearchWord) || agency.ContactPerson.Contains(agencySearchDto.SearchObj.SearchWord))
                              select new AgencyTableView
                              {
                                  Id = agency.Id,
                                  Name=agency.Name,
                                  ContactPerson = agency.ContactPerson,
                                  Country=country.Name,
                                  Status=agency.Status,                   
                              }).ToList();
                returnAgencySearchDto.TableView = result.Skip((agencySearchDto.Page - 1) * agencySearchDto.PageSize).Take(agencySearchDto.PageSize).ToList();
                returnAgencySearchDto.TotalCount = result.Count();
                returnAgencySearchDto.MaxPage = Convert.ToInt32(Math.Ceiling((double)returnAgencySearchDto.TotalCount / (double)agencySearchDto.PageSize));
            }
            return returnAgencySearchDto;
        }
    }
}
