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

        double totalCostDouble = 0;
        double totalReceivedDouble = 0;
        double changeDue = 0;
        double hundredVal = 100.00;
        double fiftyVal = 50.00;
        double twentyVal = 20.00;
        double tenVal = 10.00;
        double fiveVal = 5.00;
        double oneVal = 1.00;
        double quartVal = 0.25;
        double dimeVal = 0.10;
        double nickVal = 0.05;
        double pennyVal = 0.01;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string totalCost = textBoxTotalCost.Text;
                double totalCostDouble = double.Parse(totalCost);

                string totalReceived = textBoxTotalReceived.Text;
                double totalReceivedDouble = double.Parse(totalReceived);
                
                changeDue = totalReceivedDouble - totalCostDouble;
                textBlockChangeDue1.Text = "$" + changeDue;
            }

            catch (Exception exception)
            {
                MessageBox.Show("Your input(s) were invalid. Input valid dollar amount(s) without the '$'.");
            }

            if (changeDue < 0)
            {
                MessageBox.Show("The customer still owes you $" + changeDue * -1 + ".");
            }
        }
        
        private void buttonDenominations_Click(object sender, RoutedEventArgs e)
        {
            double hundreds = Math.Floor(changeDue / hundredVal);
            double hundredsRemainder = (changeDue % hundredVal);
            double fifties = Math.Floor(hundredsRemainder / fiftyVal);
            double fiftiesRemainder = (hundredsRemainder % fiftyVal);
            double twenties = Math.Floor(fiftiesRemainder / twentyVal);
            double twentiesRemainder = (fiftiesRemainder % twentyVal);
            double tens = Math.Floor(twentiesRemainder / tenVal);
            double tensRemainder = (twentiesRemainder % tenVal);
            double fives = Math.Floor(tensRemainder / fiveVal);
            double fivesRemainder = (tensRemainder % fiveVal);
            double ones = Math.Floor(fivesRemainder / oneVal);
            double onesRemainder = (fivesRemainder % oneVal);
            double quarters = Math.Floor(onesRemainder / quartVal);
            double quartersRemainder = (onesRemainder % quartVal);
            double dimes = Math.Floor(quartersRemainder / dimeVal);
            double dimesRemainder = (quartersRemainder % dimeVal);
            double nickels = Math.Floor(dimesRemainder / nickVal);
            double nickelsRemainder = (dimesRemainder % nickVal);
            double pennies = Math.Floor(nickelsRemainder / pennyVal);

            //I made the new window too small so its too hard to see the coins' pictures, but I was too lazy to fix it.
            Denominations denominationsWindow = new Denominations();
            denominationsWindow.Show();
            denominationsWindow.ReceiveValues(hundreds, fifties, twenties, tens, fives, ones, quarters, dimes, nickels, pennies);
        }
    }
}
