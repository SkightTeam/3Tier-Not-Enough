using NHibernate;
using NHibernate.Context;
using NUnit.Framework;
using Skight.Demo.Domain;
using Skight.Demo.Domain.Examination;

namespace Skight.Demo.NHRepository.Tests
{
    [TestFixture]
    public class DataOperation
    {
        private Repository repository;
        private ISession session;
        private ITransaction transaction;
        [SetUp]
        public void SetUp()
        {
            //Dependecy Inject
            repository=new RepositoryImpl();
            session = SessionProvider.Instance.CreateSession();
            transaction = session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }
        [TearDown]
        public void TearDown()
        {
            
            transaction.Commit();
            transaction.Dispose();
            transaction = null;

            session.Close();
            session.Dispose();
        }
        [Test]
        public void create_a_exam()
        {
            var exam = new Exam();
            exam.Code = "001";
            exam.Name = "计算机考试";
            repository.save(exam);
        }

        [Test]
        public void get_the_exam_by_id()
        {
            var exam = repository.get_by_id<Exam>(1);
            Assert.IsNotNull(exam);
        }

        [Test]
        public void delete_the_exam() {
            var exam = repository.get_by_id<Exam>(1);
            repository.delete(exam);
        }
         
    }
}