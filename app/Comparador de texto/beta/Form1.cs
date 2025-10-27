using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beta
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botonValidar_Click(object sender, EventArgs e)
        {
            string madreTexto = textoMadre.Text.Trim();
            string validarTexto = textoValidar.Text.Trim();

            string textoCorregido = AplicarFormato(madreTexto, validarTexto, out string reporteErrores);

            textoValidado.Text = textoCorregido;
            errores.Text = reporteErrores;
        }

        private string AplicarFormato(string madre, string validar, out string erroresDetectados)
        {
            List<string> bloquesMadre = SepararPorCaracteresEspeciales(madre, out List<string> separadoresMadre);
            List<string> bloquesValidar = SepararPorCaracteresEspeciales(validar, out List<string> separadoresValidar);

            List<string> resultado = new List<string>();
            List<string> errores = new List<string>();

            for (int i = 0; i < bloquesMadre.Count; i++)
            {
                string bloqueValidado = (i < bloquesValidar.Count) ? bloquesValidar[i] : "";
                resultado.Add(bloqueValidado);

                if (i < separadoresMadre.Count)
                {
                    string sepMadre = separadoresMadre[i];
                    string sepValidar = (i < separadoresValidar.Count) ? separadoresValidar[i] : "";

                    if (sepMadre != sepValidar)
                    {
                        errores.Add($"esperado '{sepMadre}', encontrado '{sepValidar}'");
                    }

                    resultado.Add(sepMadre); 
                }
            }

            erroresDetectados = errores.Count > 0 ? string.Join(Environment.NewLine, errores) : "Sin errores de formato.";
            return string.Join("", resultado);
        }

        private List<string> SepararPorCaracteresEspeciales(string texto, out List<string> separadores)
        {
            List<string> bloques = new List<string>();
            separadores = new List<string>();

            StringBuilder bloqueActual = new StringBuilder();
            StringBuilder separadorActual = new StringBuilder();
            bool enSeparador = false;

            foreach (char c in texto)
            {
                if (EsCaracterEspecial(c))
                {
                    if (!enSeparador && bloqueActual.Length > 0)
                    {
                        bloques.Add(bloqueActual.ToString());
                        bloqueActual.Clear();
                    }
                    enSeparador = true;
                    separadorActual.Append(c);
                }
                else
                {
                    if (enSeparador)
                    {
                        separadores.Add(separadorActual.ToString());
                        separadorActual.Clear();
                        enSeparador = false;
                    }
                    bloqueActual.Append(c);
                }
            }

            if (bloqueActual.Length > 0)
                bloques.Add(bloqueActual.ToString());
            if (separadorActual.Length > 0)
                separadores.Add(separadorActual.ToString());

            return bloques;
        }

        private bool EsCaracterEspecial(char c)
        {
            return !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c);
        }

    }
}