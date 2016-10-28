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
            CaricaPiatti("primi",Table1);
            CaricaPiatti("secondi", Table2);
            CaricaPiatti("bibite", Table3);
        }

        private void CaricaPiatti(string tipo,Table tabella)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "select nome from " + tipo;
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
                tabella.Rows.Add(riga);
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
                aggiungiPiatto(nomepiatto, quantita,"primi");
            }
            SqlDataSource2.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloPrimi] tp,[Primi] p WHERE tp.idprimo = p.id AND tp.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            //per riazzerare tutti i menù a discesa dopo aver aggiunto i piatti al gridView
            foreach (TableRow riga in Table1.Rows)
            {
                DropDownList ddl = (DropDownList)riga.Cells[1].Controls[0];
                ddl.SelectedIndex = 0;
            }
        }

        private void aggiungiPiatto(string nomepiatto, int quantita,string tipo)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "select id from " + tipo + " where nome ='" + nomepiatto + "'";
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
                comando.CommandText = "insert into tavolo" + tipo + " values('" + idtavolo + "','" + idPiatto + "')";
                comando.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.Visible = false;
            Button2.Visible = false;
            DropDownList2.Visible = false;
            Button4.Visible = false;
            DropDownList3.Visible = false;
            Button6.Visible = false;
            SqlDataSource2.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloPrimi] tp,[Primi] p WHERE tp.idprimo = p.id AND tp.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            SqlDataSource4.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloSecondi] ts,[Secondi] s WHERE ts.idsecondo = s.id AND ts.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            SqlDataSource6.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloBibite] tb,[Bibite] b WHERE tb.idbibita = b.id AND tb.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            foreach (TableRow riga in Table2.Rows)
            {
                DropDownList ddl = (DropDownList)riga.Cells[1].Controls[0];
                int quantita = Int32.Parse(ddl.SelectedValue);
                string nomepiatto = riga.Cells[0].Text;
                aggiungiPiatto(nomepiatto, quantita,"secondi");
            }
            SqlDataSource4.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloSecondi] ts,[Secondi] s WHERE ts.idsecondo = s.id AND ts.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            //per riazzerare tutti i menù a discesa dopo aver aggiunto i piatti al gridView
            foreach (TableRow riga in Table2.Rows)
            {
                DropDownList ddl = (DropDownList)riga.Cells[1].Controls[0];
                ddl.SelectedIndex = 0;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            foreach (TableRow riga in Table3.Rows)
            {
                DropDownList ddl = (DropDownList)riga.Cells[1].Controls[0];
                int quantita = Int32.Parse(ddl.SelectedValue);
                string nomepiatto = riga.Cells[0].Text;
                aggiungiPiatto(nomepiatto, quantita, "bibite");
            }
            SqlDataSource6.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloBibite] tb,[Bibite] b WHERE tb.idbibita = b.id AND tb.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            //per riazzerare tutti i menù a discesa dopo aver aggiunto i piatti al gridView
            foreach (TableRow riga in Table3.Rows)
            {
                DropDownList ddl = (DropDownList)riga.Cells[1].Controls[0];
                ddl.SelectedIndex = 0;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "delete top (" + DropDownList2.SelectedValue +
                ") from tavolosecondi where idtavolo = (select id from tavolo where numero = " + RadioButtonList1.SelectedValue +
                ") and idsecondo = (select id from secondi where nome = '" + GridView2.SelectedRow.Cells[2].Text + "')";
            comando.ExecuteNonQuery();
            conn.Close();
            SqlDataSource4.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloSecondi] ts,[Secondi] s WHERE ts.idsecondo = s.id AND ts.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            DropDownList2.Visible = false;
            Button4.Visible = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "delete top (" + DropDownList2.SelectedValue +
                ") from tavolobibite where idtavolo = (select id from tavolo where numero = " + RadioButtonList1.SelectedValue +
                ") and idbibita = (select id from bibite where nome = '" + GridView3.SelectedRow.Cells[2].Text + "')";
            comando.ExecuteNonQuery();
            conn.Close();
            SqlDataSource6.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloBibite] tb,[Bibite] b WHERE tb.idbibita = b.id AND tb.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            DropDownList3.Visible = false;
            Button6.Visible = false;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            int quantità = Int32.Parse(GridView2.SelectedRow.Cells[1].Text);
            for (int i = 1; i <= quantità; i++)
                DropDownList2.Items.Add(i.ToString());
            DropDownList2.Visible = true;
            Button4.Visible = true;
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            int quantità = Int32.Parse(GridView3.SelectedRow.Cells[1].Text);
            for (int i = 1; i <= quantità; i++)
                DropDownList3.Items.Add(i.ToString());
            DropDownList3.Visible = true;
            Button6.Visible = true;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand comando = new SqlCommand("", conn);
            comando.CommandText = "delete from tavoloprimi where idtavolo = " + RadioButtonList1.SelectedValue;
            comando.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            comando = new SqlCommand("", conn);
            comando.CommandText = "delete from tavolosecondi where idtavolo = " + RadioButtonList1.SelectedValue;
            comando.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            comando = new SqlCommand("", conn);
            comando.CommandText = "delete from tavolobibite where idtavolo = " + RadioButtonList1.SelectedValue;
            comando.ExecuteNonQuery();
            conn.Close();
            contoLabel.Visible = false;
            SqlDataSource2.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloPrimi] tp,[Primi] p WHERE tp.idprimo = p.id AND tp.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            SqlDataSource4.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloSecondi] ts,[Secondi] s WHERE ts.idsecondo = s.id AND ts.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
            SqlDataSource6.SelectCommand = "SELECT count([nome]) as quantità,nome FROM[TavoloBibite] tb,[Bibite] b WHERE tb.idbibita = b.id AND tb.idtavolo = " + RadioButtonList1.SelectedValue + " GROUP BY [nome] ORDER BY[nome]";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            decimal conto = 0m;
            conto += ContoPiatto("primi",GridView1);
            conto += ContoPiatto("secondi", GridView2);
            conto += ContoPiatto("bibite", GridView3);
            contoLabel.Text = "Il conto da pagare è: " + conto;
            contoLabel.Visible = true;
        }

        private decimal ContoPiatto(string tipo,GridView grid)
        {
            decimal conto = 0m;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            foreach (GridViewRow grw in grid.Rows)
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("", conn);
                comando.CommandText = "select prezzo from " + tipo + " where nome = '" + grw.Cells[2].Text + "'";
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                    conto += (decimal)reader["prezzo"]*Decimal.Parse(grw.Cells[1].Text);
                conn.Close();
            }
            return conto;
        }
    }
}