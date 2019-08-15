using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEOManagement.Models;
using SEOManagement.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEOManagement.Controllers
{
    [Authorize]
    public class SEOController : Controller
    {
        private SEOService seoService = new SEOService();

        // GET: SEO
        public ActionResult Index()
        {
            List<SEOMetaData> seoMetaData = seoService.GetAll();
            return View(seoMetaData);
        }

        // GET: SEO/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Default()
        {
            SEOMetaData data = seoService.Get(1);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DefaultAsync(SEOMetaData data)
        {
            data.Id = 1;

            await seoService.UpdateAsync(data);
            TempData["msg"] = "Default Set";

            return RedirectToAction(nameof(Index));
        }

        // POST: SEO/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(SEOMetaData data)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Error: Data Not Valid";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                //refuse if path already exists in database, suggest they edit
                //seoService.Get always returns something (default) so must make
                //so, it only exists if it returns an ID > 1 (valid id) and not default (1)
                SEOMetaData exists = seoService.Get(data.Path);
                if (exists != null && exists.Id > 1)
                {
                    TempData["msg"] = "URL already in database.  Edit instead.";
                    return RedirectToAction(nameof(Index));

                }

                int id = await seoService.AddAsync(data);
                if (id > 0)
                {
                    TempData["msg"] = "Added.";
                }
                else
                {
                    TempData["msg"] = "Error: Failure to add to database";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["msg"] = "Add Failed";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: SEO/Edit/5
        public ActionResult Edit(int id)
        {
            SEOMetaData data = seoService.Get(id);
            return View(data);
        }

        // POST: SEO/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(SEOMetaData data)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Error: Data Not Valid";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                int id = await seoService.UpdateAsync(data);
                if (id > 0)
                {
                    TempData["msg"] = "Edited.";
                }
                else
                {
                    TempData["msg"] = "Error: Failure to update database";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["msg"] = "Update Failed";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: SEO/Delete/5
        public ActionResult Delete(int id)
        {
            //testing if invalid id is passed in url
            if (!(id > 0))
            {
                TempData["msg"] = "Error: Failure to recognize which data to delete";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                seoService.Delete(id);

                TempData["msg"] = "Deleted";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["msg"] = "Deleted Failed";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}