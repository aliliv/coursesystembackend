using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string CourseName { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int DaysInWeek { get; set; }
        public string Goal { get; set; }
        public string Objectives { get; set; }
        public string Topic { get; set; }
        public string Vocabulary { get; set; }
        public string Grammar { get; set; }
        public string Writing { get; set; }
        public string Speaking { get; set; }
        public string EndOfModuleWriting { get; set; }
        public string EndOfModuleSpeaking { get; set; }
        public string ProgressQuizzes { get; set; }
        public string EndOfModuleExamReading { get; set; }
        public string EndOfModuleExamUOE { get; set; }
        public string EndOfModuleExamVocabulary  { get; set; }
        public string EndOfModuleExamListening { get; set; }





    }
}
