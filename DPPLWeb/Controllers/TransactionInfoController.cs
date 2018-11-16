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
    public class TransactionInfoController : Controller
    {
        private DPPL_DbEntities db = new DPPL_DbEntities();

        // GET: TransactionInfo
        public async Task<ActionResult> Index()
        {
            var t_TransactionInfo = db.T_TransactionInfo.Include(t => t.M_MasterTable).Include(t => t.M_MasterTable1).Include(t => t.M_ProductMaster).Include(t => t.T_InvoiceInfo);
            return View(await t_TransactionInfo.ToListAsync());
        }

        // GET: TransactionInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TransactionInfo t_TransactionInfo = await db.T_TransactionInfo.FindAsync(id);
            if (t_TransactionInfo == null)
            {
                return HttpNotFound();
            }
            return View(t_TransactionInfo);
        }

        // GET: TransactionInfo/Create
        public ActionResult Create()
        {
            ViewBag.Pack = new SelectList(db.M_MasterTable, "MasterID", "MasterValue");
            ViewBag.TypeOfTransaction = new SelectList(db.M_MasterTable, "MasterID", "MasterValue");
            ViewBag.ProductID = new SelectList(db.M_ProductMaster, "ProductID", "ProductCode");
            ViewBag.InvoiceID = new SelectList(db.T_InvoiceInfo, "InvoiceID", "InvoiceNo");
            return View();
        }

        // POST: TransactionInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TransactionID,ProductID,TypeOfTransaction,InvoiceID,MFR,Batch,Exp,HSN,Pack,Qty,Rate,Dis,Free,IGST,Amount,Remarks")] T_TransactionInfo t_TransactionInfo)
        {
            if (ModelState.IsValid)
            {
                t_TransactionInfo.CreatedBy = Session["CurrentUser"].ToString();
                t_TransactionInfo.CreatedDate = DateTime.Now;
                t_TransactionInfo.ModifiedBy = Session["CurrentUser"].ToString();
                t_TransactionInfo.ModifiedDate = DateTime.Now;
                t_TransactionInfo.Active = true;
                db.T_TransactionInfo.Add(t_TransactionInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Pack = new SelectList(db.M_MasterTable, "MasterID", "MasterValue", t_TransactionInfo.Pack);
            ViewBag.TypeOfTransaction = new SelectList(db.M_MasterTable, "MasterID", "MasterValue", t_TransactionInfo.TypeOfTransaction);
            ViewBag.ProductID = new SelectList(db.M_ProductMaster, "ProductID", "ProductCode", t_TransactionInfo.ProductID);
            ViewBag.InvoiceID = new SelectList(db.T_InvoiceInfo, "InvoiceID", "InvoiceNo", t_TransactionInfo.InvoiceID);
            return View(t_TransactionInfo);
        }

        // GET: TransactionInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TransactionInfo t_TransactionInfo = await db.T_TransactionInfo.FindAsync(id);
            if (t_TransactionInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pack = new SelectList(db.M_MasterTable, "MasterID", "MasterValue", t_TransactionInfo.Pack);
            ViewBag.TypeOfTransaction = new SelectList(db.M_MasterTable, "MasterID", "MasterValue", t_TransactionInfo.TypeOfTransaction);
            ViewBag.ProductID = new SelectList(db.M_ProductMaster, "ProductID", "ProductCode", t_TransactionInfo.ProductID);
            ViewBag.InvoiceID = new SelectList(db.T_InvoiceInfo, "InvoiceID", "InvoiceNo", t_TransactionInfo.InvoiceID);
            return View(t_TransactionInfo);
        }

        // POST: TransactionInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TransactionID,ProductID,TypeOfTransaction,InvoiceID,MFR,Batch,Exp,HSN,Pack,Qty,Rate,Dis,Free,IGST,Amount,Remarks,CreatedBy,CreatedDate,Active")] T_TransactionInfo t_TransactionInfo)
        {
            if (ModelState.IsValid)
            {
                t_TransactionInfo.ModifiedBy = Session["CurrentUser"].ToString();
                t_TransactionInfo.ModifiedDate = DateTime.Now;

                db.Entry(t_TransactionInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Pack = new SelectList(db.M_MasterTable, "MasterID", "MasterValue", t_TransactionInfo.Pack);
            ViewBag.TypeOfTransaction = new SelectList(db.M_MasterTable, "MasterID", "MasterValue", t_TransactionInfo.TypeOfTransaction);
            ViewBag.ProductID = new SelectList(db.M_ProductMaster, "ProductID", "ProductCode", t_TransactionInfo.ProductID);
            ViewBag.InvoiceID = new SelectList(db.T_InvoiceInfo, "InvoiceID", "InvoiceNo", t_TransactionInfo.InvoiceID);
            return View(t_TransactionInfo);
        }

        // GET: TransactionInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TransactionInfo t_TransactionInfo = await db.T_TransactionInfo.FindAsync(id);
            if (t_TransactionInfo == null)
            {
                return HttpNotFound();
            }
            return View(t_TransactionInfo);
        }

        // POST: TransactionInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_TransactionInfo t_TransactionInfo = await db.T_TransactionInfo.FindAsync(id);
            db.T_TransactionInfo.Remove(t_TransactionInfo);
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
