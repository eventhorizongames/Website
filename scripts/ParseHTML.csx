#r "nuget: HtmlAgilityPack, 1.9.0" 

using HtmlAgilityPack;

var filePath = @"..\blog.data\2-27-2019.html";

var document = new HtmlDocument();
document.Load(filePath);

Console.WriteLine(
    document.DocumentNode.SelectSingleNode("//title").InnerText
);