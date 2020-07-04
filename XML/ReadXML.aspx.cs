using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XML
{
  public partial class ReadXML : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      DataTable dt = new DataTable();
      //新增欄位名稱, 欄位型別
      dt.Columns.Add("序號", typeof(int));
      dt.Columns.Add("資料年度", typeof(string));
      dt.Columns.Add("統計項目", typeof(string));
      dt.Columns.Add("稅目別", typeof(string));
      dt.Columns.Add("資料單位", typeof(string));
      dt.Columns.Add("值", typeof(string));

      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.Load("https://data.kcg.gov.tw/dataset/9c1303df-2493-43ce-bb78-8686963f91b7/resource/a34eed92-8c03-4ae0-8273-bb09f489a928/download/xml76.xml");
      XmlNode root = xmlDoc.DocumentElement;//取得文件的根節點<DataCollection>
      XmlNodeList xmlList = root.ChildNodes;//<DataCollection>內的<各項稅捐徵課成本>
      int i = 1;

      foreach (XmlNode rootChild in xmlList)
      {
        DataRow row = dt.NewRow();//建立新的一筆資料，已經有欄位
        foreach (XmlNode node in rootChild.ChildNodes)
        {
          row[0] = i;
          row[1] = node.InnerText;
          row[2] = node.InnerText;
          row[3] = node.InnerText;
          row[4] = node.InnerText;
          row[5] = node.InnerText;

          #region 
          //switch (node.Name)
          //{
          //  case "資料年度":
          //    row["資料年度"] = node.InnerText;
          //    break;
          //  case "統計項目":
          //    row["統計項目"] = node.InnerText;
          //    break;
          //  case "稅目別":
          //    row["稅目別"] = node.InnerText;
          //    break;
          //  case "資料單位":
          //    row["資料單位"] = node.InnerText;
          //    break;
          //  case "值":
          //    row["值"] = node.InnerText;
          //    break;
          //}
          #endregion
        }
        dt.Rows.Add(row);
        i++;
      }

      DataView dv = dt.DefaultView;//和 dt 內容一樣的檢視表
      dv.RowFilter = "序號<10";

      DataView dv1 = new DataView(dt);
      dv1.RowFilter = "序號>=10";

      //GridView1.DataSource = dt;
      //GridView1.DataBind();

      GridView1.DataSource = dv;
      GridView1.DataBind();

      GridView2.DataSource = dv1;
      GridView2.DataBind();
    }
  }
}