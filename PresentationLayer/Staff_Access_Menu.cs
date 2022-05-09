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
using BusinessLayer;

namespace PresentationLayer
{
    public partial class Staff_Access_Menu : Form
    {
        

        public Staff_Access_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "") // Textler boş olup olmadığı kontrol edildi
            {
                Staff_Data staff = new Staff_Data()  // Girilen veriler entity katmanındaki değişkenlere atandı
                {
                    StfIn = textBox1.Text,
                    StfPassword = textBox2.Text
                };

                if (Staff_BL.staffControl_BL(staff) == true) //Girilen değerler veri tabanındaki tabloda mevcut ise işlem gerçekleşti
                {
                    MessageBox.Show("Login successful");
                    Staff_Management staffManagement = new Staff_Management(); // Gorevli geçiş formundan nesne üretildi
                    this.Hide();                                           // Bulunduğumuz fonksiyon kapatıldı
                    staffManagement.Show();                                  // Oluşturulan nesnenin formu açıldı
                }

                else
                {
                    MessageBox.Show("incorrect entry");
                }

            }

            else
            {
                MessageBox.Show("fill in the required fields");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); // Picturebox' a tıklayınca uygulamayı kapatma
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //TC kimlik textbox'ına harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked) //CheckBox seçili ise parolayı goster text e gizle yaz
            {
               textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "Hidden";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked) //CheckBox seçili değil ise parolayı gizle ve text e göster yaz
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Show";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Main_Menu main = new Main_Menu(); //Geçiş yapılacak formdan nesne oluşturuldu.
            this.Hide();                                  //Şuan ki form ekranı kapatıldı.
            main.Show();                            //Geçiş yapılan form ekranı açıldı.
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
