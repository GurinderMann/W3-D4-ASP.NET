using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Rubrica
{
    public partial class ListaContatti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["rubrica"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM CONTATTI ORDER BY NOME", conn);

                SqlDataReader sqlData;
                List<Contatto> ListaContatti = new List<Contatto>();

                sqlData = cmd.ExecuteReader();
                while (sqlData.Read())
                {
                    Contatto contatto = new Contatto();
                    contatto.Nome = sqlData["Nome"].ToString();
                    contatto.Cognome = sqlData["Cognome"].ToString();
                    contatto.Indirizzo = sqlData["Indirizzo"].ToString();
                    contatto.Numero = Convert.ToInt32(sqlData["Numero"]);
                    contatto.Email = sqlData["Email"].ToString();
                    contatto.ProfileImg = sqlData["ProfileImg"].ToString();
                    contatto.IdContatto = Convert.ToInt32(sqlData["IdContatto"]);

                    ListaContatti.Add(contatto);
                }
                Repeater1.DataSource = ListaContatti;
                Repeater1.DataBind();
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

    public class Contatto
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public int Numero { get; set; }
        public string Email { get; set; }
        public string ProfileImg { get; set; }
        public int IdContatto { get; set; }


    }
}