using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Article
    {
        /// <summary>
        /// Create an Article and insert it in the DB
        /// </summary>
        /// <param name="blogID">Id of the blog containing the T_Article.</param>
        /// <param name="mediaUrl">Link to the media includes into the article, or text if the media is a quote.</param>
        /// <param name="mediaTypeId">Type of the media.</param>
        /// <param name="text">A caption for the media, or the content of the article if there is no media.</param>
        /// <param name="tags">The tags, separated by a space</param>
        /// <returns>Nothing</returns>
        public static void Create(long blogID, String mediaUrl, long mediaTypeId, String text, String tags)
        {
            T_Article article = new T_Article()
            {
                BlogId = blogID,
                MediaUrl = mediaUrl,
                MediaTypeId = mediaTypeId,
                Text = text,
                CreationDate = DateTime.Now
            };

            List<T_Tag> newtags = new List<T_Tag>();
            string[] tabTags = tags.Split(new Char[] {' '});


            foreach (string tag in tabTags)
            {
                newtags.Add(new T_Tag() {Name = tag});
            }

            ArticleCRUD.CreateAndAddTags(article, newtags);
        }

        public Dbo.Article GetArticleDbo(long articleId)
        {
            return ArticleCRUD.GetArticleDbo(articleId);
        }

        public List<T_Article> GetWithBlog(long blogId)
        {
            return ArticleCRUD.GetWithBlog(blogId);
        }

        public static T_Article Get(long articleId)
        {
            return ArticleCRUD.Get(articleId);
        }

        public void Delete(long articleId)
        {
            ArticleCRUD.Delete(articleId);
        }
    }
}
