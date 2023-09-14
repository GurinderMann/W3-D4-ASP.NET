using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rubrica
{
    public partial class Contatti : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void aggiungi (object sender, EventArgs e) 
        {
            string fileName = "";

          
            if (FileUpload1.HasFile)
            {
                fileName = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath($"/Content/img/{FileUpload1.FileName}"));
            }

            string connectionString = ConfigurationManager.ConnectionStrings["rubrica"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO CONTATTI VALUES (@Nome, @Cognome, @Indirizzo, @Numero, @Email, @ProfileImg )";
                cmd.Parameters.AddWithValue("Nome", Nome.Text);
                cmd.Parameters.AddWithValue("Cognome", Cognome.Text);
                cmd.Parameters.AddWithValue("Indirizzo", Indirizzo.Text);
                cmd.Parameters.AddWithValue("Numero", Numero.Text);
                cmd.Parameters.AddWithValue("Email", Email.Text);
                cmd.Parameters.AddWithValue("ProfileImg", fileName);

                int inserimentoEffettuato = cmd.ExecuteNonQuery();
                if (inserimentoEffettuato > 0)
                {
                    Label1.Text = "Contatto Aggiunto";
                    Nome.Text = "";
                    Cognome.Text = "";
                    Indirizzo.Text = "";
                    Numero.Text = "";
                    Email.Text = "";
                };    




            }
            catch (Exception ex)
            {
                Response.Write("Errore: " + ex.Message);
            }
            finally
            {
                conn.Close();
                

                
               
            }

        }
    }
}