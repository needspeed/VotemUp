using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bend.Util;
using System.IO;
using Bend.Util;

namespace VotemUp.HTTP
{
    class MyHttpServer : HttpServer
    {
        private UserManager um;
        private PlayList pl;

        public MyHttpServer(int port, UserManager um, PlayList pl) : base(port)
        {
            this.um = um;
            this.pl = pl;
        }        

        public override void handleGETRequest(HttpProcessor p)
        {
            openFile(p.http_url, p.outputStream);
        }

        private void openFile(String url, StreamWriter out_stream, Dictionary<String, String> vars = null)
        {
            if (!url.Equals("/") && !url.EndsWith(".cs"))
            {
                String path = url.Substring(1);
                try
                {
                    String mime_type = "text/html";
                    if (url.EndsWith(".png")) mime_type = "image/png";
                    else if (url.EndsWith(".html")) mime_type = "text/html";
                    else if (url.EndsWith(".css")) mime_type = "text/css";
                    sendFile(path, mime_type, out_stream);
                }
                catch (FileNotFoundException fnfe)
                {
                    sendFile("404", "text/html", out_stream);
                }
            }
            else if (url.EndsWith(".cs"))
            {
                //parse commands in a cs and return html
                String path = url.Substring(1);

                try
                {
                    StreamReader sr = new StreamReader("html/" + path);

                    String cs = sr.ReadToEnd();

                    String[] split_at_beginnig_tag = cs.Split(new String[] { "<cs>" }, StringSplitOptions.None);
                    String non_cs_code_at_beginning = split_at_beginnig_tag[0];

                    HttpProcessor.writeSuccess(out_stream);
                    out_stream.Write(non_cs_code_at_beginning);
                    for (int i = 1; i < split_at_beginnig_tag.Length; i++)
                    {
                        String[] split_at_end_tag = split_at_beginnig_tag[i].Split(new String[] { "</cs>" }, StringSplitOptions.None);
                        String cs_code = split_at_end_tag[0];
                        String following_non_cs_code = split_at_end_tag[1];

                        String generated_html = CsInterpreter.interpretCsCode(cs_code, pl, "html/" + path, vars);
                        generated_html += following_non_cs_code;

                        out_stream.Write(generated_html);
                    }


                }
                catch (FileNotFoundException fnfe)
                {
                    sendFile("404", "text/html", out_stream);
                }
                catch (IndexOutOfRangeException ioore)
                {
                    HttpProcessor.writeSuccess(out_stream);

                    out_stream.WriteLine(
                        "<h1> 566 Defect .cs code </h1>"
                        );
                }
            }
            else
            {
                Console.WriteLine("request: {0}", url);
                HttpProcessor.writeSuccess(out_stream);

                out_stream.WriteLine(
                    "<h1> Default Page </h1>" +
                    "<form action=index.html method=post>" +
                        "<input id=trans name=user type=text value=Janni>" +
                        "<input id=trans name=pw type=text value=asdf>" +
                        "<input id=trans name=uid type=text value=-1959629167>" +
                        "<input type=image id=myButton src=/arrow.png>" +
                    "</form>"
                    );
            }
        
        }

        private void sendFile(String path, String mime_type, StreamWriter out_stream)
        {
            Stream fs = File.Open("html/" + path, FileMode.Open);

            HttpProcessor.writeSuccess(out_stream, mime_type);
            out_stream.Flush();

            fs.CopyTo(out_stream.BaseStream);
            out_stream.BaseStream.Flush();
            fs.Flush();
            fs.Close();                   
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();

            p.writeSuccess();

            String[] args = data.Split('&');
            Dictionary<String, String> act_args = new Dictionary<string, string>();
            foreach (String s in args)
            {
                String[] arg_pair = s.Split('=');
                act_args[arg_pair[0]] = arg_pair[1];
            }

            bool success = false;

            if (p.http_url.Equals("/vote/index.cs"))
            {
                String user = act_args["user"];
                String pass = act_args["pw"];
                String md5pass = Util.getMD5Hash(pass);
                int uid = Convert.ToInt32(act_args["uid"]);

                success = pl.vote(uid, um.getUser(user, md5pass));

                p.outputStream.WriteLine("<h1>Vote aftersite</h1>");
                p.outputStream.WriteLine("<a href=/vote/vote.cs>Vote was {0}</a><p>", (success) ? "successfull" : "not successfull");
            }
            else if (p.http_url.Equals("/vote/pass.cs"))
            {                
                Dictionary<String, String> vars_to_pass = new Dictionary<string,string>();
                vars_to_pass["UID"] = act_args["uid"];

                openFile("/vote/pass.cs", p.outputStream, vars_to_pass);
            }

            //p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);
        }
    }
}
