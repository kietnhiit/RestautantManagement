using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace DAL
{

    public class TableDAL
    {
        RestaurantDB db;
        public TableDAL()
        {
            db = new RestaurantDB();
        }

        public Table GetTableById(int id)
        {
            try
            {
                Table table = db.Tables.Find(id);
                return table;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Table> GetAllTable()
        {
            try
            {
                List<Table> list = db.Tables.ToList();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateTable(Table table)
        {
            try
            {
                db.Entry(table).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddTable(Table table)
        {
            try
            {
                db = new DAL.RestaurantDB();
                db.Tables.Add(table);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteTable(int id)
        {
            try
            {
                Table odd = db.Tables.Find(id);
                if (id > -1)
                {
                    db.Tables.Remove(odd);
                    db.SaveChanges();
                    return true;
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
