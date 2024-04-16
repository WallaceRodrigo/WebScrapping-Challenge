// using BackEnd.Models;
// using System.Net;
// using HtmlAgilityPack;

// namespace BackEnd.Services;

// public class WebScrap
// {
//  public List<IAliment> scrap()
//  {
//    var html = @"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";

//    HtmlWeb web = new HtmlWeb();

//    var htmlDoc = web.Load(html);

//    var node = htmlDoc.DocumentNode.SelectNodes("//tr");

//    IEnumerable<Dictionary<string, string>> createComponents(IEnumerable<HtmlNode> nodes, HtmlNode referenceNode)
//    {
//      var components = new List<Dictionary<string, string>>();
//      var propertyNames = referenceNode.ChildNodes.Select(n => WebUtility.HtmlDecode(n.InnerText)).ToArray();

//      foreach (var node in nodes)
//      {
//        var component = new Dictionary<string, string>();
//        for (int i = 0; i < propertyNames.Length; i++)
//        {
//          component[propertyNames[i]] = node.ChildNodes[i].InnerText;
//        }
//        components.Add(component);
//      }

//      return components;
//    }

//    return node.Skip(1).Select(node =>
//    {
//      var componentsHtml = @$"https://www.tbca.net.br/base-dados/int_composicao_estatistica.php?cod_produto={node.ChildNodes[0].InnerText}";
//      var htmlDocComponents = web.Load(componentsHtml);
//      var nodeComponents = htmlDocComponents.DocumentNode.SelectNodes("//tr");

//      var Aliments = new IAliment
//      {
//        AlimentId = node.ChildNodes[0].InnerText,
//        name = node.ChildNodes[1].InnerText,
//        scientificName = node.ChildNodes[2].InnerText,
//        group = node.ChildNodes[3].InnerText,
//        brand = node.ChildNodes[4].InnerText,
//        components = createComponents(nodeComponents.Skip(1), nodeComponents[0])
//      };


//      return Aliments;

//    }).ToList();
//  }
// }
