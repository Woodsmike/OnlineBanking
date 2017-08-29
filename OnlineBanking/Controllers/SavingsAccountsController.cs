using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineBanking.Models;

namespace OnlineBanking.Controllers
{
    public class SavingsAccountsController : Controller
    {
        private OnlineBankingContext db = new OnlineBankingContext();

        // GET: SavingsAccounts
        public ActionResult Index()
        {
            var savingsAccounts = db.SavingsAccounts.Include(s => s.Account);
            return View(savingsAccounts.ToList());
        }

        // GET: SavingsAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsAccount savingsAccount = db.SavingsAccounts.Find(id);
            if (savingsAccount == null)
            {
                return HttpNotFound();
            }
            return View(savingsAccount);
        }

        // GET: SavingsAccounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountType");
            return View();
        }

        // POST: SavingsAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SavingsAccountID,SavingsAccountBalance,Deposit,Withdraw,SavingsAccountType,AccountID")] SavingsAccount savingsAccount)
        {
            if (ModelState.IsValid)
            {
                db.SavingsAccounts.Add(savingsAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountType", savingsAccount.AccountID);
            return View(savingsAccount);
        }

        // GET: SavingsAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsAccount savingsAccount = db.SavingsAccounts.Find(id);
            if (savingsAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountType", savingsAccount.AccountID);
            return View(savingsAccount);
        }

        // POST: SavingsAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SavingsAccountID,SavingsAccountBalance,Deposit,Withdraw,SavingsAccountType,AccountID")] SavingsAccount savingsAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savingsAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountType", savingsAccount.AccountID);
            return View(savingsAccount);
        }

        // GET: SavingsAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsAccount savingsAccount = db.SavingsAccounts.Find(id);
            if (savingsAccount == null)
            {
                return HttpNotFound();
            }
            return View(savingsAccount);
        }

        // POST: SavingsAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SavingsAccount savingsAccount = db.SavingsAccounts.Find(id);
            db.SavingsAccounts.Remove(savingsAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
