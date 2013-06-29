using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class InscriptionController : Controller
    {
        //
        // GET: /Inscription/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(InscriptionModel model)
        {
            if (model.mdp != model.mdpbis)
            {
                return RedirectToAction("Index");
            }

            Dbo.Account acc = new Dbo.Account()
            {
                Email = model.email,
                Firstname = model.firstname,
                Lastname = model.name,
                Login = model.username,
                Password = model.mdp
            };

            if (!BusinessManagement.Registration.RegisterAccount(acc))
                return RedirectToAction("Index");

            return RedirectToAction("OnAccountCreated");
        }

        public ActionResult OnAccountCreated()
        {
            return View();
        }
    }
}
