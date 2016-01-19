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

namespace ChangeCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        decimal totalCostDecimal = 0;
        decimal totalReceivedDecimal = 0;
        decimal changeDue = 0;
        decimal hundredVal = 100.00M;
        decimal fiftyVal = 50.00M;
        decimal twentyVal = 20.00M;
        decimal tenVal = 10.00M;
        decimal fiveVal = 5.00M;
        decimal oneVal = 1.00M;
        decimal quartVal = 0.25M;
        decimal dimeVal = 0.10M;
        decimal nickVal = 0.05M;
        decimal pennyVal = 0.01M;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string totalCost = textBoxTotalCost.Text;
                decimal totalCostDecimal = decimal.Parse(totalCost);

                string totalReceived = textBoxTotalReceived.Text;
                decimal totalReceivedDecimal = decimal.Parse(totalReceived);

                changeDue = Math.Round(totalReceivedDecimal - totalCostDecimal, 2);
                textBlockChangeDue1.Text = "$" + changeDue;
            }

            catch (Exception exception)
            {
                changeDue = 0;
                textBlockChangeDue1.Text = "$" + changeDue;
                MessageBox.Show("Your input(s) were invalid. Input valid dollar amount(s) without the '$'.");
            }

            if (changeDue < 0)
            {
                MessageBox.Show("The customer still owes you $" + changeDue * -1 + ".");
            }
        }

        private void buttonDenominations_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Change due: " + changeDue);

            decimal hundreds = Math.Floor(changeDue / hundredVal);
            decimal hundredsRemainder = (changeDue % hundredVal);
            decimal fifties = Math.Floor(hundredsRemainder / fiftyVal);
            decimal fiftiesRemainder = (hundredsRemainder % fiftyVal);
            decimal twenties = Math.Floor(fiftiesRemainder / twentyVal);
            decimal twentiesRemainder = (fiftiesRemainder % twentyVal);
            decimal tens = Math.Floor(twentiesRemainder / tenVal);
            decimal tensRemainder = (twentiesRemainder % tenVal);
            decimal fives = Math.Floor(tensRemainder / fiveVal);
            decimal fivesRemainder = (tensRemainder % fiveVal);
            decimal ones = Math.Floor(fivesRemainder / oneVal);
            decimal onesRemainder = (fivesRemainder % oneVal);
            decimal quarters = Math.Floor(onesRemainder / quartVal);
            decimal quartersRemainder = (onesRemainder % quartVal);
            decimal dimes = Math.Floor(quartersRemainder / dimeVal);
            decimal dimesRemainder = (quartersRemainder % dimeVal);
            decimal nickels = Math.Floor(dimesRemainder / nickVal);
            decimal nickelsRemainder = (dimesRemainder % nickVal);
            decimal pennies = Math.Floor(nickelsRemainder / pennyVal);

            //I made the new window too small so its too hard to see the coins' pictures, but I was too lazy to fix it.
            Denominations denominationsWindow = new Denominations();
            denominationsWindow.Show();
            denominationsWindow.ReceiveValues(hundreds, fifties, twenties, tens, fives, ones, quarters, dimes, nickels, pennies);
        }
    }
}
