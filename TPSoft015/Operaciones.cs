using System;

namespace TPSoft015
{
    public class Operaciones
    {
        public int promedio(short n1, short n2, short n3)
        {
            double promInit = (n1 + n2 + n3) / 3;
            int promFinal = (int)Math.Round(promInit, MidpointRounding.AwayFromZero);
            return promFinal;
        }

        public string estado(int prom)
        {
            string message;
            if (prom >= 13) message = "Aprovado";
            else message = "Desaprovado";
            return message;
        }

        public int calcEdad(DateTime fechaNacimiento)
        {
            int edad = (short)(DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1);
            return edad;
        }
    }
}

