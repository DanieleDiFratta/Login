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
    public partial class NewOrdinazione : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("",conn);
            comando.CommandText = "select nome from primi";
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                TableRow riga = new TableRow();
                TableCell nome = new TableCell();
                nome.Text = (string)reader["nome"];
                TableCell quantita = new TableCell();
                DropDownList ddl = new DropDownList();
                ddl.Items.Add("0");
                ddl.Items.Add("1");
                ddl.Items.Add("2");
                ddl.Items.Add("3");
                ddl.Items.Add("4");
                ddl.Items.Add("5");
                quantita.Controls.Add(ddl);
                riga.Cells.Add(nome);
                riga.Cells.Add(quantita);
                Table1.Rows.Add(riga);
            }
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach(TableRow riga in Table1.Rows)
            {
                DropDownList ddl = (DropDownList)riga.Cells[1].Controls[0];
                int quantita = Int32.Parse(ddl.SelectedValue);
                string nomepiatto = riga.Cells[0].Text;
                aggiungiPiatto(nomepiatto, quantita);
            }
            SqlDataSource2.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloPrimi] tp,[Primi] p WHERE tp.idprimo = p.id AND tp.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            //per riazzerare tutti i menù a discesa dopo aver aggiunto i piatti al gridView
            foreach (TableRow riga in Table1.Rows)
            {
                DropDownList ddl = (DropDownList)riga.Cells[1].Controls[0];
                ddl.SelectedIndex = 0;
            }
        }

        private void aggiungiPiatto(string nomepiatto, int quantita)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "select id from primi where nome ='" + nomepiatto + "'";
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            int idPiatto = (int)reader["id"];
            conn.Close();
            conn.Open();
            comando = new SqlCommand("", conn);
            comando.CommandText = "select id from tavolo where numero ='" + RadioButtonList1.SelectedValue + "'";
            reader = comando.ExecuteReader();
            reader.Read();
            int idtavolo = (int)reader["id"];
            conn.Close();
            for (int i = 0; i < quantita; i++)
            {
                conn.Open();
                comando = new SqlCommand("", conn);
                comando.CommandText = "insert into tavoloprimi values('" + idtavolo + "','" + idPiatto + "')";
                comando.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.Visible = false;
            Button2.Visible = false;
            SqlDataSource2.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloPrimi] tp,[Primi] p WHERE tp.idprimo = p.id AND tp.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            int quantità = Int32.Parse(GridView1.SelectedRow.Cells[1].Text);
            for (int i = 1; i <= quantità; i++)
                DropDownList1.Items.Add(i.ToString());
            DropDownList1.Visible = true;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "delete top (" + DropDownList1.SelectedValue + 
                ") from tavoloprimi where idtavolo = (select id from tavolo where numero = " + RadioButtonList1.SelectedValue +
                ") and idprimo = (select id from primi where nome = '" + GridView1.SelectedRow.Cells[2].Text + "')";
            comando.ExecuteNonQuery();
            conn.Close();
            SqlDataSource2.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloPrimi] tp,[Primi] p WHERE tp.idprimo = p.id AND tp.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            DropDownList1.Visible = false;
            Button2.Visible = false;
        }
    }
}