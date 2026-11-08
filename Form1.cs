using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Calculadora_Pro : Form
    {
        private double valor1 = 0;
        private double valor2 = 0;
        private string operador = "";
        private bool nuevaOperacion = false;

        public Calculadora_Pro()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            bttn0.Click += (s, e) => AgregarNumero("0");
            bttn1.Click += (s, e) => AgregarNumero("1");
            bttn2.Click += (s, e) => AgregarNumero("2");
            bttn3.Click += (s, e) => AgregarNumero("3");
            bttn4.Click += (s, e) => AgregarNumero("4");
            bttn5.Click += (s, e) => AgregarNumero("5");
            bttn6.Click += (s, e) => AgregarNumero("6");
            bttn7.Click += (s, e) => AgregarNumero("7");
            bttn8.Click += (s, e) => AgregarNumero("8");
            bttn9.Click += (s, e) => AgregarNumero("9");
            bttnPunto.Click += bttnPunto_Click;
        }

        private void AgregarNumero(string numero)
        {
            if (txtPantalla.Text == "0" || nuevaOperacion)
            {
                txtPantalla.Text = numero;
                nuevaOperacion = false;
            }
            else
            {
                txtPantalla.Text += numero;
            }
        }
        private void BtnPunto_Click(object sender, EventArgs e)
        {
            if (!txtPantalla.Text.Contains("."))
            {
                txtPantalla.Text += ".";
            }
        }
        public void EstablecerOperador(string op)
        {
            if (double.TryParse(txtPantalla.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out valor1))
            {
                operador = op;
                nuevaOperacion = true;
            }
        }

        public void CalcularResultado()
        {
            // Usamos CultureInfo.InvariantCulture para que acepte el punto decimal sin importar el idioma de la PC
            if (double.TryParse(txtPantalla.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out valor2))
            {
                double resultado = 0;

                switch (operador)
                {
                    case "+": resultado = valor1 + valor2; break;
                    case "-": resultado = valor1 - valor2; break;
                    case "X": case "*": resultado = valor1 * valor2; break;
                    case "/":
                        if (valor2 != 0) resultado = valor1 / valor2;
                        else { MessageBox.Show("No se puede dividir por cero."); Limpiar(); return; }
                        break;
                }

                // Al convertir el resultado a texto, también usamos InvariantCulture para que muestre el punto (.) y no una coma
                txtPantalla.Text = resultado.ToString(System.Globalization.CultureInfo.InvariantCulture);
                valor1 = resultado;
                nuevaOperacion = true;
            }
        }

        private void Limpiar()
        {
            txtPantalla.Text = "0";
            valor1 = 0;
            valor2 = 0;
            operador = "";
            nuevaOperacion = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPantalla.Text = "0";
            txtPantalla.TextAlign = HorizontalAlignment.Right;
        }

        private void bttnSumar_Click(object sender, EventArgs e)
        {
            EstablecerOperador("+");
        }

        private void bttnRestar_Click(object sender, EventArgs e)
        {
            EstablecerOperador("-");
        }

        private void bttnMultiplicar_Click(object sender, EventArgs e)
        {
            EstablecerOperador("X");
        }

        private void bttnDividir_Click(object sender, EventArgs e)
        {
            EstablecerOperador("/");
        }

        private void bttnIgual_Click(object sender, EventArgs e)
        {
            CalcularResultado();
        }

        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void bttnBorrar_Click(object sender, EventArgs e)
        {
            txtPantalla.Text = "0";
        }

        private void bttnPunto_Click(object sender, EventArgs e)
        {
            if (!txtPantalla.Text.Contains("."))
            {
                if (txtPantalla.Text == "" || nuevaOperacion)
                {
                    txtPantalla.Text = "0.";
                    nuevaOperacion = false;
                }
                else
                {
                    txtPantalla.Text += ".";
                }
            }
        }
    }
}