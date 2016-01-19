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
using System.Windows.Shapes;

namespace ChangeCalculator
{
    /// <summary>
    /// Interaction logic for Denominations.xaml
    /// </summary>
    public partial class Denominations : Window
    {
        public Denominations()
        {
            InitializeComponent();
        }

        public void ReceiveValues(decimal hundreds, decimal fifties, decimal twenties, decimal tens, decimal fives, decimal ones, decimal quarters, decimal dimes, decimal nickels, decimal pennies)
        {
            hundredsBlock.Text = "x " + hundreds;
            fiftiesBlock.Text = "x " + fifties;
            twentiesBlock.Text = "x " + twenties;
            tensBlock.Text = "x " + tens;
            fivesBlock.Text = "x " + fives;
            onesBlock.Text = "x " + ones;
            quartersBlock.Text = "x " + quarters;
            dimesBlock.Text = "x " + dimes;
            nickelsBlock.Text = "x " + nickels;
            penniesBlock.Text = "x " + pennies;
        }
    }
}
