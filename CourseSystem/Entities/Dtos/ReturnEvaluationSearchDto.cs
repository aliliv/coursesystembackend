using Core.Entities;
using Entities.Concrete;
using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ReturnEvaluationSearchDto:IDto
    {
        public List<EvaluationTableView> TableView { get; set; }
        public int TotalCount { get; set; }
        public int MaxPage { get; set; }
    }
}
