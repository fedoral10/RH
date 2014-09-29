using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

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
            string archivo =AppDomain.CurrentDomain.BaseDirectory + "\\RH.db3";
            
            configuration.SetProperty("connection.connection_string", "Data Source=" +archivo+";Version=3;compress=true");
            SessionFactory = configuration.BuildSessionFactory();
            ExportarEsquema(configuration);

            /*configuration.AddAssembly(typeof(Domain.Empleado).Assembly);
            configuration.AddAssembly(typeof(Domain.PagoHist).Assembly);
            configuration.AddAssembly(typeof(Domain.SalarioBaseHist).Assembly);
            configuration.AddAssembly(typeof(Domain.Vacacion).Assembly);*/
            
            //NHibernate.Dialect.SQLiteDialect
        }

        private static void ExportarEsquema(Configuration cfg)
        {
            var lol = new SchemaUpdate(cfg);
            lol.Execute(false, true);
            
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
