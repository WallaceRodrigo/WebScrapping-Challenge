using HtmlAgilityPack;
using BackEnd.Models;
using System.Net;

namespace BackEnd.Services;

public class WebScrap
{
  private readonly HtmlWeb _web = new HtmlWeb();

  public List<IAliment> Scrap()
  {
    var html = @"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";

    var htmlDoc = _web.Load(html);

    var node = htmlDoc.DocumentNode.SelectNodes("//tr").Skip(1);

    return node.Select(node =>
    {
      var componentsHtml = @$"https://www.tbca.net.br/base-dados/int_composicao_estatistica.php?cod_produto={node.ChildNodes[0].InnerText}";
      var htmlDocComponents = _web.Load(componentsHtml);
      var nodeComponents = htmlDocComponents.DocumentNode.SelectNodes("//tr");

      var Aliments = new IAliment
      {
        AlimentId = node.ChildNodes[0].InnerText,
        name = node.ChildNodes[1].InnerText,
        scientificName = node.ChildNodes[2].InnerText,
        group = node.ChildNodes[3].InnerText,
        brand = node.ChildNodes[4].InnerText,
        components = createComponents(nodeComponents, node.ChildNodes[0].InnerText)
      };

      return Aliments;

    }).ToList();
  }

  private IEnumerable<ISingleComponent> createComponents(IEnumerable<HtmlNode> nodes, string alimentId)
  {
    var referenceNode = nodes.First();
    var propertyNames = referenceNode.ChildNodes.Select(n => WebUtility.HtmlDecode(n.InnerText)).ToArray();

    return nodes.Skip(1).Select(node =>
    {
      var component = new Dictionary<string, string>();
      for (int i = 0; i < propertyNames.Length; i++)
      {
        component[propertyNames[i]] = node.ChildNodes[i].InnerText;
      }

      return new ISingleComponent
      {
        AlimentId = alimentId,
        SingleComponentId = $"{alimentId}-{component["Componente"]}-{component["Unidades"]}",
        Componente = component["Componente"],
        Unidades = component["Unidades"],
        ValorPor100g = component["Valor por 100 g"],
        DesvioPadrão = component["Desvio padrão"],
        ValorMínimo = component["Valor Mínimo"],
        ValorMáximo = component["Valor Máximo"],
        NúmeroDeDadosUtilizado = component["Número de dados utilizados"],
        Referências = component["Referências"],
        TipoDeDados = component["Tipo de dados"],
      };
    }).ToList();
  }
}