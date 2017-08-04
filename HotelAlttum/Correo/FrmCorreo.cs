using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral.Correo
{
    public partial class FrmCorreo : Form
    {
        public string contrato;
        public FrmCorreo()
        {
            InitializeComponent();
        }

        
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Montamos la estructura básica del mensaje...
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("desarrolladorab@alttum.land");
                mail.To.Add(txtPara.Text);
                mail.To.Add("coordinadoradminab@alttum.land");
                mail.Subject = txtAsunto.Text;

                // Creamos la vista para clientes que
                // sólo pueden acceder a texto plano...

                string text = txtContenido.Text;

                AlternateView plainView =
                    AlternateView.CreateAlternateViewFromString(text,
                                            Encoding.UTF8,
                                            MediaTypeNames.Text.Plain);


                // Ahora creamos la vista para clientes que 
                // pueden mostrar contenido HTML...

                string html = "<p>" + txtContenido.Text + "</p>" +
                              "<img src='cid:imagen' />";

                AlternateView htmlView =
                    AlternateView.CreateAlternateViewFromString(html,
                                            Encoding.UTF8,
                                            MediaTypeNames.Text.Html);

                //// Creamos el recurso a incrustar.

                //LinkedResource img =
                //    new LinkedResource(@"C:\Firma.jpg",
                //                        MediaTypeNames.Image.Jpeg);
                //img.ContentId = "imagen";

                //// Lo incrustamos en la vista HTML...

                //htmlView.LinkedResources.Add(img);

                // Por último, vinculamos ambas vistas al mensaje...

                mail.AlternateViews.Add(plainView);
                mail.AlternateViews.Add(htmlView);

                // Y lo enviamos a través del servidor SMTP...

                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 25);
                cliente.EnableSsl = true;
                cliente.Credentials = new NetworkCredential("desarrolladorab@alttum.land", "E$teban07052011.");
                cliente.Send(mail);
                MessageBox.Show("Correo enviado exitosamente.", "¡EXITO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente enviando el mensaje: "+ex.Message, "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCorreo_Load(object sender, EventArgs e)
        {
            txtAsunto.Text = "Corrección de personas que comisionan contrato " + contrato;
        }
        
    }
}
