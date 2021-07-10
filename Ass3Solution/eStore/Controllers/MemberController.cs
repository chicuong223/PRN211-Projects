using BusinessObjects;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class MemberController : Controller
    {
        private MemberRepository memberRepository = null;
        public MemberController() => memberRepository = new MemberRepository();

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            int loggedIn = CheckLogin();
            if (loggedIn == -1)
                return RedirectToAction("Login", "Home");
            if (loggedIn == 0)
            {
                ViewBag.Error = "You don't have access to this action";
                return View();
            }
            try
            {
                Member member = memberRepository.GetMemberByID(id);
                return View(member);
            }
            catch
            {
                ViewData["error"] = "Member Not Found";
                return View("Error");
            }
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            int loggedIn = CheckLogin();
            if (loggedIn == -1)
                return RedirectToAction("Login", "Home");
            if (loggedIn == 0)
            {
                ViewBag.Error = "You don't have access to this action";
                return View();
            }
            int memberID = memberRepository.GetMembers().Max(m => m.MemberId) + 1;
            ViewData["id"] = memberID;
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberRepository.AddMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(member);
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            int loggedIn = CheckLogin();
            if (loggedIn == -1)
                return RedirectToAction("Login", "Home");
            Member member = memberRepository.GetMemberByID(id);
            return View(member);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            try
            {
                if (id != member.MemberId)
                    return NotFound();
                if (ModelState.IsValid)
                {
                    memberRepository.UpdateMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(member);
            }
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Member member = memberRepository.GetMemberByID(id);
                if (member == null)
                    return NotFound();
                memberRepository.DeleteMember(member);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "Error deleting Member";
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Index()
        {
            IEnumerable<Member> memList = memberRepository.GetMembers();
            return View(memList);
        }

        public int CheckLogin()
        {
            var session = HttpContext.Session.GetInt32("user");
            if (session == null)
                return -1;
            if (session != 0)
                return 0;
            return 1;
        }
    }
}
