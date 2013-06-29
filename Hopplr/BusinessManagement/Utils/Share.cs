using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessManagement.Utils
{
    public class Share
    {
        private static readonly string baseUrl = "http://localhost:5288";

        public static string ArticleOnFacebook(long articleId)
        {
            string articleUrl = HttpUtility.UrlEncode(baseUrl + "/ArticleDisplay/Display?id=" + articleId);

            return "<iframe src=\"//www.facebook.com/plugins/like.php?href=" + articleUrl + "&amp;send=false&amp;layout=button_count&amp;width=450&amp;show_faces=true&amp;font&amp;colorscheme=light&amp;action=like&amp;height=21\" scrolling=\"no\" frameborder=\"0\" style=\"border:none; overflow:hidden; width:450px; height:21px;\" allowTransparency=\"true\"></iframe>";
        }

        public static string ArticleOnTwitter(long articleId)
        {
            string articleUrl = baseUrl + "/ArticleDisplay/Display?id=" + articleId;

            return "<a href=\"https://twitter.com/share\" class=\"twitter-share-button\" data-url=\"" + articleUrl + "\" data-lang=\"fr\">Tweeter</a>"
                 + "<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script>";
        }
    }
}
