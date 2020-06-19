using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Agency:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int Commission { get; set; }
        public bool Status { get; set; }
    }
}
