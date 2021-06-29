using BusinessObject;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
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
        private List<MemberObject> MemberList = new List<MemberObject>()
        {
            new MemberObject{MemberID = 1, MemberName = "Joe Barbaro", Email = "joeb@fstore.com", Password = "12345678", City = "New York City", Country = "USA"},
            new MemberObject{MemberID = 2, MemberName = "Ezio Auditore", Email = "ezioa@fstore.com", Password = "12345678", City = "Florence", Country = "Italy"},
            new MemberObject{MemberID = 3, MemberName = "Wei Shen", Email = "weis@fstore.com", Password = "12345678", City = "Hong Kong", Country = "China"},
            new MemberObject{MemberID = 4, MemberName = "Joe Johnson", Email = "carlj@fstore.com", Password = "12345678", City = "Los Angeles", Country = "USA"},
            new MemberObject{MemberID = 5, MemberName = "Vito Scaletta", Email = "vitos@fstore.com", Password = "12345678", City = "Venice", Country = "Italy"},
            new MemberObject{MemberID = 6, MemberName = "Tommy Vercetti", Email = "tommyv@fstore.com", Password = "12345678", City = "Miami", Country = "USA"},
            new MemberObject{MemberID = 7, MemberName = "XuanDe Liu", Email = "xuande@fstore.com", Password = "12345678", City = "Cheng Du", Country = "China"},
            new MemberObject{MemberID = 8, MemberName = "Joshua Braybrooke", Email = "joshuab@fstore.com", Password = "12345678", City = "London", Country = "UK"},
            new MemberObject{MemberID = 9, MemberName = "Chi Cuong Tang", Email = "chicuong@fstore.com", Password = "12345678", City = "Ho Chi Minh City", Country = "Vietnam"},
            new MemberObject{MemberID = 10, MemberName = "Camille Aubert", Email = "camillea@fstore.com", Password = "12345678", City = "Lyon", Country = "France"},
            new MemberObject{MemberID = 11, MemberName = "Sanada Yukimura", Email = "yukimuras@fstore.com", Password = "12345678", City = "Osaka", Country = "Japan"},
            new MemberObject{MemberID = 12, MemberName = "Ollie Kendall", Email = "olliek@fstore.com", Password = "12345678", City = "London", Country = "UK"},
            new MemberObject{MemberID = 13, MemberName = "Minh Hai Ho", Email = "minhhai@fstore.com", Password = "12345678", City = "Ho Chi Minh City", Country = "Vietnam"},
            new MemberObject{MemberID = 14, MemberName = "Jean Beaufort", Email = "jeanb@fstore.com", Password = "12345678", City = "Paris", Country = "France"},
            new MemberObject{MemberID = 15, MemberName = "Ka Keung Wong", Email = "kakeung@fstore.com", Password = "12345678", City = "Hong Kong", Country = "China"}

        };

        //Using Singleton pattern
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public List<MemberObject> GetMemberList => MemberList;
        public MemberObject GetMemberByID(int id)
        {
            MemberObject member = MemberList.SingleOrDefault(mem => mem.MemberID == id);
            return member;
        }
        public void AddMember(MemberObject newMember)
        {
            MemberObject mem = GetMemberByID(newMember.MemberID);
            if(mem == null)
            {
                MemberList.Add(newMember);
            }
            else
            {
                throw new Exception("Member ID already exists!");
            }
        }
        public void UpdateMember(MemberObject modifiedMember)
        {
            MemberObject mem = GetMemberByID(modifiedMember.MemberID);
            if(mem != null)
            {
                int index = MemberList.IndexOf(mem);
                MemberList[index] = modifiedMember;
            }
            else
            {
                throw new Exception("Member not found!");
            }
        }
        public void DeleteMember(int memberID)
        {
            MemberObject mem = GetMemberByID(memberID);
            if(mem != null)
            {
                MemberList.Remove(mem);
            }
            else
            {
                throw new Exception("Member not found!");
            }
        }
        public List<MemberObject> GetMembersByCity(string city)
        {
            return MemberList.FindAll(mem => mem.City.ToLower().Contains(city.ToLower()));
        }

        public List<MemberObject> GetMembersByCountry(string country)
        {
            //return MemberList.FindAll(mem => mem.Country.ToLower().Contains(country.ToLower()));
            return MemberList.Where(mem => mem.Country.ToLower().Contains(country.ToLower())).ToList();
        }

        public MemberObject CheckLogin(string email, string password)
        {
            using StreamReader sr = new StreamReader("appsettings.json");
            var details = JObject.Parse(sr.ReadToEnd());
            string AdminEmail = (string)details["admin"]["email"];
            string AdminPassword = (string)details["admin"]["password"];

            if (email.Equals(AdminEmail) && password.Equals(AdminPassword))
                {
                    MemberObject admin = new MemberObject();
                    admin.Email = AdminEmail;
                    admin.Password = AdminPassword;
                    return admin;
                }
                else
                {
                    MemberObject mem = MemberList.SingleOrDefault(mem => mem.Email.Equals(email) && mem.Password.Equals(password));
                    if (mem != null)
                    {
                        return mem;
                    }
                }
            return null;
        }

        public List<MemberObject> GetMembersByName(string name)
        {
            return MemberList.FindAll(mem => mem.MemberName.ToLower().Contains(name.ToLower()));
        }

        public List<string> GetCountries()
        {
            return MemberList.Select(mem => mem.Country).Distinct().ToList();
        }

        public List<string> GetCitiesByCountry(string country)
        {
            return MemberList.Where(mem => mem.Country.Equals(country))
                .Select(mem => mem.City)
                .Distinct()
                .ToList();
        }
        public void SortList(int sortType)
        {
            if (sortType == 0)
            {
                MemberList.Sort((x, y) => x.MemberName.CompareTo(y.MemberName));
            }
            else
            {
                MemberList.Sort((x, y) => y.MemberName.CompareTo(x.MemberName));
            }
        }
    }
}
