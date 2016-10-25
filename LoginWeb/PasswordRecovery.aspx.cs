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
                mail.Body = "Abbiamo impostato la password temporanea per l'utente " + PasswordRecovery1.UserName + "\nPassword: " + password +"\n"
                            + "Per cambiarla effettua il login con la password temporanea e vai nella sezione cambia password.";

                smptServer.Port = 587;
                smptServer.Credentials = new System.Net.NetworkCredential("danale2@hotmail.it","Hamsik9498");
                smptServer.EnableSsl = true;
                smptServer.Send(mail);
            }
            catch (Exception)
            {

            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string passTemp = System.Web.Security.Membership.GeneratePassword(7, 2);
            SqlConnection conn = new SqlConnection("Data Source=DDIFRATTM;Initial Catalog=Ristorante;Integrated Security=True");
            conn.Open();
            SqlCommand comando = new SqlCommand("",conn);
            comando.CommandText = "select email from Account where username = '" + PasswordRecovery1.UserName + "'";
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            string email = (string)reader["email"];
            var crypto = new SimpleCrypto.PBKDF2();
            string encriptPass = crypto.Compute(passTemp);
            conn.Close();
            conn.Open();
            comando = new SqlCommand("", conn);
            comando.CommandText = "update Account set password='" + encriptPass + "', passwordSalt ='" + 
                                   crypto.Salt + "' where username ='" + PasswordRecovery1.UserName + "'";
            comando.ExecuteNonQuery();
            conn.Close();
            sendMail(email, passTemp);
            Response.Redirect("Default.aspx");
        }
    }
}