using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using System.Reflection;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Web.Routing;
using System.IO;
using Com.Ktbl.RiskManagement.Map.Repository;
using System.Configuration;
using Com.Ktbl.RiskManagement.Domain;



namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        public string Page { get; set; }
        public string OccupationCatelogy { get; set; }

        private ICCISourceRepository CCISourceRepository { get; set; }
        private IOccupationRepository OccupationRepository { get; set; }
        private IPoliticianRelationshipRepository PoliticianRelationshipRepository { get; set; }
        private IPositionRepository PositionRepository { get; set; }
        private ICountryRepository CountryRepository { get; set; }
        private IDecisionTableRepository DecisionTableRepository { get; set; }
        private IApplicationNameRepository ApplicationNameRepository { get; set; }

        //
        // GET: /Home/
        /// <summary>
        /// ref:// http://stackoverflow.com/questions/1257482/redirecttoaction-with-parameter
        /// return RedirectToAction( "Main", new RouteValueDictionary( 
        ///           new { controller = controllerName, action = "Main", Id = Id } ) );
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string page, string catelogy, string group, string type, string position,string requestno, string user, string key)
        {
            try
            {
                
                //check in database common user
                CheckParameter(ref catelogy, ref group, ref type, ref position);

                ViewBag.Page = page;
                ViewBag.OccupationCatelogy = catelogy;
                ViewBag.OccupationGroup = group;
                ViewBag.OccupationType = type;
                ViewBag.Position = position;
                ViewBag.Key = key;
                ViewBag.User = user;
                ViewBag.RequestNo = requestno;
                var isAppkey = ApplicationNameRepository.CheckKey(key);

                if (!string.IsNullOrEmpty(user) && isAppkey)
                {
                    ViewBag.Status = true;
                }
                else
                {
                    ViewBag.Status = false;
                }

                Log.Info(string.Format("test {0}",DateTime.Now));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
              //  throw;
            }
            return View();
        }


        public ActionResult Individual(string catelogy, string group, string type, string position,string key,string user)
        {
            Page = "Individual";

            CheckParameter(ref catelogy, ref group, ref type, ref position);

            return RedirectToAction("Index", "Home", new { Page = "Individual", catelogy = catelogy, group =group, type = type, position = position });
        }

        private void CheckParameter(ref string catelogy, ref string group, ref string type, ref string position)
        {
            string _catelogy = catelogy;
            string _group = group;
            string _type = type;
            string _position = position;

            if (this.OccupationRepository.GetOccupationCatelogy().Where(x => x.Id == _catelogy).FirstOrDefault() != null)
            {

                if (this.OccupationRepository.GetOccupationGroup().Where(x => x.Id == _group).FirstOrDefault() != null)
                {
                    if (this.OccupationRepository.GetOccupationType().Where(x => x.Id == _type).FirstOrDefault() != null)
                    {
                        if (this.PositionRepository.GetAll().Where(x => x.Id == _position).FirstOrDefault() != null)
                        {

                        }
                        else
                        {
                            position = "";
                        }
                    }
                    else
                    {
                        type = "";
                        position = "";
                    }
                }
                else
                {
                    group = "";
                    type = "";
                    position = "";
                }


            }
            else
            {
                catelogy = "";
                group = "";
                type = "";
                position = "";

            }
        }

        public ActionResult Corporation(string catelogy, string group, string type, string position)
        {
            Page = "Corporation";
            CheckParameter(ref catelogy, ref group, ref type, ref position);
            return RedirectToAction("Index", "Home", new { Page = "Individual", catelogy = catelogy, group = group, type = type, position = position });
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

        public JsonResult InsertInit(string user){
            List<DecisionTable> list = new List<DecisionTable>();
            if(user.Equals("jonehua")){
                this.DecisionTableRepository.InsertInitData();
                list = this.DecisionTableRepository.GetById(1);
            }
            return Json(new { data = list, total = list.Count }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetKeyWithAppName(string appname){
            try
            {
                var appkey = this.ApplicationNameRepository.GetKeyWithAppName(appname);
                return Json(new { Appname = appkey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public JsonResult GetAppNameWithKey(string key)
        {
            try
            {
                var appkey = this.ApplicationNameRepository.GetAppNameWithKey(key);
                return Json(new { Appname = appkey }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public JsonResult SaveAppName(string appname)
        {
            try
            {
                var result = this.ApplicationNameRepository.Insert(new ApplicationNameDomain
                {
                    Active = true,
                    AppName = appname.ToLower(),
                });
                var appkey = this.ApplicationNameRepository.GetKeyWithAppName(appname.ToLower());
                return Json(new { Appname = appkey.Replace("-", string.Empty) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
