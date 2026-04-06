using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private TextBox? txtDisplay;
        private Button[]? numberButtons;
        private Button? btnAdd, btnSubtract, btnMultiply, btnDivide, btnEquals, btnClear, btnDecimal;
        private double firstNumber = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Simple Calculator";
            this.Size = new System.Drawing.Size(300, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Display TextBox
            txtDisplay = new TextBox();
            txtDisplay.Location = new System.Drawing.Point(20, 20);
            txtDisplay.Size = new System.Drawing.Size(240, 30);
            txtDisplay.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.ReadOnly = true;
            this.Controls.Add(txtDisplay);

            // Number buttons
            numberButtons = new Button[10];
            for (int i = 0; i < 10; i++)
            {
                numberButtons[i] = new Button();
                numberButtons[i].Text = i.ToString();
                numberButtons[i].Size = new System.Drawing.Size(50, 50);
                numberButtons[i].Font = new System.Drawing.Font("Arial", 12);
                numberButtons[i].Click += NumberButton_Click;
                this.Controls.Add(numberButtons[i]);
            }

            // Position number buttons
            numberButtons[1].Location = new System.Drawing.Point(20, 80);
            numberButtons[2].Location = new System.Drawing.Point(80, 80);
            numberButtons[3].Location = new System.Drawing.Point(140, 80);
            numberButtons[4].Location = new System.Drawing.Point(20, 140);
            numberButtons[5].Location = new System.Drawing.Point(80, 140);
            numberButtons[6].Location = new System.Drawing.Point(140, 140);
            numberButtons[7].Location = new System.Drawing.Point(20, 200);
            numberButtons[8].Location = new System.Drawing.Point(80, 200);
            numberButtons[9].Location = new System.Drawing.Point(140, 200);
            numberButtons[0].Location = new System.Drawing.Point(20, 260);

            // Operator buttons
            btnAdd = new Button();
            btnAdd.Text = "+";
            btnAdd.Size = new System.Drawing.Size(50, 50);
            btnAdd.Location = new System.Drawing.Point(200, 80);
            btnAdd.Font = new System.Drawing.Font("Arial", 12);
            btnAdd.Click += OperatorButton_Click;
            this.Controls.Add(btnAdd);

            btnSubtract = new Button();
            btnSubtract.Text = "-";
            btnSubtract.Size = new System.Drawing.Size(50, 50);
            btnSubtract.Location = new System.Drawing.Point(200, 140);
            btnSubtract.Font = new System.Drawing.Font("Arial", 12);
            btnSubtract.Click += OperatorButton_Click;
            this.Controls.Add(btnSubtract);

            btnMultiply = new Button();
            btnMultiply.Text = "*";
            btnMultiply.Size = new System.Drawing.Size(50, 50);
            btnMultiply.Location = new System.Drawing.Point(200, 200);
            btnMultiply.Font = new System.Drawing.Font("Arial", 12);
            btnMultiply.Click += OperatorButton_Click;
            this.Controls.Add(btnMultiply);

            btnDivide = new Button();
            btnDivide.Text = "/";
            btnDivide.Size = new System.Drawing.Size(50, 50);
            btnDivide.Location = new System.Drawing.Point(200, 260);
            btnDivide.Font = new System.Drawing.Font("Arial", 12);
            btnDivide.Click += OperatorButton_Click;
            this.Controls.Add(btnDivide);

            // Equals button
            btnEquals = new Button();
            btnEquals.Text = "=";
            btnEquals.Size = new System.Drawing.Size(50, 50);
            btnEquals.Location = new System.Drawing.Point(140, 260);
            btnEquals.Font = new System.Drawing.Font("Arial", 12);
            btnEquals.Click += EqualsButton_Click;
            this.Controls.Add(btnEquals);

            // Clear button
            btnClear = new Button();
            btnClear.Text = "C";
            btnClear.Size = new System.Drawing.Size(50, 50);
            btnClear.Location = new System.Drawing.Point(80, 260);
            btnClear.Font = new System.Drawing.Font("Arial", 12);
            btnClear.Click += ClearButton_Click;
            this.Controls.Add(btnClear);

            // Decimal button
            btnDecimal = new Button();
            btnDecimal.Text = ".";
            btnDecimal.Size = new System.Drawing.Size(50, 50);
            btnDecimal.Location = new System.Drawing.Point(200, 320);
            btnDecimal.Font = new System.Drawing.Font("Arial", 12);
            btnDecimal.Click += DecimalButton_Click;
            this.Controls.Add(btnDecimal);
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (txtDisplay.Text == "0" || isOperationPerformed)
            {
                txtDisplay.Text = button.Text;
            }
            else
            {
                txtDisplay.Text += button.Text;
            }
            isOperationPerformed = false;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            firstNumber = double.Parse(txtDisplay.Text);
            operation = button.Text;
            isOperationPerformed = true;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(txtDisplay.Text);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                        MessageBox.Show("Cannot divide by zero!");
                    break;
            }

            txtDisplay.Text = result.ToString();
            isOperationPerformed = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            operation = "";
            isOperationPerformed = false;
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }
    }
}