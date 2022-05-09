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
    public partial class BookSearch : Form
    {
        public BookSearch()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BookSearch_Load(object sender, EventArgs e)
        {
            lbıdStudentSearch.Visible = false;
            dataGridView2.DataSource = Book_BL.BookList(); // Form açıldığında datagrid üzerine veritabanındaki listeyi aktardık
            //Bazı sütunların tabloda görünümünü kapattık
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();  // Picturebox ' a tıklanınca uyguylamayı kapattık
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")  //text doluluğu kontrol edildi
            {
                Book_Data book = new Book_Data()  //Kitap veriden nesne oluşturuldu
                {
                    BkId = int.Parse(textBox1.Text)  // Id aktarıldı
                };

                book = Book_BL.BookIdInfo(book);  // Id bilgisi nesneye aktarıldı
                label8.Text = book.BkName;
                label10.Text = book.BkType;
                label9.Text = book.BkPage;
                label11.Text = book.BkWriter;

                Student_Book_Data studentBook = new Student_Book_Data()  // Kitap öğrenci veriden nesne oluşturuldu
                {
                    BkId = int.Parse(textBox1.Text)  // Kitap ıd 'si aktarıldı
                };

                if (Book_BL.BookQuery_BL(book) != false)  // Kitabın mevcut olup olmadığı kontrol edildi
                {
                    dataGridView1.DataSource = Book_Return_BL.studentBookList(studentBook);  // Lİste datagride aktarıldı
                    //Sütun başlıkları düzenlendi
                    dataGridView1.Columns[1].HeaderText = "Name";
                    dataGridView1.Columns[2].HeaderText = "Lastname";
                    dataGridView1.Columns[6].HeaderText = "Is It Delivered?";
                }

                else
                    MessageBox.Show("The book belonging to the entered id does not exist !");
            }

            else
                MessageBox.Show("Please enter the book id");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Student_Information student = new Student_Information();             //  Ogrenci  formundan nesne üretildi
            student.lbIdStdnt.Text = lbıdStudentSearch.Text;  // Ogrenci Id yi aktardık
            this.Hide();                                       // Bulunduğumuz form ekranı kapatıldı
            student.Show();                                   // Ogrenci nesnesini kullanarak ogrenci formu açıldı
        }
    }
}
