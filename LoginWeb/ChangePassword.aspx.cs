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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DDIFRATTM;Initial Catalog=Ristorante;Integrated Security=True");
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "select password,passwordsalt from account where username='" + Context.User.Identity.Name + "'";
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            string pass = (string)reader["password"];
            string salt = (string)reader["passwordsalt"];
            conn.Close();
            var crypto = new SimpleCrypto.PBKDF2();
            string encr = crypto.Compute(ChangePassword1.CurrentPassword, salt);
            if (pass == crypto.Compute(ChangePassword1.CurrentPassword, salt))
            {
                conn.Open();
                comando.CommandText = "update Account set password='" + crypto.Compute(ChangePassword1.NewPassword) + "', passwordSalt ='" +
                                   crypto.Salt + "' where username ='" + Context.User.Identity.Name + "'";
                comando.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Default.aspx");
            }
            else
            {
                errorLabel.Text = "Password corrente sbagliata";
                errorLabel.Visible = true;
            }
        }
    }
}