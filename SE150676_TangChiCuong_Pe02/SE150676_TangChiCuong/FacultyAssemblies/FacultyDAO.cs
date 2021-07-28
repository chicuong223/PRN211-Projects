using System;
using System.Collections.Generic;
using System.Linq;

namespace FacultyAssemblies
{
    public class FacultyDAO
    {
        public List<Faculty> GetAll()
        {
            try
            {
                using var context = new PE02Context();
                List<Faculty> lst = context.Faculties.ToList();
                return lst;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(Faculty faculty)
        {
            try
            {
                using var context = new PE02Context();
                context.Faculties.Add(faculty);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var context = new PE02Context();
                Faculty fa = context.Faculties.Find(id);
                context.Faculties.Remove(fa);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Faculty> Search(string name)
        {
            List<Faculty> lst = new List<Faculty>();
            try
            {
                using var context = new PE02Context();
                //lst = context.Faculties.Where(fa => fa.FullName.ToLower().Contains(name.ToLower())).ToList();
                lst = (from fa in context.Faculties.ToList()
                       where fa.FullName.ToLower().Contains(name.ToLower())
                       select fa).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lst;
        }
    }
}
