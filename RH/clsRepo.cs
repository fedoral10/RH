using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public IList<TClase> Seleccionar<TClase>() where TClase : class
        {
            using (ISession session = NHhelper.GetCurrentSession())
            {
                return session.CreateCriteria<TClase>().List<TClase>();
            }
        }

        #endregion
        #region EMPLEADO
        
        #endregion
    }
    static class clsRepoConvertidor
    {
        public static DataTable Seleccionar_Datatable<TClase>() where TClase : class
        {
            clsRepo repo = new clsRepo();
            return ToDataTable<TClase>(repo.Seleccionar<TClase>());
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static DataTable ToDataTable<T>(this List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
