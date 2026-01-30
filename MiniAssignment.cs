// Tasks:
// 1️⃣ Print title
// 2️⃣ Print <h1> text
// 3️⃣ Print all paragraphs
// URL: https://httpbin.org/html

using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScrapper;

public class MiniAssignment
{
    public static async Task Run()
    {
        // HTTP client is just a browser without UI.
        var http = new HttpClient();

        // GET Raw HTML from the URL —> https://httpbin.org/html
        var html = await http.GetStringAsync("https://httpbin.org/html");
        Console.WriteLine(html);

        //Now create a HTML document to traverse through all the elements and their contents in a HTML tree.
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);

        // Now get the content of each HTML element.
        // 1️⃣ Print title
        var title = htmlDoc.DocumentNode.SelectSingleNode("//title");
        if(title != null)
        {
            Console.WriteLine(title.InnerText);
        }

        // 2️⃣ Print <h1> text
        var h1 = htmlDoc.DocumentNode.SelectNodes("//h1");
        if(h1 != null)
        {
            Console.WriteLine("\nH1 tag contents:");
            foreach(var content in h1)
            {
                Console.WriteLine(content.InnerText);
            }
        }

        // 3️⃣ Print all paragraphs
        var paragraphs = htmlDoc.DocumentNode.SelectNodes("//p");
        if(paragraphs != null)
        {
            Console.WriteLine("\nP tag contents:");
            foreach(var content in paragraphs)
            {
                Console.WriteLine(content.InnerText);
            }
        }

    }
}
