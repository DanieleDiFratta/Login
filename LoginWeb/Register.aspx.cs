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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(passwordInputText.Value != confermaPasswordInputText.Value)
            {
                errorLabel.Text = "Le password non coincidono";
                errorLabel.Visible = true;
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=DDIFRATTM;Initial Catalog=Ristorante;Integrated Security=True");
                conn.Open();
                SqlCommand comando = new SqlCommand("", conn);
                string userID = Guid.NewGuid().ToString();
                comando.CommandText = "insert into Account values('" + userID + "','" +
                                      usernameInputText.Value + "','" + passwordInputText.Value + "','"
                                      + "ciao" + "','" + emailInputText.Text + "')";
                try
                {
                    comando.ExecuteNonQuery();
                    FormsAuthentication.SetAuthCookie(usernameInputText.Value, true);
                    conn.Close();
                    Response.Redirect("Default.aspx");
                }
                catch(Exception)
                {
                    errorLabel.Text = "email già in uso";
                    errorLabel.Visible = true;
                }
            }
        }
    }
}