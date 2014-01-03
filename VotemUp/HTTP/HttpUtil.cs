using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotemUp.HTTP
{
    class HttpUtil
    {
        public static List<String> alternativePage = new List<String>()
        {
            "index.csh",
            "index.html",
            "/404.html"
        };

        public enum MIMETYPE
        {
            HTML, PNG, CSS
        }

        public static String getMimetype(MIMETYPE m)
        {
            switch (m)
            {
                case MIMETYPE.HTML:
                    return "text/html";
                case MIMETYPE.PNG:
                    return "image/png";
                case MIMETYPE.CSS:
                    return "text/css";
                default:
                    return "";
            }
        }

        public static String getMimetypeByFileExtension(String file)
        {
            if (file.EndsWith(".png")) return getMimetype(MIMETYPE.PNG);
            else if (file.EndsWith(".html") || file.EndsWith(".csh")) return getMimetype(MIMETYPE.HTML);
            else if (file.EndsWith(".css")) return getMimetype(MIMETYPE.CSS);
            else return "";
        }


        public static String getHTMLdirectory()
        {
            return "../../HTML/";
        }
    }
}
