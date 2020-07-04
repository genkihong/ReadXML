using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XML
{
  public partial class ReadXML2 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      StringBuilder sb = new StringBuilder("<table><tr><th>資料年度</th><th>統計項目</th><th>稅目別</th><th>資料單位</th><th>值</th></tr>");

      XmlDocument xdoc = new XmlDocument();
      xdoc.Load("https://data.kcg.gov.tw/dataset/9c1303df-2493-43ce-bb78-8686963f91b7/resource/a34eed92-8c03-4ae0-8273-bb09f489a928/download/xml76.xml");
      XmlNode root = xdoc.DocumentElement;
      
      foreach (XmlNode rootChild in root.ChildNodes)
      {
        sb.Append("<tr>");
        foreach (XmlNode node in rootChild.ChildNodes)
        {
          sb.Append($"<td>{node.InnerText}</td>");
        }
        sb.Append("</tr>");
      }

      XmlNode selectNode = root.SelectSingleNode("各項稅捐徵課成本[3]");
      sb.Append("<tr>");
      foreach (XmlNode node in selectNode.ChildNodes)
      {
        sb.Append($"<td>{node.InnerText}</td>");
      }
      sb.Append("<tr>");
      sb.Append("</table>");
      Literal1.Text = sb.ToString();
    }
  }
}