using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchTableView
{
    public class AgencyTableView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string ContactPerson { get; set; }
        public bool Status { get; set; }
    }
}
