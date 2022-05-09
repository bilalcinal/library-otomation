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
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Staff_Access_Menu stfAccess = new Staff_Access_Menu(); // Gorevli giris formundan nesne oluşturuldu
            this.Hide();                                       // Bulunan form kapatıldı
            stfAccess.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Student_Access_Menu stdAccess = new Student_Access_Menu(); // Geçiş yapılacak formdan nesne oluşturuldu
            this.Hide();                                       // Şuan bulunduğumuz form ekranı kapatıldı
            stdAccess.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
