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
        private readonly string[] operators = new string[] {"ON/OFF", "*", "+", "-", "=", "/", "%", "CLEAR" };
        //private string _label = " ";
        private Int32 _grand_total = 0;
        //private List<string> buttons = new List<string>();
        private double _currentValue = 0;    // Current number entered or result
        private string _currentOperator = ""; // Current operator (+, -, *, /)
        private bool _newEntry = true;       // Is the next number a new entry?
        public MainWindow()
        {
            InitializeComponent();

    }
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string tag = (string)button.Tag;

            if (tag == "CLEAR")
            {
                DisplayLabel.Content = "0";
                _currentValue = 0;
                _currentOperator = "";
                _newEntry = true;
                return;
            }

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

            // Handle operator buttons (+, -, *, /, =)
            double labelNumber = double.Parse(DisplayLabel.Content.ToString());

            if (_currentOperator != "")
            {
                // Calculate the previous operation
                switch (_currentOperator)
                {
                    case "+": _currentValue += labelNumber; break;
                    case "-": _currentValue -= labelNumber; break;
                    case "*": _currentValue *= labelNumber; break;
                    case "/": _currentValue /= labelNumber; break;
                }
                DisplayLabel.Content = _currentValue.ToString();
            }
            else
            {
                _currentValue = labelNumber; // first number
            }

            _currentOperator = tag == "=" ? "" : tag; // reset operator if "=" pressed
            _newEntry = true; // next number starts fresh
        }
    }
    }