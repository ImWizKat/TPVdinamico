using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TPVdinámico
{
    public partial class TPVFrutas : Form
    {
        claseConectarBD conex = new claseConectarBD();

        List<claseFruta> frutas;

        //este segundo array está para recuperar los datos de stock modificados si el cobro no se realiza
        List<claseFruta> frutasBackup;

        decimal total = 0;

        public TPVFrutas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void buttonNuevoCliente_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            try
            {
                conex.conectarBD();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("No ha sido posible conectar a la base de datos");
                Close();
            }
            groupBox1.Visible = true;
            buttonCargar.Visible = false;

            frutas = conex.ListarFrutas();
            frutasBackup = frutas;

            //generar los botones y ponerles las fotos etc

            for (int a = 0; a < frutas.Count; a++)
            {
                Button btnX = new Button();
                btnX.Name = "boton" + frutas[a].Nombre;
                btnX.Text = frutas[a].Nombre;

                //fotos
                WebClient wc = new WebClient();
                MemoryStream ms = new MemoryStream(frutas[a].Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btnX.Image = imagen;

                //colocarlos y guardar el objeto en su Tag
                btnX.BackgroundImageLayout = ImageLayout.Zoom;
                btnX.Tag = frutas[a];
                btnX.Size = new Size(80, 80);
                btnX.Location = new Point(a * 75, 25);

                //textbox de los precios
                TextBox txtX = new TextBox();
                txtX.Enabled = false;
                txtX.Name = "texto" + frutas[a].Nombre;
                txtX.Text = frutas[a].Precio.ToString();
                txtX.Size = new Size(60, 60);
                txtX.Location = new Point(a * 75, 25);

                panelBotones.Controls.Add(btnX);
                panelBotones.Controls.Add(txtX);
                btnX.Click += btnXClick;
            }
        }

        private void btnXClick(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            try
            {
                String peso = Interaction.InputBox("Introduce kgs de " + btnX.Text, "TPV", "0");

                decimal calculoStock = (((claseFruta)btnX.Tag).Stock) - Convert.ToDecimal(peso);

                claseFruta frutaCompra = (claseFruta)btnX.Tag;

                if (calculoStock < 0)
                {
                    MessageBox.Show("No hay suficiente stock");
                }
                else
                {
                    String precio = frutaCompra.Precio.ToString();
                    String[] fila = { btnX.Text,
                                        precio,
                                        peso,
                                        (Convert.ToDecimal(peso) * Convert.ToDecimal(precio)).ToString(),
                                        frutaCompra.Procedencia.ToString(),
                                        calculoStock.ToString()};

                    tablaCarrito.Rows.Add(fila);
                    total += Convert.ToDecimal(fila[3]);
                    label1.Text = total.ToString();

                    frutaCompra.Stock = calculoStock;

                    foreach (claseFruta fruta in frutas)
                    {
                        if (fruta.Id == frutaCompra.Id)
                        {
                            fruta.Stock = frutaCompra.Stock;
                        }
                    }
                }
            }
            catch (System.FormatException)
            {
                //catch para evitar parar el programa cuando se introduzca algo que no sea un número en el peso
                //seguirá funcionando si introduce números negativos, pero es una forma de quitar frutas ya introducidas, quitando el mismo peso en negativo
                MessageBox.Show("Error, introduce solo números en el peso");
            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            generarPDF();

            groupBox2.Visible = Enabled;
        }

        private void textBoxContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                groupBox3.Visible = true;
                textBoxContraseña.Enabled = false;
            }
        }

        private void textBoxMail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                if (enviarMail())
                {
                    //limpiamos los textbox y avisamos de que se ha enviado

                    textBoxContraseña.Clear();

                    textBoxMail.Clear();

                    MessageBox.Show("Factura enviada");
                    reset();
                }
                else
                {
                    MessageBox.Show("Error al realizar el cobro y enviar el mail");
                    //Si no se produce bien el cobro, el array de frutas se corrige y se deja como estaba
                    frutas = frutasBackup;
                }

            }
        }

        private void generarPDF()
        {
            PdfPTable pdfTable = new PdfPTable(tablaCarrito.ColumnCount);

            //padding
            pdfTable.DefaultCell.Padding = 10;

            //ancho que va a ocupar la tabla en el pdf
            pdfTable.WidthPercentage = 50;

            //alineación
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            //borde de las tablas
            pdfTable.DefaultCell.BorderWidth = 1;

            //Añadir fila de cabecera
            foreach (DataGridViewColumn column in tablaCarrito.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(214, 50, 240);
                pdfTable.AddCell(cell);
            }

            //añadir filas
            foreach (DataGridViewRow row in tablaCarrito.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // if para evitar que salte una excepción cuando llegue al final y esté a null
                    if (cell.Value != null)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                }
            }
            //Añado una fila final también con colorpara el total de precio

            PdfPCell cellTotal = new PdfPCell(new Phrase("Total: " + total + " euros"));
            cellTotal.BackgroundColor = new iTextSharp.text.BaseColor(214, 50, 240);

            for (int i = 0; i < tablaCarrito.Columns.Count; i++)
            {
                if (i == tablaCarrito.Columns.Count - 1) pdfTable.AddCell(cellTotal);
                else pdfTable.AddCell("");
            }

            //Exportar a pdf (ruta por defect
            string folderPath = "C:\\Users\\Kat\\Desktop\\Tickets";

            //si no existe el directoria se crea
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "\\ticket.pdf", FileMode.Create))
            {
                //intento de poner una imagen que he diseñado de fondo
                string imageURL = folderPath + "\\fondoFrutas.jpg";
                iTextSharp.text.Image fondo = iTextSharp.text.Image.GetInstance(imageURL);
                fondo.Alignment = iTextSharp.text.Image.UNDERLYING;

                Document pdfDoc = new Document(PageSize.A3, 0f, 0f, 0f, 0f);

                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(fondo);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }

        private Boolean enviarMail()
        {
            Boolean resultado = false;
            try
            {
                string email = "dcalvoa01@educarex.es";
                string password = textBoxContraseña.Text.ToString();
                var loginInfo = new NetworkCredential(email, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 25);
                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress(textBoxMail.Text.ToString()));
                msg.Subject = "Factura Frutería";
                msg.Body = "Factura de compra de la frutería Paco Manolo";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("C:\\Users\\Kat\\Desktop\\Tickets\\ticket.pdf");
                msg.Attachments.Add(attachment);
                msg.IsBodyHtml = true;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);
                smtpClient.Dispose();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el mail, corrige los datos introducidos");
            }
            return resultado;
        }

        private void reset()
        {
            total = 0;
            label1.Text = total.ToString();
            tablaCarrito.Rows.Clear();
        }

        private void tablaCarrito_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {    
            foreach (claseFruta fruta in frutas)
            {
                if (fruta.Nombre.Equals(e.Row.Cells[0].Value.ToString()))
                {                    
                    fruta.Stock += Convert.ToDecimal(e.Row.Cells[2].Value);
                }
            }
        }
    }
}
