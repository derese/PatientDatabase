using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bini_Project.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Bini_Project.Controllers
{
    public class PatientsController : Controller
    {

         [Authorize]
        public ActionResult Index()
        {
            ViewData["patients"] = null;
            ViewBag.count = 0;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Index(patientSearchCriteria ps)
         {
            if(ModelState.IsValid)
            {
                string searchUri = API.patientSearch;
                
                 
                patientSearchCriteria search = new patientSearchCriteria();
                search.firstname =  ps.firstname;
                search.lastname = ps.lastname;
                search.patientID = ps.patientID;

                search.token = Session.Contents["user1"].ToString();

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(searchUri);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        HttpResponseMessage response = httpClient.PostAsJsonAsync(searchUri, search).Result;
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Rootobject ro = new Rootobject();
                            var res = await response.Content.ReadAsStringAsync();
                            ro = JsonConvert.DeserializeObject<Rootobject>(res);
                            ViewData["patients"] = ro.patients;
                            ViewBag.count = ro.Count;
                            return View();

                        }
                        else
                        {
                            ModelState.AddModelError(response.StatusCode.ToString() ,response.ReasonPhrase);
                            return View();

                        }
                    }catch(Exception ex)
                    {
                        ModelState.AddModelError("Service Error", "Error Connecting to Remote Services");
                        return View();
                    }

                }
            }
            
            return View();
         }
    }
}