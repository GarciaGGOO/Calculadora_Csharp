using System;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace CalculadoraTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Habilita a captura de teclas no formulário
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // Associa o evento KeyPress do formulário
            this.Load += new EventHandler(Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 100; // Intervalo de 100 milissegundos
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop(); // Para o temporizador
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        #region Variáveis
        private string operador = "";
        private double valorAtual = 0;
        private double resultadoFinal = 0;

        #endregion

        #region Botões Números
        private void AdicionarNumero(string numero)
        {
            textBox1.Text += numero;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            AdicionarNumero("0");
            textBox1.Focus(); // Define o foco no TextBox
            textBox1.SelectionStart = textBox1.Text.Length; // Posiciona o cursor no final do texto
            textBox1.SelectionLength = 0; // Garante que nenhum texto seja selecionado
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarNumero("1");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdicionarNumero("2");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdicionarNumero("3");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarNumero("4");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdicionarNumero("5");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdicionarNumero("6");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdicionarNumero("7");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdicionarNumero("8");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdicionarNumero("9");
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }
        #endregion

        #region Botões de Operações

        private void SalvarOperacao(string novoOperador)
        {
            operador = novoOperador;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                valorAtual = Convert.ToDouble(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void dividir_Click(object sender, EventArgs e)
        {
            SalvarOperacao("/");
            textBox1.Select();
        }

        private void multiplicar_Click(object sender, EventArgs e)
        {
            SalvarOperacao("*");
            textBox1.Select();
        }

        private void subtrair_Click(object sender, EventArgs e)
        {
            SalvarOperacao("-");
            textBox1.Select();
        }

        private void somar_Click(object sender, EventArgs e)
        {
            SalvarOperacao("+");
            textBox1.Select();
        }
        #endregion

        #region Botão enter e delete
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(operador))
            {
                double segundoValor;
                string texto = textBox1.Text.Replace(",", ".");

                if (double.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out segundoValor))
                {
                    string expressaoCompleta = $"{valorAtual} {operador} {segundoValor} = ";
                    double resultado = 0;

                    switch (operador)
                    {
                        case "+":
                            resultado = valorAtual + segundoValor;
                            textBox1.Focus();
                            break;
                        case "-":
                            resultado = valorAtual - segundoValor;
                            textBox1.Focus();
                            break;
                        case "*":
                            resultado = valorAtual * segundoValor;
                            textBox1.Focus();
                            break;
                        case "/":
                            if (segundoValor != 0)
                            {
                                resultado = valorAtual / segundoValor;
                                textBox1.Focus();
                            }
                            else
                            {
                                textBox1.Text = expressaoCompleta + "Erro";
                                textBox1.Focus();
                                return;
                            }
                            break;
                    }

                    this.resultadoFinal = resultado; // Atualiza a variável global com o resultado
                    textBox1.Text = $"{expressaoCompleta}{resultado}";
                    operador = "";
                    // MessageBox.Show($"O resultado final é: {resultadoFinal}", "Resultado Final");

                }
                else
                {
                    // Tratamento para entrada inválida
                    textBox1.Text = "Entrada inválida";
                    textBox1.Focus();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); // Limpa o conteúdo do TextBox
            operador = ""; // Reseta o operador
            valorAtual = 0; // Reseta o valor atual
            textBox1.Focus();

        }

        #endregion

        #region Virgula

        private void AdicionarVirgula()
        {
            int selectionStart = textBox1.SelectionStart; // Salva a posição do cursor
            textBox1.Text = textBox1.Text.Insert(selectionStart, ","); // Insere a vírgula na posição do cursor
            textBox1.SelectionStart = selectionStart + 1; // Reposiciona o cursor após a vírgula
        }


        private void virgula_Click(object sender, EventArgs e)
        {
            AdicionarVirgula();

        }

        #endregion

        #region Associa Teclado a Tela
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                    button0.PerformClick();
                    break;
                case Keys.D1:
                    button1.PerformClick();
                    break;
                case Keys.D2:
                    button2.PerformClick();
                    break;
                case Keys.D3:
                    button3.PerformClick();
                    break;
                case Keys.D4:
                    button4.PerformClick();
                    break;
                case Keys.D5:
                    button5.PerformClick();
                    break;
                case Keys.D6:
                    button6.PerformClick();
                    break;
                case Keys.D7:
                    button7.PerformClick();
                    break;
                case Keys.D8:
                    button8.PerformClick();
                    break;
                case Keys.D9:
                    button9.PerformClick();
                    break;

                case Keys.Add:
                    somar.PerformClick();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Subtract:
                    subtrair.PerformClick();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Multiply:
                    multiplicar.PerformClick();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Divide:
                    dividir.PerformClick();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Decimal:
                    if (!(ActiveControl is Button) && !textBox1.Text.Contains(","))
                    {
                        AdicionarVirgula();
                        e.SuppressKeyPress = true; // Impede que a tecla decimal seja processada novamente
                    }
                    break;

                case Keys.Enter:
                    if (ActiveControl is Button) // Verifica se o foco está em um botão para evitar a digitação do zero
                    {
                        break;
                    }
                    buttonEnter.PerformClick();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Escape:
                case Keys.Delete:
                    buttonDelete.PerformClick(); // Chamada ao método do botão Delete
                    e.SuppressKeyPress = true;
                    break;

                default:

                    break;
                case Keys.S: // Tecla "S" para salvar
                    buttonSalvarResultado.PerformClick();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.M: // Tecla "M" para abrir a ComboBox
                    comboBox_memoria.DroppedDown = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }
        #endregion

        #region Memoria

        private List<double> resultadosSalvos = new List<double>();

        private void comboBox_memoria_DropDown(object sender, EventArgs e)
        {
            if (!comboBox_memoria.Items.Contains("Memória"))
            {
                comboBox_memoria.Items.Insert(0, "Memória");
                comboBox_memoria.SelectedIndex = 0;
            }
        }

        private void buttonSalvarResultado_Click(object sender, EventArgs e)
        {
            resultadosSalvos.Add(resultadoFinal);

            // Limpa os itens atuais do ComboBox
            comboBox_memoria.Items.Clear();

            // Adiciona "Memória" ao ComboBox como item inicial
            comboBox_memoria.Items.Add("Memória");

            // Adiciona os valores da lista ao ComboBox
            foreach (var resultado in resultadosSalvos)
            {
                comboBox_memoria.Items.Add(resultado.ToString());
            }

            comboBox_memoria.SelectedIndex = 0; // Seleciona "Memória" após adicionar os resultados
        }

        private void comboBox_memoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_memoria.SelectedIndex > 0 && comboBox_memoria.SelectedIndex <= resultadosSalvos.Count)
            {
                double valorSelecionado = resultadosSalvos[comboBox_memoria.SelectedIndex - 1];
                textBox1.Text = valorSelecionado.ToString();

                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
            else
            {
                textBox1.Text = "";
            }
        }


        #endregion



        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string removedItem = listBox1.Items[listBox1.SelectedIndex].ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                MessageBox.Show($"Item removido: {removedItem}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedItem = comboBox1.SelectedItem.ToString();
                MessageBox.Show($"Seleção alterada para: {selectedItem}");
            }
        }
    }
}