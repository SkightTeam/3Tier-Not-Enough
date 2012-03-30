using System;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Skight.Demo.NHRepository
{
    public class SessionProvider
    {
        #region Instance for use outside
        private static SessionProvider instance;
        public static SessionProvider Instance {
            get
            {
                if (instance == null)
                {
                    instance = new SessionProvider();
                }
                return instance;
            }
        }
        #endregion

        #region Set up database
        private const string DBFile = "SkightDemo.db";

        public bool IsBuildScheme { get; set; }

        public void initilize()
        {
           
            session_factory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DBFile).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                .ExposeConfiguration(build_schema)
                .BuildSessionFactory();
        }

        private void build_schema(Configuration configuration)
        {
            if (IsBuildScheme)
            {
                new SchemaExport(configuration)
                    .Execute(true, true, false);
            }
        }

        #endregion
        private readonly object lock_flag = new object();
        private ISessionFactory session_factory;
        public ISessionFactory SessionFactory {
            get {
                if (session_factory == null) {
                    lock (lock_flag) {
                        if (session_factory == null) {
                            initilize();
                        }
                    }
                }
                return session_factory;
            }
        }
        public ISession CreateSession() {

            ISession session = SessionFactory.OpenSession();
            return session;

        }

        public ISession CurrentSession
        {
            get { return SessionFactory.GetCurrentSession(); }
        }

    }
}