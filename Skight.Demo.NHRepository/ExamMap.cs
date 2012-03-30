using FluentNHibernate.Mapping;
using Skight.Demo.Domain.Examination;

namespace Skight.Demo.NHRepository
{
    public class ExamMap:ClassMap<Exam>
    {
        public ExamMap()
        {
            Id(x => x.Id);
            Map(x => x.Code);
            Map(x => x.Name);
        }
    }
}