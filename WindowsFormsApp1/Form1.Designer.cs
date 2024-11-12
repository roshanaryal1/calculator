using System.Linq;
using System.Windows.Forms;

namespace SimpleCalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Label labelCurrentOperation;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.labelCurrentOperation = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // TextBox for result
            this.textBox_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox_Result.Location = new System.Drawing.Point(12, 12);
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.Size = new System.Drawing.Size(276, 45);
            this.textBox_Result.TabIndex = 0;
            this.textBox_Result.Text = "0";
            this.textBox_Result.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // Label for current operation
            this.labelCurrentOperation.AutoSize = true;
            this.labelCurrentOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelCurrentOperation.Location = new System.Drawing.Point(12, 60);
            this.labelCurrentOperation.Name = "labelCurrentOperation";
            this.labelCurrentOperation.Size = new System.Drawing.Size(0, 29);
            this.labelCurrentOperation.TabIndex = 1;

            // Add buttons
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

                if (buttonTexts[i] == "C")
                    button.Click += new System.EventHandler(this.button_Clear_Click);
                else if (buttonTexts[i] == "=")
                    button.Click += new System.EventHandler(this.button_Equal_Click);
                else if (new[] { "+", "-", "*", "/" }.Contains(buttonTexts[i]))
                    button.Click += new System.EventHandler(this.operator_Click);
                else
                    button.Click += new System.EventHandler(this.button_Click);

                this.Controls.Add(button);
            }

            // Form settings
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.labelCurrentOperation);
            this.Name = "Form1";
            this.Text = "Simple Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
