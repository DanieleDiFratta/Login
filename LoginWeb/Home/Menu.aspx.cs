using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWeb
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CaricaPiatto("primi",nomePrimo,prezzoPrimo);
            CaricaPiatto("secondi", nomeSecondo, prezzoSecondo);
            CaricaPiatto("bibite", nomeBibita, prezzoBibita);

            decimal totale = Decimal.Parse(prezzoPrimo.Text) + Decimal.Parse(prezzoSecondo.Text) + Decimal.Parse(prezzoBibita.Text);
            totale *= 0.9M;
            totale = Decimal.Round(totale, 2);
            totaleLabel.Text = totale.ToString();
        }

        private void CaricaPiatto(string tipo, Label nome, Label prezzo)
        {
            List<string> nomepiatto = new List<string>();
            List<decimal> prezzopiatto = new List<decimal>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "select * from " + tipo;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                nomepiatto.Add((string)reader["nome"]);
                prezzopiatto.Add((decimal)reader["prezzo"]);
            }
            conn.Close();
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    nome.Text = nomepiatto[0];
                    prezzo.Text = prezzopiatto[0].ToString();
                    break;
                case DayOfWeek.Monday:
                    nome.Text = nomepiatto[1];
                    prezzo.Text = prezzopiatto[1].ToString();
                    break;
                case DayOfWeek.Tuesday:
                    nome.Text = nomepiatto[2];
                    prezzo.Text = prezzopiatto[2].ToString();
                    break;
                case DayOfWeek.Wednesday:
                    nome.Text = nomepiatto[3];
                    prezzo.Text = prezzopiatto[3].ToString();
                    break;
                case DayOfWeek.Thursday:
                    nome.Text = nomepiatto[4];
                    prezzo.Text = prezzopiatto[4].ToString();
                    break;
                case DayOfWeek.Friday:
                    nome.Text = nomepiatto[5];
                    prezzo.Text = prezzopiatto[5].ToString();
                    break;
                case DayOfWeek.Saturday:
                    nome.Text = nomepiatto[6];
                    prezzo.Text = prezzopiatto[6].ToString();
                    break;
            }
        }
    }
}