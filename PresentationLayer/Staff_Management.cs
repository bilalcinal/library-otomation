using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Staff_Management : Form
    {
        public Staff_Management()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Book_Management book = new Book_Management();  // Nesne oluşturuldu
            this.Hide();                                 // Aktif form kapatıldı
            book.Show();                               // Oluşturulan nesneden yeni form açıldı
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Student_Management student = new Student_Management(); //Nesne oluşturuldu
            this.Hide();                                      // aktif form kapatıldı
            student.Show();                                  // oluşturulan nesneden yeni form açıldı
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Student_Management student = new Student_Management(); //Nesne oluşturuldu
            this.Hide();                                      // aktif form kapatıldı
            student.Show();                                  // oluşturulan nesneden yeni form açıldı

        }
      
      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Staff_Access_Menu staffAccess = new Staff_Access_Menu(); //Nesne oluşturuldu
            this.Hide();                                           //aktif form kapatıldı
            staffAccess.Show();                                  // oluşturulan nesneden yeni form açıldı
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit(); // Uygulama kapatıldı
        }
    }
}
