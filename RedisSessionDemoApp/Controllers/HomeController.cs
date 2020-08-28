
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisSessionDemoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Developer"] == null)
                Session["Developer"] = "MSK";
            if (Session["ListItems"] != null)
            {
                //List<SelectListItem> _Sellist = JsonConvert.DeserializeObject<List<SelectListItem>>(Session["ListItems"].ToString());
                //ViewBag.MySkills = JsonConvert.DeserializeObject<List<SelectListItem>>(Session["ListItems"].ToString());
                ViewData["MySkills"] = Session["ListItems"];
            }
            else
            {
                List<SelectListItem> _slItems = new List<SelectListItem>();
                _slItems.Add(new SelectListItem() { Value = "1", Text = "M", Selected = false });
                _slItems.Add(new SelectListItem() { Value = "2", Text = "S", Selected = true });
                _slItems.Add(new SelectListItem() { Value = "3", Text = "K", Selected = false });
                //Session["ListItems"] = JsonConvert.SerializeObject(_slItems);
                Session["ListItems"] = _slItems;
            }

            ViewBag.Developer = Session["Developer"] != null ? Session["Developer"].ToString() : String.Empty;
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}