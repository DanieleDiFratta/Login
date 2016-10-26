using System;
using System.Collections.Generic;
using System.Configuration;
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
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("select username,password,passwordsalt from Account where username='" + Login1.UserName + "'", conn);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            string pass="",salt ="";
            var crypto = new SimpleCrypto.PBKDF2();
            try
            {
                pass = (string)reader["Password"];
                salt = (string)reader["PasswordSalt"];
            }
            catch(Exception)
            {
                Response.Redirect("Default.aspx");
            }
            if (pass != crypto.Compute(Login1.Password,salt))
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(Login1.UserName, Login1.RememberMeSet);
                //ritorna alla pagina precedente
                var returnUrl = Request.QueryString["ReturnURL"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    returnUrl = "~/";
                }
                Response.Redirect(returnUrl);
            }
        }
    }
}