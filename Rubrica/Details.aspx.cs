using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rubrica
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string connectionString = ConfigurationManager.ConnectionStrings["rubrica"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();
                  
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CONTATTI WHERE idContatto = @IdContatto", conn);
                    cmd.Parameters.AddWithValue("@IdContatto", Request.QueryString["idContatto"]);
                    SqlDataReader sqlData = cmd.ExecuteReader();

                    if (sqlData.Read())
                    {
                        Nome.Text = sqlData["Nome"].ToString();
                        Cognome.Text = sqlData["Cognome"].ToString();
                        Indirizzo.Text = sqlData["Indirizzo"].ToString();
                        Numero.Text = sqlData["Numero"].ToString();
                        Email.Text = sqlData["Email"].ToString();
                     
                    }
                    else
                    {
                        Response.Write("Nessun contatto trovato con l'ID specificato.");
                    }
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

        protected void Modifica(object sender, EventArgs e)
        {
            string fileName = "";

            if (FileUpload1.HasFile)
            {
                fileName = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath($"/Content/img/{FileUpload1.FileName}"));
            }

            string connectionString = ConfigurationManager.ConnectionStrings["rubrica"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE CONTATTI SET Nome = @Nome, Cognome = @Cognome, Indirizzo = @Indirizzo, Numero = @Numero, Email = @Email, ProfileImg = @ProfileImg WHERE IdContatto = @IdContatto", conn);

                    cmd.Parameters.AddWithValue("@Nome", Nome.Text);
                    cmd.Parameters.AddWithValue("@Cognome", Cognome.Text);
                    cmd.Parameters.AddWithValue("@Indirizzo", Indirizzo.Text);
                    cmd.Parameters.AddWithValue("@Numero", Numero.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@ProfileImg", fileName);
                    cmd.Parameters.AddWithValue("@IdContatto", Request.QueryString["idContatto"]);

                    
                }
                catch (Exception ex)
                {
                    Response.Write("Errore: " + ex.Message);
                }
                finally
                {
                    conn.Close();

                    Response.Redirect($"Contatti");
                }
            }
        }

        protected void Elimina(object sender, EventArgs e) 
        {
            string connectionString = ConfigurationManager.ConnectionStrings["rubrica"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))

                try
                {
                    conn.Open();
                                    
                                 
                    SqlCommand cmd = new SqlCommand("DELETE FROM CONTATTI WHERE IdContatto = @IdContatto", conn);
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@IdContatto", Request.QueryString["idContatto"]);

                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    Response.Write("Errore: " + ex.Message);
                }
                finally
                {
                    conn.Close();

                   Response.Redirect($"Contatti");
                }
        }
    }
}