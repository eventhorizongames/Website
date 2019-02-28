#r "nuget: HtmlAgilityPack, 1.9.0" 
#load "./blog/clean.blog.folder.csx"

using HtmlAgilityPack;

// Delete current blog folder
CleanBlogFolder("../");
// Read template HTML from blog.data
var template = ReadHtmlDocument(
    "../blog.data/template.html"
);
// Read blog.data files
// Inject blog data into html template
// Save blog html page to blog folder

Console.WriteLine(
    template.SelectSingleNode("//title").InnerText
);
template.SelectSingleNode("//title").ParentNode.ReplaceChild(
    HtmlNode.CreateNode("<title>some title</title>"),
    template.SelectSingleNode("//title")
);
Console.WriteLine(
    template.SelectSingleNode("//title").InnerText
);

var filePath = @"..\blog.data\2-27-2019.html";

var document = new HtmlDocument();
document.Load(filePath);

Console.WriteLine(
    document.DocumentNode.SelectSingleNode("//title").InnerText
);

HtmlNode ReadHtmlDocument(string filePath)
{
    var document = new HtmlDocument();
    document.Load(filePath);
    return document.DocumentNode;
}