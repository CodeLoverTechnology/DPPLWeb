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
    public class InvoiceInfoController : Controller
    {
        private DPPL_DbEntities db = new DPPL_DbEntities();

        // GET: InvoiceInfo
        public async Task<ActionResult> Index()
        {
            var t_InvoiceInfo = db.T_InvoiceInfo.Include(t => t.M_PartyMaster);
            return View(await t_InvoiceInfo.ToListAsync());
        }

        // GET: InvoiceInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_InvoiceInfo t_InvoiceInfo = await db.T_InvoiceInfo.FindAsync(id);
            if (t_InvoiceInfo == null)
            {
                return HttpNotFound();
            }
            return View(t_InvoiceInfo);
        }

        // GET: InvoiceInfo/Create
        public ActionResult Create()
        {
            ViewBag.PartyID = new SelectList(db.M_PartyMaster, "PartyID", "PartyName");
            return View();
        }

        // POST: InvoiceInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InvoiceID,InvoiceNo,InvoiceDate,PartyID,Delivery_Location,LR_No,Cases,Transport,DueDate,SubTotal,Dis_Percent,IGST,FREIGHT,RoundOff,CR_DR_Note,GrandTotal,GrandTotal_InWord")] T_InvoiceInfo t_InvoiceInfo)
        {
            if (ModelState.IsValid)
            {
                t_InvoiceInfo.CreatedBy = Session["CurrentUser"].ToString();
                t_InvoiceInfo.CreatedDate = DateTime.Now;
                t_InvoiceInfo.ModifiedBy = Session["CurrentUser"].ToString();
                t_InvoiceInfo.ModifiedDate = DateTime.Now;
                t_InvoiceInfo.Active = true;

                db.T_InvoiceInfo.Add(t_InvoiceInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PartyID = new SelectList(db.M_PartyMaster, "PartyID", "PartyName", t_InvoiceInfo.PartyID);
            return View(t_InvoiceInfo);
        }

        // GET: InvoiceInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_InvoiceInfo t_InvoiceInfo = await db.T_InvoiceInfo.FindAsync(id);
            if (t_InvoiceInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartyID = new SelectList(db.M_PartyMaster, "PartyID", "PartyName", t_InvoiceInfo.PartyID);
            return View(t_InvoiceInfo);
        }

        // POST: InvoiceInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InvoiceID,InvoiceNo,InvoiceDate,PartyID,Delivery_Location,LR_No,Cases,Transport,DueDate,SubTotal,Dis_Percent,IGST,FREIGHT,RoundOff,CR_DR_Note,GrandTotal,GrandTotal_InWord,CreatedBy,CreatedDate,Active")] T_InvoiceInfo t_InvoiceInfo)
        {
            if (ModelState.IsValid)
            {
                t_InvoiceInfo.ModifiedBy = Session["CurrentUser"].ToString();
                t_InvoiceInfo.ModifiedDate = DateTime.Now;

                db.Entry(t_InvoiceInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PartyID = new SelectList(db.M_PartyMaster, "PartyID", "PartyName", t_InvoiceInfo.PartyID);
            return View(t_InvoiceInfo);
        }

        // GET: InvoiceInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_InvoiceInfo t_InvoiceInfo = await db.T_InvoiceInfo.FindAsync(id);
            if (t_InvoiceInfo == null)
            {
                return HttpNotFound();
            }
            return View(t_InvoiceInfo);
        }

        // POST: InvoiceInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_InvoiceInfo t_InvoiceInfo = await db.T_InvoiceInfo.FindAsync(id);
            db.T_InvoiceInfo.Remove(t_InvoiceInfo);
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
