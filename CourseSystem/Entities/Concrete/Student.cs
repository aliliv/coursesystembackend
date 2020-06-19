using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Student:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StudentId { get; set; }
        public int VisaType { get; set; }
        public string SevisNo { get; set; }
        public string PlacementScore { get; set; }
       // public int GroupId { get; set; }
        public DateTime StartDate { get; set; }
        public string Note { get; set; }
        public int AgencyId { get; set; }
    }
}
