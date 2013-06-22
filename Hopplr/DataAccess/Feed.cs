using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Feed
    {
        public static List<Dbo.Article> GetBlogContent(string userName, string blogName)
        {
            using (HopplrEntities entities = new HopplrEntities())
            {
                try
                {
                    List<Dbo.Article> articles = new List<Dbo.Article>();

                    User user = entities.User.Where(usr => usr.Pseudo == userName).FirstOrDefault();
                    Blog blog = entities.Blog.Include("Article").Where(blg => blg.Nom == blogName && blg.UserId == user.id).FirstOrDefault();
                   
                    foreach (Article item in blog.Article)
	                {
                        Mapper.CreateMap<Article, Dbo.Article>().BeforeMap((src, dest) =>
                            {
                                switch (src.MediaType.Description)
                                {
                                    case "Image":
                                        dest.MediaType1 = Dbo.Article.MediaType.Image;
                                        break;
                                    case "Video":
                                        dest.MediaType1 = Dbo.Article.MediaType.Video;
                                        break;
                                    case "Musique":
                                        dest.MediaType1 = Dbo.Article.MediaType.Son;
                                        break;
                                    default:
                                        dest.MediaType1 = Dbo.Article.MediaType.None;
                                        break;
                                }

                                src.Blog = null;
                                dest.Blog = null;

                            });
                       articles.Add((Dbo.Article) Mapper.Map<Dbo.Article>(item));
                    }

                    return articles;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
