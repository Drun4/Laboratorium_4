using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorium_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Lambda #1
        private void btn_numToThePower_Click(object sender, EventArgs e)
        {
            double numberFromUser = Convert.ToDouble(box_input.Text);
            int degreeFromUser = Convert.ToInt32(box_degree.Text);
            Func<double, int, double> numberToThePower = (number, degree) =>
            {
                if (degree > 0)
                {
                    double result = number;
                    for (int i = 1; i < degree; i++)
                    {
                        result *= number;
                    }
                    return result;
                }
                else if (degree < 0)
                {
                    double result = 1 / number;
                    for (int i = degree; i < -1; i++)
                    {
                        result *= (1 / number);
                    }
                    return result;
                }
                else
                {
                    return 1;
                }
            };
            box_output.Text = numberToThePower(numberFromUser, degreeFromUser).ToString();
        }
        //Lambda #2
        private void btn_stringToThePower_Click(object sender, EventArgs e)
        {
            string stringFromUser = box_input.Text;
            int degreeFromUser = Convert.ToInt32(box_degree.Text);
            Func<string, int, string> stringToThePower = (symbol, degree2) =>
            {
                string result = "";
                for (int i = 0; i < degree2; i++)
                {
                    result += symbol;
                }
                return result;
            };
            box_output.Text = stringToThePower(stringFromUser, degreeFromUser);
        }
        //Lambda #3
        public Func<double> numToThePower(double a, int b)
        {
            if (b > 0)
            {
                double result = a;
                for (int i = 1; i < b; i++)
                {
                    result *= a;
                }
                return () => result;
            }
            else if (b < 0)
            {
                double result = 1 / a;
                for (int i = b; i < -1; i++)
                {
                    result *= (1 / a);
                }
                return () => result;
            }
            else
            {
                return () => 1;
            }
        }
        private void btn_numberToThePowerMethod_Click(object sender, EventArgs e)
        {
            Func<double> numberToThePower = numToThePower(Convert.ToDouble(box_input.Text), 
                Convert.ToInt32(box_degree.Text));
            box_output.Text = Convert.ToString(numberToThePower());
        }

        //Lambda #4-5
        delegate bool operations(double a, double b);
        operations compare;

        Func<double[], operations, double[]> BubbleSort = (table, compare) =>
        {
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 1; j < table.Length - i; j++)
                {
                    if (compare(table[j], table[j - 1]))
                    {
                        var temp = table[j];
                        table[j] = table[j - 1];
                        table[j - 1] = temp;
                    }
                }
            }
            return table;
        };

        private void btn_sortAscending_Click(object sender, EventArgs e)
        {
            box_output.Text = "";
            string[] inputs = box_input.Text.Split(' ');
            double[] array = new double[inputs.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToDouble(inputs[i]);
            }

            compare = (a, b) =>
            {
                if (a < b)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            BubbleSort(array, compare);
            double[] outputTable = BubbleSort(array, compare);
            for (int i = 0; i < outputTable.Length; i++)
            {
                box_output.Text += outputTable[i].ToString() + " ";
            }
        }
        private void btn_sortDescending_Click(object sender, EventArgs e)
        {
            box_output.Text = "";
            string[] inputs = box_input.Text.Split(' ');
            double[] array = new double[inputs.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToDouble(inputs[i]);
            }

            compare = (a, b) =>
            {
                if (a > b)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            BubbleSort(array, compare);
            double[] outputTable = BubbleSort(array, compare);
            for (int i = 0; i < outputTable.Length; i++)
            {
                box_output.Text += outputTable[i].ToString() + " ";
            }
        }

        //Extension methods #1
        private void btn_changeLetters_Click(object sender, EventArgs e)
        {
            string line = box_input.Text;
            box_output.Text = line.changeLetters();
        }
        //Extension methods #2
        private void btn_removeVovels_Click(object sender, EventArgs e)
        {
            string line = box_input.Text;
            box_output.Text = line.removeVovels();
        }
        //Extension methods #3
        private void btn_getWordsLength_Click(object sender, EventArgs e)
        {
            box_output.Text = "";
            string line = box_input.Text;
            string[] words = box_input.Text.Split(' ');
            int[] wordsLength = new int[words.Length];
            
            for(int i = 0; i < wordsLength.Length; i++)
            {
                wordsLength[i] = line.getWordsLength()[i];
                box_output.Text += wordsLength[i].ToString() + " ";
            }
        }
        //Extension methods #4
        private void btn_isSentence_Click(object sender, EventArgs e)
        {
            string line = box_input.Text;
            box_output.Text = line.isSentence().ToString();
        }
        //Extension methods #5
        private void btn_commonElement_Click(object sender, EventArgs e)
        {
            string line = box_input.Text;
            box_output.Text = line.mostCommonElement();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            box_output.Text = "";
            box_input.Text = "";
            box_degree.Text = "";
        }
    }
}

/*
    //Lambda #4-5
    public static double[] BubbleSort(double[] table, Func<double, double, bool> compare)
    {
        for (int i = 0; i < table.Length; i++)
        {
            for (int j = 1; j < table.Length - i; j++)
            {
                if (compare(table[j], table[j - 1]))
                {
                    var temp = table[j];
                    table[j] = table[j - 1];
                    table[j - 1] = temp;
                }
            }
        }
        return table;
    }
    public static Func<double, double, bool> CompareAscending()
    {
        return (s1, s2) =>
        {
            if (s1 > s2)
            {
                return false;
            }
            else
            {
                return true;
            }
        };
    }
    public static Func<double, double, bool> CompareDescending()
    {
        return (s1, s2) =>
        {
            if (s1 < s2)
            {
                return false;
            }
            else
            {
                return true;
            }
        };
    }
*/