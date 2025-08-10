using HtmlAgilityPack;

namespace IAmHungry.Application.Abstractions
{
    public interface IWebPageParser
    {
        HtmlDocument LoadPage(string url);
        List<HtmlNode> FindNodes(HtmlDocument doc, string node);

        List<string> GetNodesInnerText(HtmlDocument doc, string node);
        string GetSingleNodeInnerText(HtmlDocument doc, string node);
    }
}
