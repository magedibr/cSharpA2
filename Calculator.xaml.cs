using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AM_A2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Calculator : Page
    {
        public Calculator()
        {
            this.InitializeComponent();

            AnsBox.Text = "0";
        }

        private void AddNumberToResult(double addResultNumber)
        {

            if (char.IsNumber(AnsBox.Text.Last()))
            {
                if (AnsBox.Text.Length == 1 && AnsBox.Text == "0")
                {      
                    AnsBox.Text = string.Empty;
                }
                AnsBox.Text += addResultNumber;
            }
            else if (addResultNumber != 0)
            {
                AnsBox.Text += addResultNumber;
            }
        }//EOFunc

        //Enum used to store precedence
        enum Operands { MINUS = 1, PLUS = 2, DIV = 3, TIMES = 4, NUMBER = 5 };
        private void AddOperationToResult(Operands operands)
        {

            if (AnsBox.Text.Length == 1 && AnsBox.Text == "0") return;

            if (!char.IsNumber(AnsBox.Text.Last()))
            {

                AnsBox.Text = AnsBox.Text.Substring(0, AnsBox.Text.Length - 1);

            }

            switch (operands)
            {
                case Operands.MINUS: AnsBox.Text += "-"; break;

                case Operands.PLUS: AnsBox.Text += "+"; break;

                case Operands.DIV: AnsBox.Text += "/"; break;

                case Operands.TIMES: AnsBox.Text += "x"; break;

            }
        }

        //Button event handlers for calculator
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(3);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(4);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(5);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(6);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(7);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {

            AddNumberToResult(8);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(9);

        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            AddNumberToResult(0);
        }

        private void Divbtn_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operands.DIV);
        }

        private void Tmsbtn_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operands.TIMES);
        }

        private void Plsbtn_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operands.PLUS);
        }

        private void Minbtn_Click(object sender, RoutedEventArgs e)
        {
            AddOperationToResult(Operands.MINUS);
        }

        private void Cbtn_Click(object sender, RoutedEventArgs e)
        {
            AnsBox.Text = 0.ToString();
        }
        //End of button handlers

        //Tree definition to be able to determine order of precedence

        //Operand class to act as a heap to store operands
        private class OperandClass
        {
            public Operands opp = Operands.NUMBER;
            public double value = 0;

            public OperandClass left = null;
            public OperandClass right = null;

        }//End of Operand class


        //Actual tree construction from the expression
        private OperandClass BuildTreeOperand()
        {

            OperandClass tree = null;

            string expression = AnsBox.Text;

            if (!char.IsNumber(expression.Last()))
            {

                expression = expression.Substring(0, expression.Length - 1);

            }

            string numberStr = string.Empty;
            foreach (char c in expression.ToCharArray())
            {

                if (char.IsNumber(c) || c == '.' || numberStr == string.Empty && c == '-')
                {

                    numberStr += c;
                }
                else
                {

                    AddOperandToTree(ref tree, new OperandClass() { value = double.Parse(numberStr) });
                    numberStr = string.Empty;

                    Operands op = Operands.MINUS; //Set default case

                    switch (c)
                    {

                        case '-': op = Operands.MINUS; break;
                        case '+': op = Operands.PLUS; break;
                        case '/': op = Operands.DIV; break;
                        case 'x': op = Operands.TIMES; break;

                    }
                    AddOperandToTree(ref tree, new OperandClass() { opp = op });

                }


            }

            //Last number
            AddOperandToTree(ref tree, new OperandClass { value = double.Parse(numberStr) });
            return tree;
        }
        private void AddOperandToTree(ref OperandClass tree, OperandClass elem)
        {
            if (tree == null)
            {

                tree = elem;

            }
            else
            {
                if (elem.opp < tree.opp)
                {
                    OperandClass auxTree = tree;
                    tree = elem;
                    elem.left = auxTree;

                }
                else
                {
                    AddOperandToTree(ref tree.right, elem);// recursion used to loop through operands
                }
            }

        }

        private double CalcTree(OperandClass tree)
        {
            if (tree.left == null && tree.right == null)
            {
                return tree.value;

            }
            else //its an operation
            {
                double subResult = 0;
                switch (tree.opp)
                {

                    case Operands.MINUS: subResult = CalcTree(tree.left) - CalcTree(tree.right); break;
                    case Operands.PLUS: subResult = CalcTree(tree.left) + CalcTree(tree.right); break;
                    case Operands.DIV: subResult = CalcTree(tree.left) / CalcTree(tree.right); break;
                    case Operands.TIMES: subResult = CalcTree(tree.left) * CalcTree(tree.right); break;


                }

                return subResult;
            }
        }

        //Display results
        private void Eqbtn_Click(object sender, RoutedEventArgs e)
        {

            //Qualify input

            if (string.IsNullOrEmpty(AnsBox.Text)) return;

            OperandClass tree = BuildTreeOperand();

            double value = CalcTree(tree);

            AnsBox.Text = value.ToString();
        }
    }
}
    


