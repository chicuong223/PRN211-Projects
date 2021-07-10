using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member mem)
        {
            MemberDAO.Instance.Insert(mem);
        }

        public Member CheckLogin(string email, string password)
        {
            return MemberDAO.Instance.CheckLogin(email, password);
        }

        public void DeleteMember(Member mem)
        {
            MemberDAO.Instance.Remove(mem);
        }

        public Member GetMemberByID(int memberID)
        {
            return MemberDAO.Instance.GetMemberByID(memberID);
        }

        public IEnumerable<Member> GetMembers()
        {
            return MemberDAO.Instance.GetAll();
        }

        public void UpdateMember(Member mem)
        {
            MemberDAO.Instance.Update(mem);
        }
    }
}
