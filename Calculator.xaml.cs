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

namespace Abdelrahman_Mohamed_991343504_A2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Calculator : Page
    {
        string input = string.Empty;
        string x = string.Empty;
        string y = string.Empty;
        char operation;
        string outd = " ";
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
             //   case Operands: AnsBox.Text += "-"; break;





            }



        }


















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


        #region Equals
        //Tree definition to be able to determine order of precedence

        private class OperandClass
        {
            public Operands opp = Operands.NUMBER;
            public double value = 0;

            public OperandClass left = null;
            public OperandClass right = null;

        }
        //Actual tree construction from the expression
        private OperandClass BuildTreeOperand() {
            
            OperandClass tree = null;
            
            string expression = AnsBox.Text;

            if (!char.IsNumber(expression.Last())) { 
            
            
            
            
            
            }
        
        }



        private void Eqbtn_Click(object sender, RoutedEventArgs e)
        {
            OperandClass tree = BuildTreeOperand();
        }

        #endregion Equals
    }
}


