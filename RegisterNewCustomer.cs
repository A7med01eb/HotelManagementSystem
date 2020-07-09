using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml.Schema;
using System.Data.SqlClient;

namespace Hotel_Management_System
{
    public partial class RegisterNewCustomer : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a7med\Desktop\Hotel Management System\Hotel Management System\Hotel Management System\Hotel.mdf;Integrated Security = True");

        public double TotalArabic = 0;
        public double TotalItalic = 0;
        public double priceRoom = 0;
        public int HowManyDays;


        public RegisterNewCustomer()
        {
            InitializeComponent();
            PersonalInformationPanel.Show();
            Days.Hide();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }  
        private void Hotel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelDataSet.Days' table. You can move, or remove it, as needed.
            this.daysTableAdapter.Fill(this.hotelDataSet.Days);
            // TODO: This line of code loads data into the 'hotelDataSet.PersonalInformation' table. You can move, or remove it, as needed.

        }
        private void personalInformationBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.personalInformationBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hotelDataSet);

        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
     
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType=CommandType.Text;
            command.CommandText="insert into PersonalInformation values (' " +idTextBox.Text+" ' , ' "+first_NameTextBox.Text+" ', ' "+last_NameTextBox.Text+" ' ,' "+nationalityTextBox.Text+" ' ,' "+countryTextBox.Text+" ' ,' "+cPRTextBox.Text+" ', ' "+phone_No_TextBox.Text+" ' ,' "+addressTextBox.Text+ " ' )" ;
            int i = command.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show(i + " Data Saved ");
            }

            PersonalInformationPanel.Hide();
            Days.Show();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }
        public static string IdNo;
        public static string RoomType;
        public static string In;
        public static string Out;
        private int CalcHowManyDay()
        {
            DateTime checkIn = check_In_DateDateTimePicker.Value.Date;
            DateTime checkOut = check_Out_DateDateTimePicker.Value.Date;
            TimeSpan diff = checkOut - checkIn;
            int days = diff.Days;
            return days;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            IdNo = idTextBox1.Text;
            textBox2.Text =IdNo;
            RoomType = room_TypeComboBox.Text;
            textBox3.Text = RoomType;
            In = check_In_DateDateTimePicker.Text;
            DayTextBox.Text = In;
            Out = check_Out_DateDateTimePicker.Text;
            textBox1.Text = Out;

            if (room_TypeComboBox.Text == "Single")
            {
                priceRoom = 4.5;
            }
            else if (room_TypeComboBox.Text == "Double")
            {
                priceRoom = 7.5;
            }
            else
            {
                priceRoom = 12.5;
            }
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO Days VALUES ('"+ idTextBox1.Text +"','"+ room_TypeComboBox.Text+" ',' "+ check_In_DateDateTimePicker.Text +" ',' "+ check_Out_DateDateTimePicker.Text+" ' )";
            
            
            int i = command.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show(i + " Data Saved ");
            }
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Show();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Hide();
            ArabicPanel.Show();
            ItalicPanel.Hide();
            BillPanel.Hide();

            ArabicTextBox.Text = TotalArabic.ToString();
            ItalicTextBox.Text = TotalItalic.ToString();
            textBox4.Text = (TotalArabic + TotalItalic).ToString();
            textBox5.Text = ((TotalArabic + TotalItalic + priceRoom) * CalcHowManyDay()).ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Show();
            BillPanel.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            TotalArabic += 1.800;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            TotalArabic += 2.200;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            TotalArabic += 3.400;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            TotalArabic += 1.500;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Show();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            TotalItalic += 3.800;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            TotalItalic += 1.100;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            TotalItalic += 1.700;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            TotalItalic += 1.300;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Show();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }
        /*private int CalcHowManyDays()
        {
            DateTime CheckIn = check_In_DateDateTimePicker.Value.Date;
            DateTime CheckOut = check_Out_DateDateTimePicker.Value.Date;
            TimeSpan diff = CheckOut - CheckIn;
            int days = diff.Days;
            return days;
        }*/

        private void button12_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Show();
            Days.Hide();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }
        private void sendBill()
        {
            //int daysNo = CalcHowManyDays();
            //DayTextBox.Text = daysNo.ToString();
            ArabicTextBox.Text = TotalArabic.ToString();
        }

        private void PerosnalInfoBox_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Show();
            Days.Hide();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }

        private void DaysBox_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Show();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }

        private void FoodBox_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Show();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Hide();
        }

        private void BillBox_Click(object sender, EventArgs e)
        {
            PersonalInformationPanel.Hide();
            Days.Hide();
            ResturantPanel.Hide();
            ArabicPanel.Hide();
            ItalicPanel.Hide();
            BillPanel.Show();
        }

        private void ExitBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackBox_Click(object sender, EventArgs e)
        {
            new Home().Show();
            this.Hide();
        }
    }
}
