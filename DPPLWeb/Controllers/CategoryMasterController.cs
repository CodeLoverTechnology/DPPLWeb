﻿using System;
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
    public class CategoryMasterController : Controller
    {
        private DPPL_DbEntities db = new DPPL_DbEntities();

        // GET: CategoryMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_CategoryMaster.ToListAsync());
        }

        // GET: CategoryMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_CategoryMaster m_CategoryMaster = await db.M_CategoryMaster.FindAsync(id);
            if (m_CategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_CategoryMaster);
        }

        // GET: CategoryMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategoryID,CategoryName,Description")] M_CategoryMaster m_CategoryMaster)
        {
            if (ModelState.IsValid)
            {
                m_CategoryMaster.CreatedBy = Session["CurrentUser"].ToString();
                m_CategoryMaster.CreatedDate = DateTime.Now;
                m_CategoryMaster.ModifiedBy = Session["CurrentUser"].ToString();
                m_CategoryMaster.ModifiedDate = DateTime.Now;
                m_CategoryMaster.Active = true;
                db.M_CategoryMaster.Add(m_CategoryMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_CategoryMaster);
        }

        // GET: CategoryMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_CategoryMaster m_CategoryMaster = await db.M_CategoryMaster.FindAsync(id);
            if (m_CategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_CategoryMaster);
        }

        // POST: CategoryMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategoryID,CategoryName,Description,CreatedBy,CreatedDate,Active")] M_CategoryMaster m_CategoryMaster)
        {
            if (ModelState.IsValid)
            {
                m_CategoryMaster.ModifiedBy = Session["CurrentUser"].ToString();
                m_CategoryMaster.ModifiedDate = DateTime.Now;

                db.Entry(m_CategoryMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_CategoryMaster);
        }

        // GET: CategoryMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_CategoryMaster m_CategoryMaster = await db.M_CategoryMaster.FindAsync(id);
            if (m_CategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_CategoryMaster);
        }

        // POST: CategoryMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_CategoryMaster m_CategoryMaster = await db.M_CategoryMaster.FindAsync(id);
            db.M_CategoryMaster.Remove(m_CategoryMaster);
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
