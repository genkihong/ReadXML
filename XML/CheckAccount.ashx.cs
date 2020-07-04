using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace XML
{
  /// <summary>
  /// CheckAccount 的摘要描述
  /// </summary>
  public class CheckAccount : IHttpHandler
  {

    public void ProcessRequest(HttpContext context)
    {
      context.Response.ContentType = "application/json";//決定何種格式
      string name = context.Request["name"];
      string config = WebConfigurationManager.ConnectionStrings["memberConnectionString"].ConnectionString;
      string strSQL = "SELECT name, email FROM [Users] WHERE name = @name";

      SqlConnection conn = new SqlConnection(config);
      SqlCommand cmd = new SqlCommand(strSQL, conn);
      cmd.Parameters.AddWithValue("@name", name);
      SqlDataAdapter sda = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      sda.Fill(dt);

      if (dt.Rows.Count > 0)
      {
        string json = JsonConvert.SerializeObject(dt);
        context.Response.Write(json);
      }
      else
      {
        string json = JsonConvert.SerializeObject(new
        {
          message = "查無此帳號"//匿名類型
        });

        context.Response.Write(json);
      }

    }

    public bool IsReusable
    {
      get
      {
        return false;
      }
    }
  }
}