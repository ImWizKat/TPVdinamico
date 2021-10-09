using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVdinámico
{
    class claseFruta
    {

        int id;
        String nombre, procedencia;
        decimal precio;
        Decimal stock;
        byte[] imagen;

        public claseFruta() { }

        public claseFruta(int id, string nombre, string procedencia, decimal precio, int stock, byte[] imagen)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Procedencia = procedencia;
            this.Precio = precio;
            this.Stock = stock;
            this.Imagen = imagen;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Procedencia { get => procedencia; set => procedencia = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public decimal Stock { get => stock; set => stock = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}
