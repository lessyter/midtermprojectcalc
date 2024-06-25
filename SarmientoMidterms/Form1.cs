namespace SarmientoMidterms
{
    public partial class MidtermsCalculator : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public MidtermsCalculator()
        {
            InitializeComponent();
        }

        private void AppendNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultBox.Text == "0" || isOperationPerformed)
            {
                resultBox.Clear();
                isOperationPerformed = false;
            }

            if (button.Text == ".")
            {
                if (!resultBox.Text.Contains("."))
                    resultBox.Text += button.Text;
            }
            else
            {
                resultBox.Text += button.Text;
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            double secondNumber;
            if (double.TryParse(resultBox.Text, out secondNumber))
            {
                switch (operation)
                {
                    case "+":
                        result += secondNumber;
                        break;
                    case "-":
                        result -= secondNumber;
                        break;
                    case "*":
                        result *= secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result /= secondNumber;
                        }
                        else
                        {
                            MessageBox.Show("Division by zero error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    default:
                        break;
                }

                resultBox.Text = result.ToString();
                operation = "";
            }
        }

        private void ArithmeticOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (operation != "")
            {
                buttonEquals.PerformClick(); // Perform pending operation
                operation = button.Text;
            }
            else
            {
                operation = button.Text;
                result = double.Parse(resultBox.Text);
            }

            isOperationPerformed = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Length > 0)
                resultBox.Text = resultBox.Text.Remove(resultBox.Text.Length - 1, 1);
            if (resultBox.Text == "")
                resultBox.Text = "0";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
            result = 0;
            operation = "";
        }

        // Digit Buttons 0 - 9
        private void button0_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button1_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button2_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button3_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button4_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button5_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button6_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button7_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button8_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void button9_Click(object sender, EventArgs e) => AppendNumber(sender, e);
        private void buttonDecimal_Click(object sender, EventArgs e) => AppendNumber(sender, e);

        // Operation Buttons
        private void buttonAdd_Click(object sender, EventArgs e) => ArithmeticOperation_Click(sender, e);
        private void buttonSubtract_Click(object sender, EventArgs e) => ArithmeticOperation_Click(sender, e);
        private void buttonMultiply_Click(object sender, EventArgs e) => ArithmeticOperation_Click(sender, e);
        private void buttonDivide_Click(object sender, EventArgs e) => ArithmeticOperation_Click(sender, e);
    }
}