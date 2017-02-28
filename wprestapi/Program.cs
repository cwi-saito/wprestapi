using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace wprestapi
{
    class Program
    {
        static void Main(string[] args)
        {
            var getString = "http://{url}/wp-json/wp/v2/posts?filter[posts_per_page]=50&filter[year]=2017&filter[monthnum]=1";
            var postsJson = DownloadString(getString);
            var wpPosts = JsonConvert.DeserializeObject<List<wpposts>>(postsJson);

        }


        private static string DownloadString(string path)
        {
            string json = string.Empty;
            try
            {
                json = (new WebClient() { Encoding = Encoding.UTF8 }).DownloadString(path);
            }
            catch (Exception)
            {
                json = string.Empty;
            }
            return json;
        }

    }
}
