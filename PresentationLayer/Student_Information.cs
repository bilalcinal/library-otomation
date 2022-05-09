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
    public partial class Student_Information : Form
    {
        public Student_Information()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Student_Information_Load(object sender, EventArgs e)
        {

            StdntInformationList(); // Ogrenci bilgilerinin tutulduğu fonksiyon çağrıldı
            
            Received_Book_Data bookReturnData = new Received_Book_Data()  // nesne oluşturuldu
            {
                StdntId = int.Parse(lbIdStdnt.Text)  //id ataması yapıldı
            };
            dataGridView1.DataSource = Book_Return_BL.StudentIdList(bookReturnData); // Form açıldığında datagrid üzerine veritabanındaki listeyi aktardık

            // Bir sütunu gizledik ve diğer sütunların başlıklarını düzenledik
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Book Name";
            dataGridView1.Columns[2].HeaderText = "Taken Date";
            dataGridView1.Columns[3].HeaderText = "Delivery Date";
            dataGridView1.Columns[4].HeaderText = "Is it delivered ?";

            Book_Return_Data rtrn = new Book_Return_Data()  // nesne oluşturuldu
            {
                StdntId = int.Parse(lbIdStdnt.Text)  // id ataması yapıldı
            };
            comboBox1.DataSource = Book_Return_BL.TakeBookList(rtrn); //Combobox a alinabilicek kitaplar aktarıldı
            comboBox2.DataSource = Book_Return_BL.BookDeliveryList(rtrn); // Combobox ateslim edilecek kitaplar aktarıldı
            ListColoring();  // Tablodaki satırları renklendirme fonksiyounu çağrıldı
        }
        public void StdntInformationList()  //Ogrencinin bilgilerinin tutulduğu fonksiyon
        {
            Student_Data student = new Student_Data()  // Ogrenci veriden nesne oluşturuldu
            {
                StdntId = int.Parse(lbIdStdnt.Text) //Id ogrenci ıd ' ye aktarıldı
            };

            //Ogrenci bilgileri labellara aktarıldı
            student = Student_BL.studentIdInfo(student);
           
            name.Text = student.StdntName;
            lastname.Text = student.StdntLastname;
            no.Text = student.StdntNo;
            password.Text = student.StdntPassword;
            label8.Text = student.StdntFine.ToString();
        }

        public void
            ListColoring() //Tabloda teslim sürelerinin gecikme veya teslim edilme durumlarına göre renklendirme yapıldı
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) // Tablo satırı kadar döndürüldü
            {
                DataGridViewCellStyle color = new DataGridViewCellStyle(); //Nesne oluşturuldu

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value) ==
                    true) // teslim edilme durumu kontrol edildi
                {
                    //Satır renklendirildi
                    color.BackColor = Color.Green;
                    color.ForeColor = Color.White;
                }

                else
                {
                    //Teslim edilmeyen kitapların teslim tarihine ne kadar kaldığı öğrenildi
                    TimeSpan conclusion = DateTime.Now - Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value);

                    // 15 gün ve üzeri ise satır kırmızı renk yapıldı
                    if (conclusion.TotalDays > 15)
                    {
                        color.BackColor = Color.Red;
                    }

                    // teslim süresine 2 gün kalmış ise satır sarı yapıldı
                    if (conclusion.TotalDays >= 13 && conclusion.TotalDays <= 15)
                    {
                        color.BackColor = Color.Yellow;
                    }
                }

                dataGridView1.Rows[i].DefaultCellStyle = color; // Satırlara renklendirme işlemi gerçekleştirildi

            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            Student_Access_Menu student = new Student_Access_Menu();  //  Ogrenci giriş formundan nesne üretildi
            this.Hide();                                       // Bulunduğumuz form ekranı kapatıldı
            student.Show();                                   // Ogrenci nesnesini kullanarak ogrenci giriş formu açıldı

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();  // Picturebox ' a tıklanınca uyguylamayı kapattık
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "") //Text in doluluğu kontrol edildi
            {
                TimeSpan ThePassingTime = DateTime.Now - dateTimePicker1.Value.Date; //zaman farkı alındı
                if (ThePassingTime.TotalDays >= 0)  // Şuanki günden ileri olup olmadığı kontrol edildi
                {

                    Student_Book_Data bookId = new Student_Book_Data() //nesne oluşturuldu
                    {
                        BkName = comboBox1.Text //Kitap adı aktarıldı
                    };


                    Book_Return_Data book = new Book_Return_Data() // nesne oluşturuldu
                    {
                        BkId = Book_Return_BL.bookId(bookId), // kitap id aktarıldı
                        StdntId = int.Parse(lbIdStdnt.Text),  // ogrenci id aktarıldı
                        BkTake = dateTimePicker1.Value.Date  // alinma tarihi aktarıldı
                    };

                    Book_Return_BL.takeBookProcess(book); // Veri tabanında alma işlemi gerçekleştirildi


                    //Güncel liste oluştruuldu
                    Received_Book_Data receivedBookData = new Received_Book_Data()
                    {
                        StdntId = int.Parse(lbIdStdnt.Text)
                    };
                    dataGridView1.DataSource = Book_Return_BL.StudentIdList(receivedBookData);
                    ListColoring();

                    //güncel kitaplar oluşturuldu
                    Book_Return_Data rtrn = new Book_Return_Data()
                    {
                        StdntId = int.Parse(lbIdStdnt.Text)
                    };
                    comboBox1.DataSource = Book_Return_BL.TakeBookList(rtrn);
                    comboBox2.DataSource = Book_Return_BL.BookDeliveryList(rtrn);

                    MessageBox.Show("Book received.");
                }
                else
                {
                    MessageBox.Show("The purchase date cannot be later than today!");
                }
            }
            else
            {
                MessageBox.Show("No book available.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BookSearch student = new BookSearch();  //  Kitap arama formundan nesne üretildi
            student.lbıdStudentSearch.Text = lbIdStdnt.Text; //id ataması yapıldı
            this.Hide();                           // Bulunduğumuz form ekranı kapatıldı
            student.Show();                       // Ogrenci nesnesini kullanarak ogrenci giriş formu açıldı
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Graphic student = new Graphic();  //  Grafik formundan nesne üretildi
            student.lbıdstdntGraphic.Text = lbIdStdnt.Text; //id ataması yapıldı
            this.Hide();                           // Bulunduğumuz form ekranı kapatıldı
            student.Show();                       // Ogrenci nesnesini kullanarak grafik formu açıldı
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")  // text doluluğu kontrol edildi
            {
                Book_Return_Data studentId = new Book_Return_Data()  // nesne oluşturuldu
                {
                    StdntId = int.Parse(lbIdStdnt.Text) //id ataması yapıldı
                };
                Book_Return_BL.studentFine(studentId); // Ceza bilgisi çekildi
                if (studentId.StdntFine != 0)  // ceza durumu 0 değil ise...
                {
                    float fine = studentId.StdntFine - float.Parse(textBox1.Text); //ceza farkı atandı
                    if (fine >= 0)  // cezanın eksi olmaması kontrol edildi
                    {
                        studentId.StdntFine = fine; // Ogrenci cezasına aktarıldı
                        Book_Return_BL.studentFineProcess(studentId); //veri tabanı ile işlem gerçekleşti
                        StdntInformationList(); //Güncel liste çağrıldı
                        MessageBox.Show(textBox1.Text + " unit paid.");
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("The amount to be paid cannot be greater than the penalty!");
                    }
                }

                else
                {
                    MessageBox.Show("You have no debt.");
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please enter the amount to be paid!");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text != "")  // text doluluğu kontrol edildi
            {

                Student_Book_Data bookId = new Student_Book_Data() // nesne oluşturuldu
                {
                    BkName = comboBox2.Text //kitap adı aktarıldı
                };


                Book_Return_Data book = new Book_Return_Data() // nesne oluşturuldu ve bilgiler aktarıldı
                {
                    BkId = Book_Return_BL.bookId(bookId),
                    StdntId = int.Parse(lbIdStdnt.Text),
                    BkDelivery = dateTimePicker2.Value.Date,
                    BkControl = true
                };
                Book_Return_BL.bookDate(book); //alinma tarihi çekildi
                TimeSpan conclusion = book.BkDelivery - book.BkTake; // zaman farkı alındı
                if (conclusion.TotalDays >= 0) //zaman farkını eksi olamaması kontrol edildi
                {
                    Book_Return_BL.bookDeliveryProcess(book); //teslim işlemi gerçekleştirildi

                    //Güncel liste
                    Received_Book_Data receivedBookData = new Received_Book_Data()
                    {
                        StdntId = int.Parse(lbIdStdnt.Text)
                    };
                    dataGridView1.DataSource = Book_Return_BL.StudentIdList(receivedBookData);
                    ListColoring();  // tablo satırları renklendirildi

                    //Güncel  Kitap
                    Book_Return_Data rtrn = new Book_Return_Data()
                    {
                        StdntId = int.Parse(lbIdStdnt.Text)
                    };
                    comboBox1.DataSource = Book_Return_BL.TakeBookList(rtrn);
                    comboBox2.DataSource = Book_Return_BL.BookDeliveryList(rtrn);

                    if (conclusion.TotalDays > 15)  // teslim süresi 15 günü geçmiş ise ceza işlemi uygulandı
                    {
                        float fine = float.Parse(conclusion.TotalDays.ToString()) - 15;  //15 gün teslim süresini aşanlara hergün için 1 tl kesildi
                        Book_Return_BL.studentFine(rtrn); //Ceza bilgisi çekildi
                        rtrn.StdntFine += fine; //üzerine ekleme yapıldı
                        Book_Return_BL.studentFineProcess(rtrn); // Veri tabanında ceza işlemi gerçekleşti
                        StdntInformationList(); // Güncel liste 
                    }

                    MessageBox.Show(" Was delivered ");

                }

                else
                {
                    MessageBox.Show("The delivery date cannot be earlier than the date of purchase!");
                }

            }

            else
            {
                MessageBox.Show("There is no book to be delivered!");
            }
        }

        private void password_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Student_Access_Menu student = new Student_Access_Menu();  //  Ogrenci giriş formundan nesne üretildi
            this.Hide();                                       // Bulunduğumuz form ekranı kapatıldı
            student.Show();                                   // Ogrenci nesnesini kullanarak ogrenci giriş formu açıldı
        }

        private void lbIdStdnt_Click(object sender, EventArgs e)
        {

        }
    }
}
