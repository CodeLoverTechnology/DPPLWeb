using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DPPLWeb.DBModel;

namespace DPPLWeb.Controllers
{
    public class PartyMasterController : Controller
    {
        private DPPL_DbEntities db = new DPPL_DbEntities();

        // GET: PartyMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_PartyMaster.ToListAsync());
        }

        // GET: PartyMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PartyMaster m_PartyMaster = await db.M_PartyMaster.FindAsync(id);
            if (m_PartyMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_PartyMaster);
        }

        // GET: PartyMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartyMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PartyID,PartyName,Address,PinCode,PhoneNo,EmailID,Remarks")] M_PartyMaster m_PartyMaster)
        {
            if (ModelState.IsValid)
            {
                m_PartyMaster.CreatedBy = Session["CurrentUser"].ToString();
                m_PartyMaster.CreatedDate = DateTime.Now;
                m_PartyMaster.ModifiedBy = Session["CurrentUser"].ToString();
                m_PartyMaster.ModifiedDate = DateTime.Now;
                m_PartyMaster.Active = true;
                db.M_PartyMaster.Add(m_PartyMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_PartyMaster);
        }

        // GET: PartyMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PartyMaster m_PartyMaster = await db.M_PartyMaster.FindAsync(id);
            if (m_PartyMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_PartyMaster);
        }

        // POST: PartyMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PartyID,PartyName,Address,PinCode,PhoneNo,EmailID,Remarks,CreatedBy,CreatedDate,Active")] M_PartyMaster m_PartyMaster)
        {
            if (ModelState.IsValid)
            {
                m_PartyMaster.ModifiedBy = Session["CurrentUser"].ToString();
                m_PartyMaster.ModifiedDate = DateTime.Now;

                db.Entry(m_PartyMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_PartyMaster);
        }

        // GET: PartyMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_PartyMaster m_PartyMaster = await db.M_PartyMaster.FindAsync(id);
            if (m_PartyMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_PartyMaster);
        }

        // POST: PartyMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_PartyMaster m_PartyMaster = await db.M_PartyMaster.FindAsync(id);
            db.M_PartyMaster.Remove(m_PartyMaster);
            await db.SaveChangesAsync();
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
