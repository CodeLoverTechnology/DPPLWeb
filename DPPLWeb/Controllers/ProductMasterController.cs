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
    public class ProductMasterController : Controller
    {
        private DPPL_DbEntities db = new DPPL_DbEntities();

        // GET: ProductMaster
        public async Task<ActionResult> Index()
        {
            var m_ProductMaster = db.M_ProductMaster.Include(m => m.M_CategoryMaster);
            return View(await m_ProductMaster.ToListAsync());
        }

        // GET: ProductMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ProductMaster);
        }

        // GET: ProductMaster/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.M_CategoryMaster, "CategoryID", "CategoryName");
            return View();
        }

        // POST: ProductMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductID,CategoryID,ProductCode,ProductName,ProdDesc,MinQty,TotQty,Rate,SGST,CGST,IGST")] M_ProductMaster m_ProductMaster)
        {
            if (ModelState.IsValid)
            {
                m_ProductMaster.CreatedBy = Session["CurrentUser"].ToString();
                m_ProductMaster.CreatedDate = DateTime.Now;
                m_ProductMaster.ModifiedBY = Session["CurrentUser"].ToString();
                m_ProductMaster.ModifiedDate = DateTime.Now;
                m_ProductMaster.Active = true;

                db.M_ProductMaster.Add(m_ProductMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.M_CategoryMaster, "CategoryID", "CategoryName", m_ProductMaster.CategoryID);
            return View(m_ProductMaster);
        }

        // GET: ProductMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.M_CategoryMaster, "CategoryID", "CategoryName", m_ProductMaster.CategoryID);
            return View(m_ProductMaster);
        }

        // POST: ProductMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,CategoryID,ProductCode,ProductName,ProdDesc,MinQty,TotQty,Rate,SGST,CGST,IGST,CreatedBy,CreatedDate,Active")] M_ProductMaster m_ProductMaster)
        {
            if (ModelState.IsValid)
            {
                m_ProductMaster.ModifiedBY = Session["CurrentUser"].ToString();
                m_ProductMaster.ModifiedDate = DateTime.Now;
                db.Entry(m_ProductMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.M_CategoryMaster, "CategoryID", "CategoryName", m_ProductMaster.CategoryID);
            return View(m_ProductMaster);
        }

        // GET: ProductMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ProductMaster);
        }

        // POST: ProductMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            db.M_ProductMaster.Remove(m_ProductMaster);
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
