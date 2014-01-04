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

        public enum HTTPSTATUS
        {
            FORBIDDEN = 403, NOT_FOUND = 404, INTERNAL_SERVER_ERROR = 500, CS_CODE_DEFECT = 566
        }

        public enum MIMETYPE
        {
            HTML, PNG, BMP, JPG, JPEG, CSS
        }

        public static String getMimetype(MIMETYPE m)
        {
            switch (m)
            {
                case MIMETYPE.HTML:
                    return "text/html";
                case MIMETYPE.PNG:
                    return "image/png";
                case MIMETYPE.BMP:
                    return "image/bmp";
                case MIMETYPE.JPG:
                    return "image/jpg";
                case MIMETYPE.JPEG:
                    return "image/jpeg";
                case MIMETYPE.CSS:
                    return "text/css";
                default:
                    return "";
            }
        }

        public static String getMimetypeByFileExtension(String file)
        {
            if (file.EndsWith(".png")) return getMimetype(MIMETYPE.PNG);
            else if (file.EndsWith(".jpg")) return getMimetype(MIMETYPE.JPG);
            else if (file.EndsWith(".jpeg")) return getMimetype(MIMETYPE.JPEG);
            else if (file.EndsWith(".bmp")) return getMimetype(MIMETYPE.BMP);
            else if (file.EndsWith(".html") || file.EndsWith(".csh")) return getMimetype(MIMETYPE.HTML);
            else if (file.EndsWith(".css")) return getMimetype(MIMETYPE.CSS);
            else return "";
        }

        public static String getHTMLdirectory()
        {
            return "../../HTML/";
        }

        public static void throwError(HTTPSTATUS status, System.IO.StreamWriter out_stream, bool writesuccess = true)
        {
            if (writesuccess) Bend.Util.HttpProcessor.writeSuccess(out_stream);
            int code = (int)status;
            String msg = "";
            switch (status)
            { 
                case HTTPSTATUS.FORBIDDEN:
                    msg = "Forbidden";
                    break;
                case HTTPSTATUS.NOT_FOUND:
                    msg = "Page not found";
                    break;
                case HTTPSTATUS.CS_CODE_DEFECT:
                    msg = "Defect cs code";
                    break;
                default:
                    code = 500;
                    msg = "Internal Server Error";
                    break;
            }

            out_stream.WriteLine(String.Format("<h1>{0:d} {1}</h1>", code, msg)); //<h1>" + code + " " + msg);
            out_stream.BaseStream.Flush();
        }
    }
}
