using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchTableView
{
    public class UserTableView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
    }
}
