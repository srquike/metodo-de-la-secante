using System;
using System.Collections.Generic;
using System.Text;

namespace metodo_de_la_secante
{
    class Iteracion
    {
        private double error;

        public int I { get; set; }
        public double Xi { get; set; }
        public double Xime1 { get; set; }
        public double Xima1 { get; set; }
        public double Fxi { get; set; }
        public double Fxime1 { get; set; }
        public double Error { get => Math.Round(error, 3); set => error = value; }
    }
}
