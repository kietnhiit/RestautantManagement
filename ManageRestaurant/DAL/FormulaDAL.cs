using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace DAL
{

    public class FormulaDAL
    {
        RestaurantDB db;
        public FormulaDAL()
        {
            db = new RestaurantDB();
        }

        public Formula GetFormulaById(int id)
        {
            try
            {
                Formula formula = db.Formulas.Where(p => p.ProductParentID == id).First();
                return formula;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Formula GetMaterialById(int productid,int materialid)
        {
            try
            {
                Formula formula = db.Formulas.Where(p => p.ProductParentID == productid && p.ProductID==materialid).First();
                return formula;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Formula> GetAllFormula()
        {
            try
            {
                List<Formula> list = db.Formulas.ToList();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateFormula(Formula formula)
        {
            try
            {
                db.Entry(formula).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddFormula(Formula formula)
        {
            try
            {
                db = new DAL.RestaurantDB();
                db.Formulas.Add(formula);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteMaterial(int productid, int materialid)
        {
            try
            {
                Formula odd = db.Formulas.Where(f=>f.ProductID==materialid && f.ProductParentID==productid).SingleOrDefault();
                if (materialid > -1)
                {
                    db.Formulas.Remove(odd);
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
        public bool DeleteFormula(int id)
        {
            try
            {
                var formula = from F in db.Formulas
                              where F.ProductParentID == id
                              select F; 
                if (id > -1)
                {
                    db.Formulas.RemoveRange(formula);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
