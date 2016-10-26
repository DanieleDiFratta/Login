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
    public partial class AddPrimo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();
                SqlCommand comando = new SqlCommand("", conn);
                comando.CommandText = "insert into primi values ('" + nomebox.Text + "','" + prezzobox.Text.Replace(',','.') + "')";
                comando.ExecuteNonQuery();
                conn.Close();
                successLabel.Visible = true;
                successLabel.Text = "Piatto aggiunto correttamente";
                RangeValidator1.Visible = false;
            }
            catch (Exception ex)
            {
                successLabel.Visible = true;
                successLabel.Text = ex.ToString();
            }
        }
    }
}