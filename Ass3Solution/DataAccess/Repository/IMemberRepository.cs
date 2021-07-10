using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        void AddMember(Member mem);
        void UpdateMember(Member mem);
        void DeleteMember(Member mem);
        Member GetMemberByID(int memberID);
        Member CheckLogin(string email, string password);
    }
}
