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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TPVdinámico
{
    public partial class Form1 : Form
    {

        String[] nombres = { "chirimoya", "ciruela", "fresa", "kiwi", "mandarina", "melocoton", "melon", "naranja", "nectarina", "papaya", "peras", "piña", "peras", "piña", "platanos", "pomelos", "prunus", "sandias" };

        String[] precios = { "1,25", "2,75", "3,25", "1,50", "2,75", "3,25", "1", "2", "3", "1", "2", "3", "1", "2", "3", "1", "2", "3" };

        decimal total = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //generar los botones y campos de texto

            for (int a = 0; a < 15; a++)
            {
                Button btnX = new Button();                
                btnX.Name = Convert.ToString(a);
                btnX.Text = nombres[a];
                btnX.Image = System.Drawing.Image.FromFile(@"imagenes\" + btnX.Text + ".PNG");
                btnX.BackgroundImageLayout = ImageLayout.Zoom;
                btnX.Tag = precios[a];
                btnX.Size = new Size(65,65);
                btnX.Location = new Point(a * 75, 25);

                TextBox txtX = new TextBox();
                txtX.Enabled = false;
                txtX.Name = Convert.ToString(a);
                txtX.Text = precios[a];
                txtX.Size = new Size(70, 70);
                txtX.Location = new Point(a * 75, 25);

                flowLayoutPanel1.Controls.Add(btnX);
                flowLayoutPanel1.Controls.Add(txtX);
                btnX.Click += btnXClick;
            }
        }

        private void btnXClick(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;

            String peso = Interaction.InputBox("Introduce kgs de " + btnX.Text, "TPV", "0");

            String precio = btnX.Tag.ToString();

            String[] fila = { btnX.Text,
                                precio,
                                peso,
                                (Convert.ToDecimal(peso) * Convert.ToDecimal(precio)).ToString()};

            dataGridView1.Rows.Add(fila);

            total += Convert.ToDecimal(fila[3]);

            label1.Text = total.ToString();
        }

        private void buttonNuevoCliente_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            total = 0;
            label1.Text = total.ToString();
            dataGridView1.Rows.Clear();
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            generarPDF();
        }

        private void generarPDF()
        {
            //DataGridView----->PDF(utiliza la librería iTextSharp)

        //Crear Tabla iTextSharp  desde una tabla de datos (datagridView)
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

            //padding
            pdfTable.DefaultCell.Padding = 3;

            //ancho que va a ocupar la tabla en el pdf
            pdfTable.WidthPercentage = 30;

            //alineación
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            //borde de las tablas
            pdfTable.DefaultCell.BorderWidth = 1;
            //Añadir fila de cabecera
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //añadir filas
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                    catch { pdfTable.AddCell("total"); }
                }
            }

            //Exportar a pdf (ruta por defect
            string folderPath = "C:\\Users\\David\\Desktop\\Tickets";

            //si no existe el directoria se crea
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "\\ticket.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }
    }
}
    