using System.Net.Http;
using HtmlAgilityPack;

// HttpClient is just a browser without UI
var client = new HttpClient();

// Using this we can get the HTML text
var html = await client.GetStringAsync("https://example.com/");

// HTML agility pack is to diverse into the HTML tree and select the node we wanted
// First we write the raw html text obtained into a HTML document using HTML agility pack
var doc = new HtmlDocument();
doc.LoadHtml(html);

// We use XPath to to locate elements inside HTML

// // -> To search anywhere
// / -> Go inside /html/body/div/h1 -> This will return only one h1 inside that path.
// @ -> For attributes
// //p[@class="good"] -> It will return the content inside the p tag with class name good.

// And there are many Xpath notations. We need to study/memorize it.
var titleNode = doc.DocumentNode.SelectSingleNode("//title");
if (titleNode != null)
{
    Console.WriteLine(titleNode.InnerText);
}

var paragraphs = doc.DocumentNode.SelectNodes("//p");
if (paragraphs != null)
{
    foreach (var p in paragraphs)
    {
        Console.WriteLine(p.InnerText);
    }
}

var attributes = doc.DocumentNode.SelectNodes("//a");
if (attributes != null)
{
    Console.WriteLine("\nLinks:");
    foreach (var link in attributes)
    {
        var href = link.GetAttributeValue("href" , "");
        Console.WriteLine(href);
    }
}

