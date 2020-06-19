using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserForRegisterDto:IDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public List<Branch> Branchs { get; set; }
        public string BirthDay { get; set; }
        public int Gender { get; set; }
        public int RoleId { get; set; }
        public int InstitutionId { get; set; }
        public int CountryId { get; set; }
    
 
        public string ImageName { get; set; }
        public string SSNPassport { get; set; }
    }
}
