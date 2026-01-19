using Mini_CRM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mini_CRM.Controllers
{
    public class PagesController : Controller
    {//Şirketleri listeleyen denetleyici. İlerleyen süreçte CompaniesController a alınabilir.
        string connStr = ConfigurationManager.ConnectionStrings["MiniCRMConnection"].ConnectionString;

        public ActionResult companylist() { 
        
 
                List<Company> companies = new List<Company>();

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT CompanyId, CompanyName, Responsible, Telephone, Email FROM company_table",
                        con
                    );

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        companies.Add(new Company
                        {
                            CompanyId = Convert.ToInt32(dr["CompanyId"]),
                            CompanyName = dr["CompanyName"].ToString(),
                            Responsible = dr["Responsible"].ToString(),
                            Telephone = dr["Telephone"].ToString(),
                            Email = dr["Email"].ToString(),
                        });
                    }
                }

                return View("~/Views/Pages/companylist.cshtml", companies);
            }
        
        
        public ActionResult create()
        {
            return View();
        }
        public ActionResult edit()
        {
            return View();
        }


        public ActionResult meetings()
        {
            return View();
        }
    }

}