using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemberByID(int memberID);
        IEnumerable<MemberObject> GetMembersByName(string memberName);
        IEnumerable<MemberObject> FilterMembersByCountry(string country);
        IEnumerable<MemberObject> FilterMembersByCity(string city);
        MemberObject CheckLogin(string email, string password);
        void InsertMember(MemberObject member);
        void DeleteMember(int memberID);
        void UpdateMember(MemberObject member);
        IEnumerable<string> GetCountries();
        IEnumerable<string> GetCities(string country);
        void Sort(int sortType);
    }
}
