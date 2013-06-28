using BusinessManagement;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class ArticleCreationController : Controller
    {
        public ActionResult AddArticle(long blogId, Int32 type = 2)
        {
            MediaType mediaType =  new MediaType();
            if (mediaType.getMediaType(type) == null)
                throw new Exception("MediaType is invalid");

            switch (type)
            {
                case (Int32)Tools.MediaTypes.Image:
                    return RedirectToAction("AddImage", new { blogId });
                case (Int32)Tools.MediaTypes.Video:
                    return RedirectToAction("AddVideo", new { blogId });
                case (Int32)Tools.MediaTypes.Music:
                    return RedirectToAction("AddMusic", new { blogId });
                case (Int32)Tools.MediaTypes.Quote:
                    return RedirectToAction("AddQuote", new { blogId });
                default:
                    throw new ArgumentException("type");
            }
        }

        public ActionResult AddQuote(long blogId)
        {
            ViewBag.BlogId = blogId;
            return View();
        }

        [HttpPost]
        public ActionResult AddQuote(QuoteModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (String.IsNullOrEmpty(model.Quote))
                return View(model);

            InsertArticleInBDD(model.BlogId, model.Quote, (long)Tools.MediaTypes.Quote, model.Caption);

            return View();
        }

        public ActionResult AddMusic(long blogId)
        {
            ViewBag.BlogId = blogId;
            return View();
        }

        [HttpPost]
        public ActionResult AddMusic(FileModel model)
        {
            String path;
            if (!CheckAndImportFile(model, out path))
                return View(model);

            if (!path.EndsWith("mp3", true, null))
            {
                ModelState.AddModelError("File", "Le fichier n'est pas un mp3.");
                Tools.DeleteFile(path);
                return View(model);
            }

            InsertArticleInBDD(model.BlogId, path, (long)Tools.MediaTypes.Music, model.Caption);

            return View();
        }

        public ActionResult AddImage(long blogId)
        {
            ViewBag.BlogId = blogId;
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(FileModel model)
        {
            String path;
            if (!CheckAndImportFile(model, out path))
                return View(model);

            if (!IsValidImage(path))
            {
                ModelState.AddModelError("File", "Le fichier n'est pas une image valide.");
                Tools.DeleteFile(path);
                return View(model);
            }

            InsertArticleInBDD(model.BlogId, path, (long)Tools.MediaTypes.Image, model.Caption);

            return View();
        }

        public ActionResult AddVideo(long blogId)
        {
            ViewBag.BlogId = blogId;
            return View();
        }

        [HttpPost]
        public ActionResult AddVideo(VideoModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (String.IsNullOrEmpty(model.Url))
                return View(model);
            else if (!Regex.Match(model.Url, @".+youtube\..+", RegexOptions.IgnoreCase).Success)
                return View(model);

            String youtubeID = GetYouTubeID(model.Url);
            if (youtubeID == null)
            {
                ModelState.AddModelError("Url", "Le lien est invalide.");
                return View(model);
            }

            InsertArticleInBDD(model.BlogId, youtubeID, (long)Tools.MediaTypes.Video, model.Caption);

            return View();
        }


        #region private
        /// <summary>
        /// Get the Id of the video in the Youtube url.
        /// </summary>
        /// <param name="youtubeUrl">Link to the video.</param>
        /// <returns>The id of the video if exist, null otherwise.</returns>
        private String GetYouTubeID(String youtubeUrl)
        {
            //RegEx to Find YouTube ID
            Match youtubeID = Regex.Match(youtubeUrl, "^[^v]+v=(.{11}).*", RegexOptions.IgnoreCase);
            if (youtubeID.Success)
                return youtubeID.Value;
            else
                return null;

        }

        private Boolean CheckAndImportFile(FileModel model, out String path)
        {
            path = null;

            if (model == null)
                throw new ArgumentNullException("model");

            if (model.File == null || model.File.ContentLength < 0)
                return false;

            // extract only the filename
            var fileName = Path.GetFileName(model.File.FileName);
            // store the file inside ~/Medias/Images folder
            path = Path.Combine(Server.MapPath("~/Medias"), fileName);
            try
            {
                model.File.SaveAs(path);
            }
            catch (Exception e)
            {
                throw new Exception("Impossible to save the file", e);
            }

            return true;
        }

        /// <summary>
        /// Insert a T_Article into the database.
        /// </summary>
        /// <param name="blogID">Id of the blog containing the T_Article.</param>
        /// <param name="mediaUrl">Link to the media includes into the article, or text if the media is a quote.</param>
        /// <param name="mediaTypeId">Type of the media.</param>
        /// <param name="text">A caption for the media, or the content of the article if there is no media.</param>
        /// <returns>Nothing</returns>
        private void InsertArticleInBDD(long blogID, String mediaUrl, long mediaTypeId, String text)
        {
            T_Article article = new T_Article()
            {
                BlogId = blogID,
                MediaUrl = mediaUrl,
                MediaTypeId = mediaTypeId,
                Text = text,
                CreationDate = DateTime.Now
            };

            // TODO: Insert into the database.
            //Article bMArticle = new Article();
            //bMArticle.Create(article);
        }

        /// <summary>
        /// Test if a file contains an image.
        /// </summary>
        /// <param name="filename">Path of the file.</param>
        /// <returns>True if the file contains an image, false otherwise.</returns>
        private Boolean IsValidImage(String filename)
        {
            try
            {
                Image newImage = Image.FromFile(filename);
            }
            catch (OutOfMemoryException)
            {
                // Image.FromFile will throw this if file is invalid.
                // Don't ask me why.
                return false;
            }
            return true;
        }

        #endregion private
    }
}
