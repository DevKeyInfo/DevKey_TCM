using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CadastroLogin.Controllers
{
    public class LinguagemController : Controller
    {
        // GET: Linguagem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Change(string LanguageAbbreviation)
        {
            if(LanguageAbbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbreviation);
            }

            HttpCookie cookie = new HttpCookie("Linguagem");
            cookie.Value = LanguageAbbreviation;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }
    }
}