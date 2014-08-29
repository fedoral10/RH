using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RH
{
    class clsRepo
    {
        #region Genericos
        public void Insertar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHhelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e) { 
                Console.WriteLine("Error: "+e.Message);
            }
        }
        public void Eliminar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHhelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void Actualizar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHhelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        #endregion
    }
}
