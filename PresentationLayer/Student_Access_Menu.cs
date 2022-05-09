using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using DataAccessLayer;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class Student_Access_Menu : Form
    {
        public Student_Access_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "") //Textlerin boş bırakılmaması kontrol edildi
            {
                Student_Data student = new Student_Data()       //Entity katmanındaki verilere girilen değerler aktarıldı
                {
                    StdntNo = textBox1.Text,
                    StdntPassword = textBox2.Text

                };

                if (Student_BL.studentControl_BL(student) == true) // Veritabanındaki tabloda girilen değerlere ait öğrenci var mı kontrol edildi
                {
                    label3.Text = Student_BL.studentIdQuery(student).ToString(); //id ataması yapıldı
                    MessageBox.Show("Login successful");
                    Student_Information stdnt = new Student_Information();
                     stdnt.lbIdStdnt.Text = label3.Text;
                    this.Hide();                         // Şuan bulunduğumuz form kapatıldı
                    stdnt.Show();                 // Oluşturulan nesne ile geçiş yapılacak form ekranı açıldı


                }
                else
                    MessageBox.Show("incorrect entry!");

            }

            else
            {
                MessageBox.Show("Fill in the required fields!");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.CheckState == CheckState.Checked) // CheckBox seçili ise parolayı goster text e gizle yaz
            {
                textBox2.UseSystemPasswordChar = true;  // Parolayı göster 
                checkBox1.Text = "Hidden";                 // CheckBox textini gizle olarak değiştir
            }
            else if (checkBox1.CheckState == CheckState.Unchecked) // ChecBox seçili değil ise parolayı gizle ve text e göster yaz
            {
                textBox2.UseSystemPasswordChar = false;  // Parolayı gizle
                checkBox1.Text = "Show";                 // CheckBox textini goster olarak değiştir
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); // kapatma picture box ına basılınca uygulamayı kapatmasını sağladık.
        }

       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ogrenci NO textbox'ına harf girisini engelledik
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Student_Access_Menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main_Menu main = new Main_Menu(); // Geçiş yapılacak formdan nesne oluşturuldu
            this.Hide();                                  // Şuan bulunduğumuz form ekranı kapatıldı
            main.Show();                            // Oluşturulan nesne ile geçiş yapılan form ekran açıldı
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
