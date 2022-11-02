using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Webcrawler_2
{


    class Controller
    {
               

        public static async Task Iniciar(WcContext db)
        {
            var url = "https://na.finalfantasyxiv.com/lodestone/news/";
            var httpClient = new HttpClient();

            var stream = await httpClient.GetStreamAsync(url);

            var htmlDocument = new HtmlDocument();

            var reader = new StreamReader(stream, Encoding.UTF8);            
            string html = reader.ReadToEnd();

            htmlDocument.LoadHtml(html);

            var News = htmlDocument.DocumentNode.Descendants("li")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("news__list")).ToList();

            

            foreach (var li in News)
            {
                Noticia noticia = new Noticia
                {

                    Titulo = li.Descendants("a").FirstOrDefault()
                    .Descendants("div").FirstOrDefault()
                    .Descendants("p").FirstOrDefault().InnerText,

                    Link = li.Descendants("a").FirstOrDefault()
                    .ChildAttributes("href").FirstOrDefault().Value
                
                };

                db.Noticias.Add(noticia);
                await db.SaveChangesAsync();
                

            }
            

            
        }
    }
}
