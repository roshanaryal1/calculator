﻿using System;
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
        }

        private void button_Equal_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    textBox_Result.Text = (result + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (result / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
        }
    }
}
