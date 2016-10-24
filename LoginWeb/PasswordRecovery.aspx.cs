using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWeb
{
    public partial class PasswordRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void sendMail(string email, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smptServer = new SmtpClient("smtp.live.com");

                mail.From = new MailAddress("danale2@hotmail.it");
                mail.To.Add(email);
                mail.Subject = "Password Smarrita";
                mail.Body = "La password per l'utente " + PasswordRecovery1.UserName + " è " + password;

                smptServer.Port = 587;
                smptServer.Credentials = new System.Net.NetworkCredential("danale2@hotmail.it","");
                smptServer.EnableSsl = true;
                smptServer.Send(mail);
            }
            catch (Exception)
            {

            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DDIFRATTM;Initial Catalog=Ristorante;Integrated Security=True");
            conn.Open();
            SqlCommand comando = new SqlCommand("",conn);
            comando.CommandText = "select email,password from Account where username = '" + PasswordRecovery1.UserName + "'";
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            string email = (string)reader["email"];
            string password = (string)reader["password"];
            sendMail(email, password);
            Response.Redirect("Default.aspx");
        }
    }
}