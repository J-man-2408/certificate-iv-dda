using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Caculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] operators = new string[] { "ON/OFF", "*", "+", "-", "=", "/", "%", "CLEAR"};
        //private string _label = " ";
        private Int32 _grand_total = 0;
        //private List<string> buttons = new List<string>();
        private double _currentValue = 0;    // Current number entered or result
        private string _currentOperator = ""; // Current operator clicked
        private bool _newEntry = true;       // Is the next number a new entry? should the next number replace the label or append

        public MainWindow()
        {
            InitializeComponent();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string tag = (string)button.Tag;

            // ON/OFF button
            if (tag == "ON/OFF")
            {
                Application.Current.Shutdown();
                return;
            }

            // CLEAR button
            if (tag == "CLEAR")
            {
                DisplayLabel.Content = "0";
                _currentValue = 0;
                _currentOperator = "";
                _newEntry = true;
                return;
            }

            // DECIMAL button
            if (tag == ".")
            {
                if (_newEntry)
                {
                    DisplayLabel.Content = "0.";
                    _newEntry = false;
                }
                else if (!DisplayLabel.Content.ToString().Contains("."))
                {
                    DisplayLabel.Content += ".";
                }
                return;
            }

            // PERCENT button
            if (tag == "%")
            {
                double number = double.Parse(DisplayLabel.Content.ToString());
                number /= 100;
                DisplayLabel.Content = number.ToString();
                _newEntry = true;
                return;
            }

            // NUMBER buttons
            if (!operators.Contains(tag))
            {
                if (_newEntry || DisplayLabel.Content.ToString() == "0")
                {
                    DisplayLabel.Content = tag;
                    _newEntry = false;
                }
                else
                {
                    DisplayLabel.Content += tag;
                }
                return;
            }

            // OPERATOR buttons (+, -, *, /, =)
            string labelText = DisplayLabel.Content.ToString().Split(' ')[0];
            double labelNumber = double.Parse(labelText);


            if (_currentOperator != "" && !_newEntry)
            {
                // Perform previous operation
                switch (_currentOperator)
                {
                    case "+": _currentValue += labelNumber; break;
                    case "-": _currentValue -= labelNumber; break;
                    case "*": _currentValue *= labelNumber; break;
                    case "/": _currentValue /= labelNumber; break;
                }
                DisplayLabel.Content = _currentValue.ToString();
            }
            else if (_currentOperator != "" && _newEntry)
            {
                // Overwrite operator on label if second number not yet entered
                DisplayLabel.Content = DisplayLabel.Content.ToString().Split(' ')[0] + " " + tag + " ";
                _currentOperator = tag;
                return;
            }
            else
            {
                _currentValue = labelNumber; // first number
            }

            // Update operator
            _currentOperator = tag == "=" ? "" : tag;

            // Show operator on label if not "="
            if (tag != "=")
            {
                DisplayLabel.Content = _currentValue.ToString() + " " + tag + " ";
            }

            _newEntry = true; // next number starts fresh
        }
    }
    }