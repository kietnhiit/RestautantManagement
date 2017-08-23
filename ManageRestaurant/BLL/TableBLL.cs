using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class TableBLL
    {
        TableBLL rsdal;

        public TableBLL GetTableById(int id)
        {
            if (id!= 0)
            {
                return rsdal.GetTableById(id);
            }
            return null;
        }

        public List<DAL.Table> GetAllTable()
        {
            try
            {
                return rsdal.GetAllTable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddTable(DAL.Table table)
        {
            try
            {
                if (table != null)
                {
                    return rsdal.AddTable(table);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateTable(DAL.Table table)
        {
            try
            {
                if (table != null)
                {
                    return rsdal.UpdateTable(table);
                }
                return false;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public TableBLL()
        {
            rsdal = new TableBLL();
        }
        public bool DeleteTable(int id)
        {
            try
            {
                if (id != 0)
                {
                    return rsdal.DeleteTable(id);
                }
                return false;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
