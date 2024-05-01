namespace WinForms2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String equation = ""; //stores the information for the entire equation to be calculated

        /** Adds a 1 to the equation string */
        private void button1_Click(object sender, EventArgs e)
        {
            equation += "1";
            textBox1.Text = equation;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            equation += "2";
            textBox1.Text = equation;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            equation += "3";
            textBox1.Text = equation;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            equation += "4";
            textBox1.Text = equation;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            equation += "5";
            textBox1.Text = equation;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            equation += "6";
            textBox1.Text = equation;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            equation += "7";
            textBox1.Text = equation;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            equation += "8";
            textBox1.Text = equation;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            equation += "9";
            textBox1.Text = equation;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            equation += "0";
            textBox1.Text = equation;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            equation += "+";
            textBox1.Text = equation;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            equation += "-";
            textBox1.Text = equation;
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            equation += "*";
            textBox1.Text = equation;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            equation += "/";
            textBox1.Text = equation;
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            equation += ".";
            textBox1.Text = equation;
        }

        /** Evaluates the equation string and returns an answer */
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            String[] split;

            double[] values;

            int i, j;

            //STRING SPLIT * / + -
            //RESOLVE NUMBERS (values)

            split = equation.Split(new char[] { '+', '*', '-', '/' });
            values = new double[split.Length];

            for (i = 0; i < split.Length; i++)
            {
                values[i] = Convert.ToDouble(split[i]);
            }

            List<double> valuesList = values.ToList();

            //LOOP STRING BY CHARACTER TO GET * / + -

            int operandIndex = 0;

            List<int> operandIndices = new List<int>(); //list of operand indices
            List<char> operands = new List<char>(); //list of operand characters

            // FIND INDEXES OF OPERANDS
            for (i = 0; i < equation.Length; i++)
            {
                if (equation[i].CompareTo('*') == 0)
                {
                    operandIndices.Add(operandIndex++);
                    operands.Add('*');

                }
                if (equation[i].CompareTo('/') == 0)
                {
                    operandIndices.Add(operandIndex++);
                    operands.Add('/');
                }

                if (equation[i].CompareTo('+') == 0)
                {
                    operandIndices.Add(operandIndex++);
                    operands.Add('+');
                }
                if (equation[i].CompareTo('-') == 0)
                {
                    operandIndices.Add(operandIndex++);
                    operands.Add('-');
                }
            }

            //LOOP TWICE, [BE]DMAS ==> DM,AS

            // MULTIPLY / DIVIDE
            for (i = 0; i < operandIndices.Count; i++)
            {
                //check for * or /
                if (operands[i].CompareTo('*') == 0) {
                    //multiply the first node and remove the second node from the list
                    valuesList[operandIndices[i]] = valuesList[operandIndices[i]] * valuesList[operandIndices[i] + 1];
                    valuesList.RemoveAt(operandIndices[i] + 1);
                    //update indices beyond j
                    for (j = i; j < operandIndices.Count; j++)
                    {
                        operandIndices[j]--;
                    }
                } else if (operands[i].CompareTo('/') == 0)
                {
                    //divide the first node and remove the second node from the list
                    valuesList[operandIndices[i]] = valuesList[operandIndices[i]] / valuesList[operandIndices[i] + 1];
                    valuesList.RemoveAt(operandIndices[i] + 1);
                    //update indices beyond j
                    for (j = i; j < operandIndices.Count; j++)
                    {
                        operandIndices[j]--;
                    }
                }
            }

            // ADD / SUBTRACT
            for (i = 0; i < operandIndices.Count; i++)
            {
                //check for + or -
                if (operands[i].CompareTo('+') == 0)
                {
                    //add to the first node and remove the second node from the list
                    valuesList[operandIndices[i]] = valuesList[operandIndices[i]] + valuesList[operandIndices[i] + 1];
                    valuesList.RemoveAt(operandIndices[i] + 1);
                    //update indices beyond j
                    for (j = i; j < operandIndices.Count; j++)
                    {
                        operandIndices[j]--;
                    }
                }
                else if (operands[i].CompareTo('-') == 0)
                {
                    //subtract to the first node and remove the second node from the list
                    valuesList[operandIndices[i]] = valuesList[operandIndices[i]] - valuesList[operandIndices[i] + 1];
                    valuesList.RemoveAt(operandIndices[i] + 1);
                    //update indices beyond j
                    for (j = i; j < operandIndices.Count; j++)
                    {
                        operandIndices[j]--;
                    }
                }
            }

            //OUTPUT ANSWER TO TEXTBOX & RESET EQUATION
            textBox1.Text = equation + " = " + valuesList[0];
            equation = "";

        }

        /** Handles the removal of the last character added to the equation */
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //REMOVE LAST INPUT WHEN INPUT EXISTS
            if (equation.Length > 0)
            {
                equation = equation.Substring(0, equation.Length - 1);
            }
            //UPDATE EQUATION TO TEXTBOX
            textBox1.Text = equation;
        }
    }
}
