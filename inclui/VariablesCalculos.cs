﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inclui.CompAndCalcDates
{
    class VariablesCalculos
    {
        private static string RutaEspannol = @"..\..\lenguajes\espannol\Calculos_ES.txt";
        private static string RutaIngles = @"..\..\lenguajes\espannol\Calculos_EN.txt";
        private static readonly List<string> Mensajes = ExtraerFichero.ExtraerContenidoFichero(RutaEspannol);

        public static string PrimerConcatenado(int DiferenciasAnnios,int DiferenciaDias)
        {
            string concatenado = Mensajes[0] + DiferenciasAnnios + Mensajes[1] + DiferenciaDias;
            return concatenado;
        }

        public static string SegundoConcatenado(int DiferenciasAnnios, int DiferenciaDias)
        {
            string concatenado = Mensajes[2] + DiferenciasAnnios + Mensajes[3] + DiferenciaDias;
            return concatenado;
        }
    }
}
