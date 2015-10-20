using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bini_Project.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Security;


namespace Bini_Project.Controllers
{
    public class userController : Controller
    {
        
        // GET: user
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Error = null;
            return View(new User());

        }
        
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(User userModel)
        {
            ViewBag.Error = null;
            if (ModelState.IsValid)
            {
                string loginUri = API.Login;
                string _lvUserName = userModel.userName; // this shouldnt have been necessary as the API should have returned the username too


                using (HttpClient httpClient = new HttpClient())
                {


                    httpClient.BaseAddress = new Uri(loginUri);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                    try
                    {
                        HttpResponseMessage response = httpClient.PostAsJsonAsync(loginUri, userModel).Result;


                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            userModel = await response.Content.ReadAsAsync<User>();
                            userModel.userName = _lvUserName;
                            FormsAuthentication.SetAuthCookie(_lvUserName, false);
                            Session.Add(userModel.userName, userModel.token);


                            return RedirectToAction("Index", "Patients");                          
                        }
                        else
                        {
                            
                            ViewBag.Error = "Wrong User name and password";                            
                            return View(userModel);
                        }
                    }catch(Exception ex)
                    {
                       
                        ViewBag.Error = "Error Connecting to Remote Services";
                        return View(userModel);
                    }

                }
            }
 

            return View();
        }
    }
}