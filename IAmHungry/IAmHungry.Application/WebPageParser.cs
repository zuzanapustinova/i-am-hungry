using HtmlAgilityPack;
using System.Text;

namespace IAmHungry.Application
{
    public class WebPageParser
    {
        public WebPageParser()
        {

        }

        public HtmlDocument LoadPage(string url)
        {
            var web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            HtmlDocument doc = web.Load(url);
            return doc;
        }

        public List<string> FindNodes(HtmlDocument doc, string node)
        {
            List<string> nodes = new List<string>();
            try
            {
                var htmlNodes = doc.DocumentNode.SelectNodes(node);
                if (htmlNodes == null)
                {
                    string message = $"FindNodes Node {node} was not found";
                    nodes.Add(message);
                }
                else
                {
                    foreach (var htmlNode in htmlNodes)
                    {
                        nodes.Add(htmlNode.InnerText);
                    }
                }  
            }
            catch 
            {
                throw new Exception($"Node {node} was not found");
            }
            
            return nodes;
        }

        public string FindSingleNode(HtmlDocument doc, string node)
        {
            string innerText = "";
            var htmlNode = doc.DocumentNode.SelectSingleNode(node);
            if (htmlNode != null)
            {
                innerText = htmlNode.InnerText;
            }
            else
            {
                innerText = node;
            }
            return innerText;
        }
    }
}
