using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrate
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string SSNPassport { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool Status { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int CountryId { get; set; }
        public string Address { get; set; }

        public string ImageName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public int RoleId { get; set; }
        public int InstitutionId { get; set; }
        
       
    }
}
