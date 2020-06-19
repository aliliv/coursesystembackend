using Core.Entities;
using Entities.Concrete;
using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ReturnSessionSearchDto:IDto
    {
        public List<SessionTableView> TableView { get; set; }
        public int TotalCount { get; set; }
        public int MaxPage { get; set; }
    }
}
