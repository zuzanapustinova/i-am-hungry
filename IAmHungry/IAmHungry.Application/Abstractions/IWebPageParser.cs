using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmHungry.Application.Abstractions
{
    public interface IWebPageParser
    {
        HtmlDocument LoadPage(string url);

        List<string> FindNodes(HtmlDocument doc, string node);
        string FindSingleNode(HtmlDocument doc, string node);
    }
}
