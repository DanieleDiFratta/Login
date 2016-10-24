using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DDIFRATTM;Initial Catalog=Ristorante;Integrated Security=True");
            conn.Open();
            SqlCommand comando = new SqlCommand("select username,password from Account where username='" + Login1.UserName + "'", conn);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            string pass ="";
            try
            {
                pass = (string)reader["Password"];
            }
            catch(Exception)
            {
                Response.Redirect("Default.aspx");
            }
            if (pass != Login1.Password)
                Response.Redirect("Default.aspx");
            else
            {
                FormsAuthentication.SetAuthCookie(Login1.UserName, Login1.RememberMeSet);
                Response.Redirect("Default.aspx");
            }
        }
    }
}