using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoTutorials.Models;

namespace VideoTutorials.Controllers
{
    [Authorize]
    public class VideosController : Controller
    {
        private VideoTutorialsDbContext db = new VideoTutorialsDbContext();
        [HttpGet]
        // GET: /Videos/
        [Authorize(Roles="admin")]
        public ActionResult Index(string videoCategory, string adminSearchString)
        {
            var videos = db.Videos.Include(v => v.Categories);


            var CategoryList = new List<string>();

            var CategoryQry = from d in db.Categories
                           orderby d.Name
                           select d.Name;

            CategoryList.AddRange(CategoryQry.Distinct());

            ViewBag.videoCategory = new SelectList(CategoryList);

            var movies = from m in db.Videos
                         select m;

            if (!String.IsNullOrEmpty(adminSearchString))
            {
                videos = videos.Where(s => s.Title.Contains(adminSearchString));
            }

            if (!string.IsNullOrEmpty(videoCategory))
            {
                videos = videos.Where(x => x.Categories.Name == videoCategory);
            }

              return View(videos.ToList());
        }

        // GET: /Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: /Videos/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: /Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VideoID,Title,Description,Link,Tags,Thumbnail,CategoryID")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", video.CategoryID);
            return View(video);
        }

        // GET: /Videos/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", video.CategoryID);
            return View(video);
        }

        // POST: /Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include="VideoID,Title,Description,Link,Tags,Thumbnail,CategoryID")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", video.CategoryID);
            return View(video);
        }

        // GET: /Videos/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: /Videos/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult VideoList(string name)
        {
            var videos = db.Videos.Include(v => v.Categories).Where(v => v.isApproved == true);

            if (!string.IsNullOrWhiteSpace(name))
            {
                var filteredResult =
                    db.Videos
                    .Where(x =>
                                x.Title.Contains(name)
                            )
                    .ToList();

                return View(filteredResult);
            }
            return View(videos.ToList());
        }
        public ActionResult WatchVideo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        [HttpGet]
        // GET: /Videos/
        [Authorize(Roles = "admin")]
        public ActionResult UnapprovedVideos()
        {
            var videos = db.Videos.Include(v => v.Categories).Where(v => v.isApproved == false);


            return View(videos.ToList());
        }
        public ActionResult ApproveVideo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            video.isApproved = true;
            db.SaveChanges();

            return RedirectToAction("UnapprovedVideos", "Videos");
        }
    }
}
