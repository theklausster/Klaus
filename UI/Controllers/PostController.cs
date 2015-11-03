using DAL.Entities;
using RestService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class PostController : Controller

    {
        ApiController api = new ApiController();
        // GET: Posts
        public ActionResult Index()
        {
            return View(api.GetAll());
        }

        //Get: Post/id
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description, ImageUrl, Title")] PostContent p)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = api.Post(p);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(response.StatusCode);
                }
            }
            return View(p);
        }

    }
}