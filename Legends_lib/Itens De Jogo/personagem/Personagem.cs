﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class Personagem
    {
        //criar metodo padrão de movimento

        //criar habilidade
        //VIDA ATAQ
        public string Nome { get; set; }
        //  public Movimento Movimento { get; set; }
        public int QuantidadeDEMovimento { get; set; }
        public string Classe { get; set; }
        public Habilidade Habilidade { get; set; }
        public int DimXCasa { get; set; }
        public int DimYCasa { get; set; }
        public int Experiencia { get; set; }
        public int Gold { get; set; }
        /* public void Movimento()
         {


         }*/


    }
}
