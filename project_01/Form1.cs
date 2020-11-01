using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9a-zA-Z ]", "");
            textboxSender.SelectionStart = cursorPosition;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if (e.KeyChar == '.'
            //    && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPhone.TextLength < 10)
            {
                MessageBox.Show("Please enter a valid phone number");
            }
            else if (txtPhone.TextLength <1)
            {
                MessageBox.Show("Please enter Name");
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Please select Order type");
            }
            else
            {
                tabControl1.SelectedTab = tabPage2;

                if (radioButton1.Checked == true)
                {
                    gpxStreet.Visible = true;
                }
                if (radioButton2.Checked == true)
                {
                    groupBox1.Visible = true;
                    groupBox1.Location = new Point(8, 3);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            gpxStreet.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool validated = true;

            if(gpxStreet.Visible == true)
            {
                if(ValidatePostalCode(txtPostalCode.Text) == false)
                {
                    validated = false;
                }
                if(txtCity.TextLength <1)
                {
                    validated = false;
                    MessageBox.Show("Please enter City Name");
                }
                if(txtStreet.TextLength <1)
                {
                    validated = false;
                    MessageBox.Show("Please enter Street Name");
                }
            }
            if(validated == true)
            {
                tabControl1.SelectedTab = tabPage3;
                listBox1.Items.Add("Name   : "+ txtName.Text);
                listBox1.Items.Add("Phone  : " + txtPhone.Text);
                
                listBox1.Items.Add(" ");
                if(radioButton1.Checked == true)
                {
                    listBox1.Items.Add("Order Type  : Delivery ");
                    
                    listBox1.Items.Add("City        :" + txtCity.Text);
                    listBox1.Items.Add("Street      :" + txtStreet.Text);
                    listBox1.Items.Add("Postal Code :" + txtPostalCode.Text);
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Products In the Order");
                    listBox1.Items.Add("Prod 1      : " + nudProduct1.Value + "  " + (int)(nudProduct1.Value * 5));
                    listBox1.Items.Add("Prod 2      : " + nudPrduct2.Value + "  " + (int)(nudPrduct2.Value * 10));
                    listBox1.Items.Add("Delivery Fee: 15");
                    listBox1.Items.Add("Total Before Tax: " + ((int)(nudProduct1.Value * 5) +15+ (int)(nudPrduct2.Value * 10)));

                    listBox1.Items.Add("Total After Tax: " + (((double)(nudProduct1.Value * 5) +(double)+ (double)(nudPrduct2.Value * 10)) * 1.15));
                }
                else if (radioButton2.Checked == true)
                {
                    listBox1.Items.Add("Order Type      : Pick UP");
                    listBox1.Items.Add("Pick Up Date    :" + dtpDate.Value.Date.ToShortDateString());
                    listBox1.Items.Add("Pick Up Time    :" + dtpTime.Value.ToShortTimeString());
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("Products In the Order");
                    listBox1.Items.Add("Prod 1          : " + nudProduct1.Value + "  " + (int)(nudProduct1.Value * 5));
                    listBox1.Items.Add("Prod 2          : " + nudPrduct2.Value + "  " + (int)(nudPrduct2.Value * 10));
                    listBox1.Items.Add("Total Before Tax: " + ((int)(nudProduct1.Value * 5) + (int)(nudPrduct2.Value * 10)));

                    listBox1.Items.Add("Total After Tax: " + (((double)(nudProduct1.Value * 5) + (double)(nudPrduct2.Value * 10)) * 1.15));
                }

                
            }
        }
        
        public bool ValidatePostalCode(string postalCode )
       
        {

            if( postalCode.Length ==0)
            {
                MessageBox.Show("Postal is missing");
            }

            postalCode = postalCode.Trim();

            Regex rgx = new Regex(@"^[A-Z][0-9][A-Z]$|^[0-9][A-Z][0-9]$");
            
            if(rgx.IsMatch(postalCode))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please enter a valid postal code");
                return false;

            }
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void numericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            txtCity.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtPostalCode.Clear();
            txtStreet.Clear();
            dtpDate.ResetText();
            dtpTime.ResetText();
            nudPrduct2.Value = 0;
            nudProduct1.Value = 0;
            gpxStreet.Visible = false;
            listBox1.Items.Clear();
            tabControl1.SelectedTab = tabPage1;


            
        }
    }
}
