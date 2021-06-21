using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public MemberObject CheckLogin(string email, string password)
        {
            return MemberDAO.Instance.CheckLogin(email, password);
        }

        public void DeleteMember(int memberID)
        {
            MemberDAO.Instance.DeleteMember(memberID);
        }

        public IEnumerable<MemberObject> FilterMembersByCity(string city)
        {
            return MemberDAO.Instance.GetMembersByCity(city);
        }

        public IEnumerable<MemberObject> FilterMembersByCountry(string country)
        {
            return MemberDAO.Instance.GetMembersByCountry(country);
        }

        public IEnumerable<string> GetCities(string country)
        {
            return MemberDAO.Instance.GetCitiesByCountry(country);
        }

        public IEnumerable<string> GetCountries()
        {
            return MemberDAO.Instance.GetCountries();
        }

        public MemberObject GetMemberByID(int memberID)
        {
            return MemberDAO.Instance.GetMemberByID(memberID);
        }

        public IEnumerable<MemberObject> GetMembers()
        {
            return MemberDAO.Instance.GetMemberList;
        }

        public IEnumerable<MemberObject> GetMembersByName(string memberName)
        {
            return MemberDAO.Instance.GetMembersByName(memberName);
        }

        public void InsertMember(MemberObject member)
        {
            MemberDAO.Instance.AddMember(member);
        }

        public void Sort(int sortType)
        {
            MemberDAO.Instance.SortList(sortType);
        }

        public void UpdateMember(MemberObject member)
        {
            MemberDAO.Instance.UpdateMember(member);
        }

    }
}
