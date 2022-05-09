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
    public partial class Book_Management : Form
    {
        int id;  //Global Id tanımlandı
        public Book_Management()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ekleme işlemi için textboxların dolu olup olmadığını kontrol ettik
            if (textBox1.Text != "" && comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                //Entity katmanındaki değişkenlere textboxtaki verileri aktardık
                Book_Data book = new Book_Data()
                {
                    BkName = textBox1.Text,
                    BkType = comboBox1.Text,
                    BkPage = textBox2.Text,
                    BkWriter = textBox3.Text
                };

                Book_BL.BookAdd(book);  //business katmanındaki kitapEkle fonksiyonuna verileri gönderdik
                MessageBox.Show("Added");
                dataGridView1.DataSource = Book_BL.BookList();// Ekleme işleminden sonra listenin güncel halini ekrana yansıttık


                //Ekleme işlemi bitince textboxları temizledik

                textBox1.Text = "";
                comboBox1.Text = null;
                textBox2.Text = "";
                textBox3.Text = "";

            }

            else
            {
                MessageBox.Show("Please fill in the required fields");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Book_Management_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Book_BL.BookList(); // Form açıldığında datagrid üzerine veritabanındaki listeyi aktardık
            label16.ForeColor = Color.Yellow;  // Listede bilgi listesi aktif olduğu için text rengini form açılınca değiştridik
            // Form açıldığında guncelleme kısmındaki textboxların ve gunceleme için gerekli id nin boş kalmasını  sağladık.
            textBox5.Text = "";
            comboBox2.Text = null;
            textBox6.Text = "";
            textBox7.Text = "";
            id = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Staff_Management staff = new Staff_Management(); // Nesne oluşturuldu
            this.Hide();                                      // Aktif form kapatıldı  
            staff.Show();                                  // Nesneden yeni form açıldı
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); //Form kapatıldı
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //Tablo üzerinde tıklanan satırın verilerini guncelleme alanındaki textboxlara yazdırdık
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Güncelleme işlemi için textboxların dolu olup olmadığını kontrol ettik
            if (textBox5.Text != "" && comboBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                //Entity katmanındaki değişkenlere textboxtaki verileri aktardık
                Book_Data book = new Book_Data()
                {
                    BkName = textBox5.Text,
                    BkType = comboBox2.Text,
                    BkPage = textBox6.Text,
                    BkWriter = textBox7.Text,
                    BkId = id
                };

                // Girilen id ye ait kitap kontrol edildi
                if (Book_BL.BookQuery_BL(book) == true)
                {
                    Book_BL.BookUpdate(book);// Business katmanındaki kitapGuncelle Fonksiyonuna guncelleme işlemi için verileri gönderdik
                    MessageBox.Show("Updated");
                    dataGridView1.DataSource = Book_BL.BookList();// Lİstenin güncel halini datagrid e yansıttık
                    //Güncelleme işlemi bitince textboxları temizledik
                    textBox5.Text = "";
                    comboBox2.Text = null;
                    textBox6.Text = "";
                    textBox7.Text = "";
                    id = 0;
                }

                else
                    MessageBox.Show("Please fill in the values ​​after choosing from the list !");
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
                //Entity katmanındaki KitapId değişkenine textboxtaki veriyi aktardık
                Book_Data book = new Book_Data()
                {
                    BkId = int.Parse(textBox4.Text)
                };

                //Girilen id ye ait kitap kontrol edildi
                if (Book_BL.BookQuery_BL(book) == true)
                {
                    Book_BL.BookDelete(book); // Business katmanındaki kitapSİL Fonksiyonuna silme işlemi için verileri gönderdik
                    MessageBox.Show("Deleted");
                    dataGridView1.DataSource = Book_BL.BookList(); // Lİstenin güncel halini datagrid e yansıttık
                    textBox4.Text = ""; // Silme işleminden sonra textbox ı temizledik
                }

                else
                    MessageBox.Show("Invalid Id !");

            }
            else
                MessageBox.Show("Fill in the required fields!");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       

        

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // PictureBox a tıklanınca... 
            label8.Text = "BOOK INFORMATİON LİST"; // Labeldaki yazı değişti
            label16.ForeColor = Color.Yellow;    // Bilgi label i aktif rengi aldı
            label17.ForeColor = Color.White;     // İade label i pasif rengi aldı
            label18.Text = "Note: Click on the book for which you want to learn the return information from the list and press the return information button.";
            dataGridView1.DataSource = Book_BL.BookList();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // PictureBox a tıklanınca... 
            label8.Text = "RETURN INFORMATİON LİST";     // Labeldaki yazı değişti
            label17.ForeColor = Color.Yellow;        // İade label i pasif rengi aldı
            label16.ForeColor = Color.White;       // Bilgi label i aktif rengi aldı
            Student_Book_Data book = new Student_Book_Data()
            {
                BkId = id
            };
            label18.Text = "Note: Press the book information button to return to the book information list.";
            dataGridView1.DataSource = Book_Return_BL.studentBookList(book);

            textBox5.Text = "";
            comboBox2.Text = null;
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Staff_Management staff = new Staff_Management(); // Nesne oluşturuldu
            this.Hide();                                      // Aktif form kapatıldı  
            staff.Show();                                  // Nesneden yeni form açıldı
        }
    }
}
