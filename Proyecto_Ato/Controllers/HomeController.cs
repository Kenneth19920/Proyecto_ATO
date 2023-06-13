using Proyecto_Ato.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Ato.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();

        public ActionResult Index()
        {
            //ViewBag.Labels1 = ObtenerLabelsGrafico1();
            //ViewBag.Data1 = ObtenerDataGrafico1();
            //ViewBag.Labels2 = ObtenerLabelsGrafico2();
            //ViewBag.Data2 = ObtenerDataGrafico2();
            //ViewBag.Labels3 = ObtenerLabelsGrafico3();
            //ViewBag.Data3 = ObtenerDataGrafico3();
            //ViewBag.Labels4 = ObtenerLabelsGrafico4();
            //ViewBag.Data4 = ObtenerDataGrafico4();

            return View();
        }

      //public List<string> ObtenerLabelsGrafico1()
      //  {
      //      string query = "SELECT Categorias.Nombre AS Categoria, SUM(Gastos.Monto) AS MontoTotal " +
      //                     "FROM Gastos " +
      //                     "INNER JOIN Categorias ON Gastos.IdCategoria = Categorias.IdCategoria " +
      //                     "GROUP BY Categorias.Nombre";

      //      List<string> labels = new List<string>();

      //      using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
      //      {
      //          connection.Open();

      //          using (SqlCommand command = new SqlCommand(query, connection))
      //          {
      //              using (SqlDataReader reader = command.ExecuteReader())
      //              {
      //                  while (reader.Read())
      //                  {
      //                      labels.Add(reader["Categoria"].ToString());
      //                  }
      //              }
      //          }
      //      }

      //      return labels;
      //  }

      //  public List<decimal> ObtenerDataGrafico1()
      //  {
      //      string query = "SELECT Categorias.Nombre AS Categoria, SUM(Gastos.Monto) AS MontoTotal " +
      //                     "FROM Gastos " +
      //                     "INNER JOIN Categorias ON Gastos.IdCategoria = Categorias.IdCategoria " +
      //                     "GROUP BY Categorias.Nombre";

      //      List<decimal> data = new List<decimal>();

      //      using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
      //      {
      //          connection.Open();

      //          using (SqlCommand command = new SqlCommand(query, connection))
      //          {
      //              using (SqlDataReader reader = command.ExecuteReader())
      //              {
      //                  while (reader.Read())
      //                  {
      //                      data.Add(Convert.ToDecimal(reader["MontoTotal"]));
      //                  }
      //              }
      //          }
      //      }

      //      return data;
      //  }


      //  public List<string> ObtenerLabelsGrafico2()
      //  {
      //      string query = "SELECT Categorias.Nombre AS Categoria, SUM(Ingresos.Monto) AS MontoTotal " +
      //                     "FROM Ingresos " +
      //                     "INNER JOIN Categorias ON Ingresos.IdCategoria = Categorias.IdCategoria " +
      //                     "GROUP BY Categorias.Nombre";

      //      List<string> labels = new List<string>();

      //      using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
      //      {
      //          connection.Open();

      //          using (SqlCommand command = new SqlCommand(query, connection))
      //          {
      //              using (SqlDataReader reader = command.ExecuteReader())
      //              {
      //                  while (reader.Read())
      //                  {
      //                      labels.Add(reader["Categoria"].ToString());
      //                  }
      //              }
      //          }
      //      }

      //      return labels;
      //  }


      //  public List<decimal> ObtenerDataGrafico2()
      //  {
      //      string query = "SELECT Categorias.Nombre AS Categoria, SUM(Ingresos.Monto) AS MontoTotal " +
      //                     "FROM Ingresos " +
      //                     "INNER JOIN Categorias ON Ingresos.IdCategoria = Categorias.IdCategoria " +
      //                     "GROUP BY Categorias.Nombre";

      //      List<decimal> data = new List<decimal>();

      //      using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
      //      {
      //          connection.Open();

      //          using (SqlCommand command = new SqlCommand(query, connection))
      //          {
      //              using (SqlDataReader reader = command.ExecuteReader())
      //              {
      //                  while (reader.Read())
      //                  {
      //                      data.Add(Convert.ToDecimal(reader["MontoTotal"]));
      //                  }
      //              }
      //          }
      //      }

      //      return data;
      //  }


      //  public List<string> ObtenerLabelsGrafico3()
      //  {
      //      string query = "SELECT DATEPART(MONTH, FechaIngreso) AS Mes, SUM(Monto) AS MontoTotal " +
      //                    "FROM Ingresos " +
      //                    "GROUP BY DATEPART(MONTH, FechaIngreso)";

      //      List<string> labels = new List<string>();

      //      using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
      //      {
      //          connection.Open();

      //          using (SqlCommand command = new SqlCommand(query, connection))
      //          {
      //              using (SqlDataReader reader = command.ExecuteReader())
      //              {
      //                  while (reader.Read())
      //                  {
      //                      int mes = Convert.ToInt32(reader["Mes"]);
      //                      labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes));
      //                  }
      //              }
      //          }
      //      }

      //      return labels;
      //  }

      //  public List<decimal> ObtenerDataGrafico3()
      //  {
      //      string query = "SELECT DATEPART(MONTH, FechaIngreso) AS Mes, SUM(Monto) AS MontoTotal " +
      //                    "FROM Ingresos " +
      //                    "GROUP BY DATEPART(MONTH, FechaIngreso)";

      //      List<decimal> data = new List<decimal>();

      //      using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
      //      {
      //          connection.Open();

      //          using (SqlCommand command = new SqlCommand(query, connection))
      //          {
      //              using (SqlDataReader reader = command.ExecuteReader())
      //              {
      //                  while (reader.Read())
      //                  {
      //                      data.Add(Convert.ToDecimal(reader["MontoTotal"]));
      //                  }
      //              }
      //          }
      //      }

      //      return data;
      //  }
      //  public List<string> ObtenerLabelsGrafico4()
      //  {
      //      string query = "SELECT DATEPART(MONTH, FechaGastos) AS Mes, SUM(Monto) AS MontoTotal " +
      //                    "FROM Gastos " +
      //                    "GROUP BY DATEPART(MONTH, FechaGastos)";

      //      List<string> labels = new List<string>();

      //      using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
      //      {
      //          connection.Open();

      //          using (SqlCommand command = new SqlCommand(query, connection))
      //          {
      //              using (SqlDataReader reader = command.ExecuteReader())
      //              {
      //                  while (reader.Read())
      //                  {
      //                      int mes = Convert.ToInt32(reader["Mes"]);
      //                      labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes));
      //                  }
      //              }
      //          }
      //      }

      //      return labels;
      //  }


      //  public List<decimal> ObtenerDataGrafico4()
      //  {
      //      string query = "SELECT DATEPART(MONTH, FechaGastos) AS Mes, SUM(Monto) AS MontoTotal " +
      //                    "FROM Gastos " +
      //                    "GROUP BY DATEPART(MONTH, FechaGastos)";

      //      List<decimal> data = new List<decimal>();

      //      using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
      //      {
      //          connection.Open();

      //          using (SqlCommand command = new SqlCommand(query, connection))
      //          {
      //              using (SqlDataReader reader = command.ExecuteReader())
      //              {
      //                  while (reader.Read())
      //                  {
      //                      data.Add(Convert.ToDecimal(reader["MontoTotal"]));
      //                  }
      //              }
      //          }
      //      }

      //      return data;
      //  }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}