using System;
using System.Windows.Forms;

namespace LAB5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // можно оставить пустым
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // можно оставить пустым
        }

        // === ОБРАБОТЧИКИ КНОПОК ===

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Calculate((a, b) => a + b);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            Calculate((a, b) => a - b);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            Calculate((a, b) => a * b);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            Calculate((a, b) =>
            {
                if (b == 0)
                    throw new DivideByZeroException("Деление на ноль!");
                return a / b;
            });
        }

        private void btnClear_Click(object sender, EventArgs e)  // ЭТОЙ КНОПКИ У ВАС НЕТ В СПИСКЕ! ДОБАВЬТЕ
        {
            txtNumber1.Text = "";
            txtNumber2.Text = "";
            lblResult.Text = "";
            lblResult.ForeColor = System.Drawing.Color.Black;
        }

        // === МЕТОД ДЛЯ ВЫЧИСЛЕНИЙ ===

        private void Calculate(Func<double, double, double> operation)
        {
            try
            {
                double num1 = Convert.ToDouble(txtNumber1.Text);
                double num2 = Convert.ToDouble(txtNumber2.Text);

                double result = operation(num1, num2);
                lblResult.Text = result.ToString();
                lblResult.ForeColor = System.Drawing.Color.Black;
            }
            catch (FormatException)
            {
                lblResult.Text = "Ошибка: введите числа";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            catch (DivideByZeroException ex)
            {
                lblResult.Text = ex.Message;
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception)
            {
                lblResult.Text = "Ошибка";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void lblResult_Click(object sender, EventArgs e)
        {
            // можно оставить пустым
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // можно оставить пустым
        }

        private void txtNumber2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtNumber1.Text = "";
            txtNumber2.Text = "";
            lblResult.Text = "";
            lblResult.ForeColor = System.Drawing.Color.Black;
        }
    }
}