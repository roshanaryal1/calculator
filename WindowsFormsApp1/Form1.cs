using System;
using System.Linq;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operation = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
            CreateButtons();
        }

        private void CreateButtons()
        {
            int buttonWidth = 65;
            int buttonHeight = 45;
            int padding = 10;
            string[] buttonTexts = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "C", "=", "+" };

            for (int i = 0; i < buttonTexts.Length; i++)
            {
                Button button = new Button();
                button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
                button.Text = buttonTexts[i];
                button.Width = buttonWidth;
                button.Height = buttonHeight;
                button.Left = 12 + (i % 4) * (buttonWidth + padding);
                button.Top = 100 + (i / 4) * (buttonHeight + padding);

                // Attach event handlers for button clicks
                if (buttonTexts[i] == "C")
                    button.Click += new System.EventHandler(this.button_Clear_Click);
                else if (buttonTexts[i] == "=")
                    button.Click += new System.EventHandler(this.button_Equal_Click);
                else if (new[] { "+", "-", "*", "/" }.Contains(buttonTexts[i]))
                    button.Click += new System.EventHandler(this.operator_Click);
                else
                    button.Click += new System.EventHandler(this.button_Click);

                // Add button to form
                this.Controls.Add(button);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + button.Text;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = result + " " + operation;
            isOperationPerformed = true;
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            result = 0;
            labelCurrentOperation.Text = "";
            isOperationPerformed = false;
        }

        private void button_Equal_Click(object sender, EventArgs e)
        {
            try
            {
                double currentValue = Double.Parse(textBox_Result.Text);

                switch (operation)
                {
                    case "+":
                        textBox_Result.Text = (result + currentValue).ToString();
                        break;
                    case "-":
                        textBox_Result.Text = (result - currentValue).ToString();
                        break;
                    case "*":
                        textBox_Result.Text = (result * currentValue).ToString();
                        break;
                    case "/":
                        if (currentValue == 0)
                        {
                            MessageBox.Show("Cannot divide by zero.");
                            textBox_Result.Text = "0";
                        }
                        else
                        {
                            textBox_Result.Text = (result / currentValue).ToString();
                        }
                        break;
                    default:
                        break;
                }

                result = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                textBox_Result.Text = "0";
            }
        }
    }
}
