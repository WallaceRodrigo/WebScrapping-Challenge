using HtmlAgilityPack;
using BackEnd.Dto;

namespace BackEnd.Services;

public class WebScrap
{
	public List<alimentDTO> scrap()
	{
		var html = @"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";

        HtmlWeb web = new HtmlWeb();

        var htmlDoc = web.Load(html);

        var node = htmlDoc.DocumentNode.SelectNodes("//tr");

        return node.Select(node => {

          var Aliments = new alimentDTO
          {
            id = node.ChildNodes[0].InnerText,
            name = node.ChildNodes[1].InnerText,
            scientificName = node.ChildNodes[2].InnerText,
            group = node.ChildNodes[3].InnerText,
            brand = node.ChildNodes[4].InnerText,
          };
          
          return Aliments;

        }).ToList();
	}
}