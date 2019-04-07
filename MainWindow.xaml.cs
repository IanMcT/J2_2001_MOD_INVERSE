/*
 * Ian McTavish
 * J2 From https://cemc.uwaterloo.ca/contests/computing/2001/stage1/2001CCCStage1Contest.pdf
 * Mod Inverse
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace j2_2001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //variables:
        int x, m, n;
        int countEnter;
        public MainWindow()
        {
            InitializeComponent();
            //default initialization:
            x = 0;
            m = 0;
            n = 1;
            countEnter = 0;
            txtInput.SelectionStart = txtInput.Text.Length;
            txtInput.Focus();
        }

        private void txtInput_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            //input
            //deal with when the user hits the enter key
            if (e.Key == Key.Enter && countEnter == 0)
            {
                txtInput.Text += "Enter m:" + Environment.NewLine;
                txtInput.SelectionStart = txtInput.Text.Length - 1;
                countEnter++;
                e.Handled = true;
                txtInput.Focus();
            } else if (e.Key == Key.Enter && countEnter == 1)
            {
                //get the values for x and m by splitting on new lines
                string[] values = txtInput.Text.Split(new char[] { '\n' });
                /*For debugging purposes
                for (int i = 0; i < values.Length; i++)
                {
                    MessageBox.Show(i.ToString() + ": " + values[i]);
                }*/
                int.TryParse(values[1], out x);
                int.TryParse(values[3], out m);
                //debugging
                //MessageBox.Show("x: " + x.ToString() + "\nm: " + m.ToString());
                

                //loop to see if there is a value that fits.
                while ((n <= m) && (x*n%m != 1))
                {
                    //int test = x * n % m;//debugging
                    //MessageBox.Show("n: " + n.ToString() + "\ntest: " + test.ToString());
                    n++;
                }
                if (n > m)
                {
                    lblOutput.Content = "No such integer exists";
                }
                else
                {
                    lblOutput.Content = n.ToString();
                }
                //reset
                txtInput.Text = "Enter x:\n";
                countEnter = 0;
                txtInput.SelectionStart = txtInput.Text.Length;
                txtInput.Focus();
            }//end if
        }//end method
    }
}
