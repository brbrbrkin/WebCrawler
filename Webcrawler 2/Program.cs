using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace Webcrawler_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new WcContext();
            db.IniciarDB();

            Controller.Iniciar(db);

            Console.ReadLine();

        }



    }

}