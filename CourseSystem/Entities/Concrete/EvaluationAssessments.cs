using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class EvaluationAssessment:IEntity
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int AssessmentId { get; set; }
        public double EffectRation { get; set; }
    }
}
