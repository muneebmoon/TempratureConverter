using System;
using System.Windows.Forms;

namespace TempratureConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cb1.Items.Add("Celcius");
            cb1.Items.Add("Fahrenheit");
            cb1.Items.Add("Kelvin");
            cb2.Items.Add("Celcius");
            cb2.Items.Add("Fahrenheit");
            cb2.Items.Add("Kelvin");
        }

        private void Convertbtn_Click(object sender, EventArgs e)
        {
            if (inputTemp.Text == "" || cb1.Text == "" || cb2.Text == "")
            {
                MessageBox.Show("All Above fields are required! Please Fill All fields");
            }
            else
            {
                if(IsValidInput(inputTemp.Text))
                {
                    double input = Convert.ToDouble(inputTemp.Text);
                    Conversion(input, cb1.Text, cb2.Text);
                }
                else
                {
                    MessageBox.Show("Input must be a number");
                }
                
            }
        }

        private bool IsValidInput(string input)
        {
            return double.TryParse(input, out _);
        }

        private void Conversion(double input, string unit, string targetUnit)
        {
            if (unit == targetUnit)
            {
                MessageBox.Show("Targeted Unit must be different from input Unit");
                outtxt.Text = "";
            }
            else
            {
                if (unit == "Celcius" && targetUnit == "Fahrenheit")
                {
                    double output = ((input * (9.0 / 5.0)) + 32);
                    outtxt.Text = output.ToString() + " F";
                }
                if (unit == "Fahrenheit" && targetUnit == "Celcius")
                {
                    double output = ((input - 32) * (5.0 / 9.0));
                    outtxt.Text = output.ToString() + " C";
                }

                if (unit == "Celcius" && targetUnit == "Kelvin")
                {
                    double output = input + 273.15;
                    outtxt.Text = output.ToString() + " K";
                }

                if (unit == "Fahrenheit" && targetUnit == "Kelvin")
                {
                    double output = (input - 32) * (5.0 / 9.0) + 273.15;
                    outtxt.Text = output.ToString() + " K";
                }

                if (unit == "Kelvin" && targetUnit == "Celcius")
                {
                    double output = (input - 273.15);
                    outtxt.Text = output.ToString() + " C";
                }

                if (unit == "Kelvin" && targetUnit == "Fahrenheit")
                {
                    double output = (input - 273.15) * (9.0 / 5.0) + 32;
                    outtxt.Text = output.ToString() + " F";
                }

            }

        }
    }
}
