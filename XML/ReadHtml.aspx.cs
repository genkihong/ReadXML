using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XML
{
  public partial class ReadHtml : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //string web = GetContent("https://w3c.hexschool.com/category/blog");
      string web = GetContent("http://www.citytalk.tw/");
      HtmlDocument htmlDoc = new HtmlDocument();
      htmlDoc.LoadHtml(web);

      //HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode("/html/body/main/div/div/div/div/article[3]/div[1]/h3");
      HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[2]/div[2]/div[2]/div/div/section[2]/div/div[1]/div/div[1]/div/h3");
      Literal1.Text = node.InnerText;
    }
    private string GetContent(string Url)
    {
      try //程式主執行區或可能發生錯誤的地方
      {
        //string targetURI = Url;
        var request = System.Net.WebRequest.Create(Url);  // Create a request for the URL.
        //request.ContentType = "charset=utf-8";
        request.ContentType = "application/json; charset=utf-8";
        string text;
        var response = (System.Net.HttpWebResponse)request.GetResponse();
        using (var sr = new StreamReader(response.GetResponseStream()))
        {
          text = sr.ReadToEnd();
        }
        return text;
      }
      catch (Exception) //例外的處理方法，如秀出警告
      {
        return string.Empty;
      }
    }
  }
}