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
    public class MasterTableController : Controller
    {
        private DPPL_DbEntities db = new DPPL_DbEntities();

        // GET: MasterTable
        public async Task<ActionResult> Index()
        {
            return View(await db.M_MasterTable.ToListAsync());
        }

        // GET: MasterTable/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTable m_MasterTable = await db.M_MasterTable.FindAsync(id);
            if (m_MasterTable == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTable);
        }

        // GET: MasterTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MasterID,MasterValue,TableName,SequenceNo")] M_MasterTable m_MasterTable)
        {
            if (ModelState.IsValid)
            {
                m_MasterTable.CreatedBy = Session["CurrentUser"].ToString();
                m_MasterTable.CreatedDate = DateTime.Now;
                m_MasterTable.ModifiedBy = Session["CurrentUser"].ToString();
                m_MasterTable.ModifiedDate = DateTime.Now;
                m_MasterTable.Active = true;
                db.M_MasterTable.Add(m_MasterTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_MasterTable);
        }

        // GET: MasterTable/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTable m_MasterTable = await db.M_MasterTable.FindAsync(id);
            if (m_MasterTable == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTable);
        }

        // POST: MasterTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MasterID,MasterValue,TableName,SequenceNo,CreatedBy,CreatedDate,Active")] M_MasterTable m_MasterTable)
        {
            if (ModelState.IsValid)
            {
                m_MasterTable.ModifiedBy = Session["CurrentUser"].ToString();
                m_MasterTable.ModifiedDate = DateTime.Now;
                db.Entry(m_MasterTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_MasterTable);
        }

        // GET: MasterTable/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTable m_MasterTable = await db.M_MasterTable.FindAsync(id);
            if (m_MasterTable == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTable);
        }

        // POST: MasterTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_MasterTable m_MasterTable = await db.M_MasterTable.FindAsync(id);
            db.M_MasterTable.Remove(m_MasterTable);
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
