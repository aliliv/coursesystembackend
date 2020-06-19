using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }
        public IDataResult<List<Country>> GetList()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetList().ToList());
        }
    }

}
