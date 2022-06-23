using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSoft015
{
    public class Alumnos
    {
        private int id;
        private string codigo;
        private string nombre;
        private string apa;
        private string ama;
        private string anotacion;
        private int nota1;
        private int nota2;
        private int nota3;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apa { get => apa; set => apa = value; }
        public string Ama { get => ama; set => ama = value; }
        public string Anotacion { get => anotacion; set => anotacion = value; }
        public int Nota1 { get => nota1; set => nota1 = value; }
        public int Nota2 { get => nota2; set => nota2 = value; }
        public int Nota3 { get => nota3; set => nota3 = value; }
    }
}
