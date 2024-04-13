using HtmlAgilityPack;
using BackEnd.Dto;
using System.Net;

namespace BackEnd.Services;

public class WebScrap
{
  public List<alimentDTO> scrap()
  {
    var html = @"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";

    HtmlWeb web = new HtmlWeb();

    var htmlDoc = web.Load(html);

    var node = htmlDoc.DocumentNode.SelectNodes("//tr");

    return node.Skip(1).Select(node =>
    {
      var componentsHtml = @$"https://www.tbca.net.br/base-dados/int_composicao_estatistica.php?cod_produto={node.ChildNodes[0].InnerText}";
      var htmlDocComponents = web.Load(componentsHtml);
      var nodeComponents = htmlDocComponents.DocumentNode.SelectNodes("//tr");

      var Aliments = new alimentDTO
      {
        id = node.ChildNodes[0].InnerText,
        name = node.ChildNodes[1].InnerText,
        scientificName = node.ChildNodes[2].InnerText,
        group = node.ChildNodes[3].InnerText,
        brand = node.ChildNodes[4].InnerText,
        components = nodeComponents.Skip(1).Select(node => (
          new Dictionary<string, string>
          {
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[0].InnerText)}", node.ChildNodes[0].InnerText },
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[1].InnerText)}", node.ChildNodes[1].InnerText },
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[2].InnerText)}", node.ChildNodes[2].InnerText },
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[3].InnerText)}", node.ChildNodes[3].InnerText },
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[4].InnerText)}", node.ChildNodes[4].InnerText },
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[5].InnerText)}", node.ChildNodes[5].InnerText },
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[6].InnerText)}", node.ChildNodes[6].InnerText },
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[7].InnerText)}", node.ChildNodes[7].InnerText },
            {$"{WebUtility.HtmlDecode(nodeComponents[0].ChildNodes[8].InnerText)}", node.ChildNodes[8].InnerText },
          }
        )),
      };

      return Aliments;

    }).ToList();
  }
}