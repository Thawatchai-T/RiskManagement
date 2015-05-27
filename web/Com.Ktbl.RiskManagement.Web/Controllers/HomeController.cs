using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using System.Reflection;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        //
        // GET: /Home/

        public ActionResult Index()
        {
            try
            {
                //MongoClient client = new MongoClient("mongodb://localhost");

                //MongoServer conn = client.GetServer();
                //MongoDatabase db = conn.GetDatabase("log4net");
                //MongoCollection collection = db.GetCollection("logs");
                Log.Info("a log 1");
                Log.Info("a log 2");
                Log.Info("a log 3");
                Log.Info("a log 4");
                Log.Info("a log 5");

                //MongoDB.Driver.Builders.SortByBuilder sbb = new MongoDB.Driver.Builders.SortByBuilder();
                //sbb.Descending("_id");
               
                //var allDocs = collection.FindAllAs<BsonDocument>().SetSortOrder(sbb).SetLimit(5);

                //BsonDocument doc = allDocs.First();
                
            }
            catch (Exception ex)
            {
                Log.Error(ex);
              //  throw;
            }
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
