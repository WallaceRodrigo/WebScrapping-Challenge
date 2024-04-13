using HtmlAgilityPack;

namespace BackEnd.Services;

public class WebScrap
{
	public string scrap()
	{
		var html = @"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";

        HtmlWeb web = new HtmlWeb();

        var htmlDoc = web.Load(html);

        var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

        return("Node Name: " + node.Name + "\n" + node.OuterHtml);		
	}
}
