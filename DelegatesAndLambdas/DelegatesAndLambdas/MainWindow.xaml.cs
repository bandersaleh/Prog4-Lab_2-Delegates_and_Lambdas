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

namespace DelegatesAndLambdas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Action<type> - Delegate with a void return type
        // Predicate<type> - returns bool
        // TResult Func<in T1, out TResult>(T1 value)

        public delegate double MathDelegate(double num1, double num2);

        // What is a method signature
        public delegate double MyMathDelegate(double num1, double num2);
        public MyMathDelegate performMath;



        public MainWindow()
        {
            InitializeComponent();
            DisplayInformation("");


            // Func Delegate that will hold our math Methods
            Func<double, double, double> mathOperation = Add;
            Func<int, decimal, float> brokenCode = Add;
            Func<string, bool> isItRaining = IsItWetOutSide;



        } // WPF App Main Window()



        // Methods
        public void DisplayInformation(string message)
        {
            rtbDelegate.Text = "";
            rtbDelegate.Text += message;
        }

        public void DisplayToRTB(string value)
        {
            rtbDelegate.Text += value + "\n";
        }

        public double Add(double num1, double num2) { return num1 + num2; }
        public double Subtract(double num1, double num2) { return num1 - num2; }
        public double Multiply(double num1, double num2) { return num1 * num2; }
        public double Divide(double num1, double num2) { return num1 / num2; }
        public double Mod(double num1, double num2) { return num1 % num2; }

        public float Add(int num1, decimal num2)
        {
            return num1 + (float)num2;
        }







        public bool IsTrue(bool valid)
        {
            return valid;
        }

        public bool IsItWetOutSide(string response)
        {
            return (response == "yes") ? true : false;
        }

        public void ExamplePredicate()
        {
            Predicate<string> isRaining;

            isRaining = IsItWetOutSide;
            rtbDelegate.Text = "";
            DisplayToRTB(isRaining("no").ToString());

        } // Example of Delegate : Predicate()

        public void ExampleAction()
        {
            // Action is a delegate with a VOID return type
            Action<string> displayName = DisplayToRTB;
            displayName("Will");
        } // Example of Delegate : Action()

        public void Example()
        {

            MathDelegate addNumbers = new MathDelegate(Add);

            Predicate<bool> returnsIfTrue = IsTrue;

            returnsIfTrue(false);

            Console.WriteLine(addNumbers(1, 2));
        }

        public void Example2()
        {

            //MyMathDelegate mathOperation = new MyMathDelegate(Add);
            MyMathDelegate mathOperation = new MyMathDelegate(Subtract);

            string operation = "/";

            switch (operation)
            {
                case "+":
                    mathOperation = Add;
                    break;
                case "-":
                    mathOperation = Subtract;
                    break;
                case "*":
                    mathOperation = Multiply;
                    break;
                case "/":
                    mathOperation = Divide;
                    break;
            }

            double sum = mathOperation(1, 2);
            rtbDelegate.Text = "";
            DisplayToRTB(sum.ToString());

        }


        
        



        // Events
        

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double num1 = double.Parse(txtNum1.Text);
                double num2 = double.Parse(txtNum2.Text);

                double result = performMath(num1, num2);
                rtbDelegate.Text = "";
                DisplayToRTB(result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            performMath = Divide;
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            performMath = Multiply;

        }

        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            performMath = Subtract;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            performMath = Add;
        }

 
    } // Class
}
