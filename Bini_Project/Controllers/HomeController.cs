using Bini_Project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bini_Project.Controllers
{
    public class HomeController : Controller
    {
     
        [Authorize]
        public async Task<ActionResult> Index()
        {
                              
            //string searchUri = API.patientSearch;
                 
            //patientSearchCriteria search = new patientSearchCriteria();
            //search.firstname =  "ar";
            //search.token = Session.Contents["user1"].ToString();

            //    using (HttpClient httpClient = new HttpClient())
            //    {
            //        httpClient.BaseAddress = new Uri(searchUri);
            //        httpClient.DefaultRequestHeaders.Accept.Clear();
            //        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            //        HttpResponseMessage response = httpClient.PostAsJsonAsync(searchUri, search).Result;
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            Rootobject ro = new Rootobject();
            //            List<patient> j = null;
            //            var res = await response.Content.ReadAsStringAsync();                        
            //            ro =  JsonConvert.DeserializeObject<Rootobject>(res);
                        
            //          return RedirectToAction("Index", "Home");
            //            //return Redirect("Home/Index");
            //        }
            //        else
            //        {
            //            ViewBag.result = "Error";
            //            return View();
            //            //return View(userModel);
            //        }

            //    }
                return View();
              
            }

          
        

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}