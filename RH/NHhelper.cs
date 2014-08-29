using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace RH
{
    class NHhelper
    {
        private static ISessionFactory SessionFactory;

        private static void OpenSession()
        {
            Configuration configuration = new Configuration();
          /*configuration.AddProperties(NHibernate.Connection.ConnectionProvider)*/
            //configuration.AddAssembly(Assembly.GetCallingAssembly());
            configuration.Configure();
            SessionFactory = configuration.BuildSessionFactory();
            /*configuration.AddAssembly(typeof(Domain.Empleado).Assembly);
            configuration.AddAssembly(typeof(Domain.PagoHist).Assembly);
            configuration.AddAssembly(typeof(Domain.SalarioBaseHist).Assembly);
            configuration.AddAssembly(typeof(Domain.Vacacion).Assembly);*/
            
            //NHibernate.Dialect.SQLiteDialect
        }

        public static ISession GetCurrentSession()
        {
            if (SessionFactory == null)
                NHhelper.OpenSession();

            return SessionFactory.OpenSession();
        }

        public static void CloseSessionFactory()
        {
            if (SessionFactory != null)
                SessionFactory.Close();
        }
    }
}
