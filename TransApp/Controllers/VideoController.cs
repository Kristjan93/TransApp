﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransApp.Models;
using TransApp.Repositories;
using PagedList;


namespace TransApp.Controllers
{
    public class VideoController : Controller
    {
        VideoRepository videoRepo = new VideoRepository();
        TranslationRepository translationRepo = new TranslationRepository();
        
        private readonly IVideoRepository repo;
        private readonly ITranslationRepository repo2;
        
        public VideoController(IVideoRepository rep)
        {
            repo = rep;
        }
        
        public VideoController(ITranslationRepository reps)
        {
            repo2 = reps;
        }

        public VideoController()
        {

        }
        
        public ActionResult FrontPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddTranslation()
        {

            List<SelectListItem> languageList = new List<SelectListItem>();

            languageList.Add(new SelectListItem { Text = "Veldu Tungumál", Value = "" });
            languageList.Add(new SelectListItem { Text = "Enska", Value = "Enska" });
            languageList.Add(new SelectListItem { Text = "Franska", Value = "Franska" });
            languageList.Add(new SelectListItem { Text = "Íslenska", Value = "Íslenska" });
            languageList.Add(new SelectListItem { Text = "Þýska", Value = "Þýska" });
            ViewData["translationLanguage"] = languageList;

            List<SelectListItem> categoryList = new List<SelectListItem>();

            categoryList.Add(new SelectListItem { Text = "Veldu Flokk", Value = "" });
            categoryList.Add(new SelectListItem { Text = "Hasar", Value = "Hasar" });
            categoryList.Add(new SelectListItem { Text = "Ævintýra", Value = "Ævintýra" });
            categoryList.Add(new SelectListItem { Text = "Rómantík", Value = "Rómantík" });
            categoryList.Add(new SelectListItem { Text = "Gaman", Value = "Gaman" });
            ViewData["translationCategory"] = categoryList;
            
            return View(new Translation());
            
            /*var model = from t in repo.GetVideos()
                        select t;
            return View(model);*/
        }

        [HttpPost]
        public ActionResult AddTranslation(Translation translation)
        {
            List<SelectListItem> languageList = new List<SelectListItem>();

            languageList.Add(new SelectListItem { Text = "Veldu Tungumál", Value = "" });
            languageList.Add(new SelectListItem { Text = "Enska", Value = "Enska" });
            languageList.Add(new SelectListItem { Text = "Franska", Value = "Franska" });
            languageList.Add(new SelectListItem { Text = "Íslenska", Value = "Íslenska" });
            languageList.Add(new SelectListItem { Text = "Þýska", Value = "Þýska" });
            ViewData["translationLanguage"] = languageList;

            List<SelectListItem> categoryList = new List<SelectListItem>();

            categoryList.Add(new SelectListItem { Text = "Veldu Flokk", Value = "" });
            categoryList.Add(new SelectListItem { Text = "Hasar", Value = "Hasar" });
            categoryList.Add(new SelectListItem { Text = "Ævintýra", Value = "Ævintýra" });
            categoryList.Add(new SelectListItem { Text = "Rómantík", Value = "Rómantík" });
            categoryList.Add(new SelectListItem { Text = "Gaman", Value = "Gaman" });
            ViewData["translationCategory"] = categoryList;
            
            if(ModelState.IsValid)
            { 

                string transName = translation.translationName;

                IEnumerable<Video> videoNames = videoRepo.GetAllVideos().ToList();

                foreach(var item in videoNames)
                {
                    if(transName == item.videoName)
                    {
                    
                        item.videoTime = translation.translationTime;
                        UpdateModel(item);
                        videoRepo.UpdateVideoTime(item);
                        videoRepo.Save();
                    
                        translation.vID = item.ID;
                    

                        translationRepo.Add(translation);
                        return RedirectToAction("/GetVideos");
                    }
                }

                int videoId = videoNames.Last().ID + 1;
            
                videoRepo.AddVideo(translation);

                translation.vID = videoId;
                translationRepo.Add(translation);

                return RedirectToAction("/GetVideos");
            
            }
            
            return View(translation);
        }


        /*public ActionResult GetTranslations()
        {
            var model = (from t in repo2.GetTranslations()
                         orderby t.translationTime descending
                         select t).Take(10);
            
            return View(model);
        }
        */
        public ActionResult OrderByName(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            
            var model = (from name in videoRepo.GetAllVideos()
                         orderby name.videoName ascending
                         select name);
            return View(model.ToPagedList(pageNumber, pageSize));
            
        }
        
        public ActionResult OrderByDate(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var model = (from date in videoRepo.GetAllVideos()
                         orderby date.videoTime descending
                         select date);
            return View(model.ToPagedList(pageNumber, pageSize));
            
            
        }
        
        
        
        public ActionResult GetVideoByCategory(string category, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            
            var model = (from t in videoRepo.GetAllVideos()
                         where t.videoCategory == category
                         orderby t.videoTime descending
                         select t);

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult OrderCategoryByName(int? page, string category)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var model = (from name in videoRepo.GetAllVideos()
                         where name.videoCategory == category
                         orderby name.videoName ascending
                         select name);
            return View(model.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult OrderCategoryByDate(int? page, string category)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var model = (from date in videoRepo.GetAllVideos()
                         where date.videoCategory == category
                         orderby date.videoTime descending
                         select date);
            return View(model.ToPagedList(pageNumber, pageSize));


        }

        public ActionResult GetTranslationsByVideoId(int id, int? page)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            
            var model = (from t in translationRepo.GetAllTranslations()
                         where t.vID == id
                         orderby t.translationTime descending
                         select t).Take(10);
            
            /*var model = (from t in repo2.GetTranslations()
                         where t.vID == id
                         orderby t.translationTime descending
                         select t).Take(10);*/

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetVideoBySearchName(string searchString)
        {
            searchString = searchString.ToLower();
            
            var model = (from t in repo.GetVideos()
                         where t.videoName.ToLower().Contains(searchString)
                         orderby t.videoTime descending
                         select t).Take(10);

            return View(model);

        }

        [HttpGet]
        public ActionResult GetVideos(int? page)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);
 
            var model = (from videos in videoRepo.GetAllVideos()
                         orderby videos.videoTime descending
                         select videos);

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        
        [HttpGet]
        public ViewResult SearchEngine(string searchString, string currentFilter, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var searchVideos = (from a in videoRepo.GetAllVideos()
                                select a);
            if (!String.IsNullOrEmpty(searchString))
            {
                searchVideos = searchVideos.Where(a => a.videoName.ToLower().Contains(searchString.ToLower()));
            }

            return View(searchVideos.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult GetTranslationById(int id)
        {
            var model = (from translation in translationRepo.GetAllTranslations()
                         where translation.ID == id
                         select translation).SingleOrDefault();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult GetTranslationById(Translation t)
        {
            if(ModelState.IsValid)
            {
                translationRepo.Update(t);
                return RedirectToAction("/GetVideos");
            }

            return View(t);
        }
        
	}
}