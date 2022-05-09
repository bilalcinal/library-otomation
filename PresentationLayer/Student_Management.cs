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
    public partial class Student_Management : Form
    {
        

        public Student_Management()
        {
            InitializeComponent();
        }

        public void lbStdntmang_Click(object sender, EventArgs e)
        {

        }

        private void Student_Management_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Student_BL.list(); // Form açıldığında datagrid üzerine veritabanındaki listeyi aktardık
            // Tablodaki görünümü iyileştirmek için genişliğini ayarladık ve isimlerini düzenledik.
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "School No";
            dataGridView1.Columns[3].HeaderText = "Lastname";
            dataGridView1.Columns[4].HeaderText = "Password";
            dataGridView1.Columns[5].HeaderText = "Fine";

            // Form açıldığında guncelleme kısmındaki textboxların ve gunceleme için gerekli id nin boş kalmasını  sağladık.
            id = 0;
            textBox5.Text = "";
            textBox8.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            

        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();  // Picturebox ' a tıklanınca uyguylamayı kapattık
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ekleme işlemi için textboxların dolu olup olmadığını kontrol ettik
            if (textBox1.Text != "" && textBox9.Text != "" && textBox2.Text != "" && textBox3.Text != ""  )
            {
                //Entity katmanındaki değişkenlere textboxtaki verileri aktardık
                Student_Data student = new Student_Data()
                {
                    StdntName = textBox1.Text,
                    StdntLastname = textBox9.Text,
                    StdntNo = textBox2.Text,
                    StdntPassword = textBox3.Text,
                    
                };
                if (Student_BL.studentNoControl(student) == true)  // Öğrencinin kayıtlı olma durumu kontrol edildi
                {

                    Student_BL.studentAdd(student);  //business katmanındaki ogrenciEkle fonksiyonuna verileri gönderdik
                    MessageBox.Show("Added");
                    dataGridView1.DataSource = Student_BL.list(); // Ekleme işleminden sonra listenin güncel halini ekrana yansıttık

                }

                else
                {
                    MessageBox.Show("A different student from the entered school number, please change the entered school number!");
                }

                //Ekleme işlemi bitince textboxları temizledik
                textBox1.Text = "";
                textBox9.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                

            }

            else
            {
                MessageBox.Show("Please fill in the required fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Id nin girilmesini kontrol ettik
            if (textBox4.Text != "")
            {
                //Entity katmanındaki OgrenciId değişkenine textboxtaki veriyi aktardık
                Student_Data student = new Student_Data()
                {
                    StdntId = int.Parse(textBox4.Text)
                };

                //Girilen id ye ait ogrenci kontrol edildi
                if (Student_BL.studentQuery_BL(student) == true)
                {
                    Student_BL.studentDelete(student); // Business katmanındaki ogrenciSİL Fonksiyonuna silme işlemi için verileri gönderdik
                    MessageBox.Show("Deleted");
                    dataGridView1.DataSource = Student_BL.list(); // Lİstenin güncel halini datagrid e yansıttık
                    textBox4.Text = ""; // Silme işleminden sonra textbox ı temizledik
                }

                else
                    MessageBox.Show("Invalid Id !");

            }
            else
                MessageBox.Show("Fill in the required fields!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Güncelleme işlemi için textboxların dolu olup olmadığını kontrol ettik
            if (textBox5.Text != "" && textBox8.Text != "" && textBox6.Text != "" && textBox7.Text != "" )
            {
                //Entity katmanındaki değişkenlere textboxtaki verileri aktardık
                Student_Data student = new Student_Data()
                {
                    StdntName = textBox5.Text,
                    StdntLastname = textBox8.Text,
                    StdntNo = textBox6.Text,
                    StdntPassword = textBox7.Text,
                    
                    StdntId = id
                };

                // Girilen id ye ait ogrenci kontrol edildi
                if (Student_BL.studentQuery_BL(student) == true)
                {
                    if (Student_BL.studentNoControl(student) == true || firstNo == student.StdntNo.ToString())
                    {
                        Student_BL.studentUpdate(student);// Business katmanındaki ogrenciGuncelle Fonksiyonuna guncelleme işlemi için verileri gönderdik
                        MessageBox.Show("Updated");
                        dataGridView1.DataSource = Student_BL.list();// Lİstenin güncel halini datagrid e yansıttık
                                                                    //Güncelleme işlemi bitince textboxları temizledik
                        textBox5.Text = "";
                        textBox8.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        
                    }
                    else
                    {
                        MessageBox.Show("There is a student belonging to the school number you want to update, please change the entered school number!");
                    }

                }

                else
                    MessageBox.Show("Please fill in the values ​​after choosing from the list !");
            }

            else
            {
                MessageBox.Show("Please fill in the required fields");
            }
        }
        //id yi genel olarak kullanacağım için global tanımladım.
        int id;
        string firstNo;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //Tablo üzerinde tıklanan satırın verilerini guncelleme alanındaki textboxlara yazdırdık
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
           
            firstNo = textBox6.Text;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Staff_Management staff = new Staff_Management();  //  Gorevli gecisformundan nesne üretildi
            this.Hide();                                       // Bulunduğumuz form ekranı kapatıldı
            staff.Show();                                   // Gorevli nesnesini kullanarak gorevli gecis formu açıldı
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
