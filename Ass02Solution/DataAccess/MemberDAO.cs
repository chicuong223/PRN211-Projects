using BusinessObjects;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object InstanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                }
                return instance;
            }
        }
        public List<Member> GetAll()
        {
            List<Member> lst = new List<Member>();
            try
            {
                using FstoreContext context = new FstoreContext();
                lst = context.Members.ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return lst;
        }

        public void Insert(Member mem)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Members.Add(mem);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Member mem)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Members.Remove(mem);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Member mem)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Entry<Member>(mem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Member GetMemberByID(int memberID)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                Member query = (from mem in context.Members.ToList()
                                where mem.MemberId == memberID
                                select mem).Single();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("Not found!");
            }
        }

        public Member CheckLogin(string email, string password)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                Member admin = context.Admin();
                if (admin.Email.Equals(email) && admin.Password.Equals(password))
                {
                    return admin;
                }
                var query = (from mem in context.Members.ToList()
                             where mem.Email.Equals(email) && mem.Password.Equals(password)
                             select mem).Single();
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
