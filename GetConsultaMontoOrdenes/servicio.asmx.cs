using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace GetConsultaMontoOrdenes
{
    /// <summary>
    /// Descripción breve de servicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class servicio : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection("Data Source=.; Initial Catalog=AdventureWorks2014; Integrated Security=true");

        [WebMethod]
        public DataSet SalesOrderHeader()
        {
            cn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("select top 100 salesorderid from sales.salesorderheader", cn);
            cn.Close();
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet SalesOrderDetail(String orden)
        {
            cn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("select SUM(unitprice * orderqty) from sales.salesorderdetail where salesorderid="+orden+";", cn);
            cn.Close();
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }

    }
}
