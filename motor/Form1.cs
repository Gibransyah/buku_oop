using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using WinFormsApp1;

namespace motor

{
    public partial class Form1 : Form
    {
        MySqlConnection koneksi = connections.getConnection();
        DataTable dataTable = new DataTable();

        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filldataTable();

        }
        public DataTable getDataBuku()
        {
            resetIncrement();
            dataTable.Reset();
            dataTable = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM buku", koneksi))
            {
                koneksi.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dataTable.Load(reader);
            }
            koneksi.Close();
            return dataTable;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }
        public void filldataTable()
        {
            dataGridView1.DataSource = getDataBuku();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;

            koneksi.Open();
            try
            {
                
                cmd = koneksi.CreateCommand();
                cmd.CommandText = "INSERT INTO `buku` (`judul`, `genre`, `deskripsi`, `rating`) VALUE(@judul,@genre,@deskripsi,@rating)";
                cmd.Parameters.AddWithValue("@judul", textBox2.Text);
                cmd.Parameters.AddWithValue("@genre", textBox3.Text);
                cmd.Parameters.AddWithValue("@deskripsi", textBox4.Text);
                cmd.Parameters.AddWithValue("@rating", textBox6.Text);

                cmd.ExecuteNonQuery();

                // long id = cmd.LastInsertedId;
                koneksi.Close();
                resetIncrement();
                dataGridView1.Columns.Clear();
                dataTable.Clear();
                filldataTable();
            }

            catch (Exception ex)
            {
                

            }

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Lakukan aksi ketika button submit di-klik

            MySqlCommand cmd;

            // conn.Open()
            try
            {
                // resetIncrement();

                //cmd = koneksi.CreateCommand();
                //cmd.CommandText = "INSERT INTO buku(judul, genre, deskripsi, rating) VALUE(@judul,@genre,@deskripsi,@rating)";
                //cmd.Parameters.AddWithValue("@judul", textBox2.Text);
                //cmd.Parameters.AddWithValue("@genre", textBox3.Text);
                //cmd.Parameters.AddWithValue("@deskripsi", textBox4.Text);
                //cmd.Parameters.AddWithValue("@rating", textBox6.Text);

                //cmd.ExecuteNonQuery();

                //// long id = cmd.LastInsertedId;
                //koneksi.Close();

                //dataGridView1.Columns.Clear();
                //dataTable.Clear();
                //filldataTable();
            }
            catch (Exception ex)
            {
                // ex.message.EndsWith("")
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(string ValueToFind)
        {
            string searchQuery = "SELECT * FROM buku WHERE CONCAT(judul, genre, deskripsi, rating) LIKIE '%" + ValueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, koneksi);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5_TextChanged(button4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;

            try
            {

                koneksi.Open();
                cmd = koneksi.CreateCommand();
                cmd.CommandText = "UPDATE `buku` SET `judul`=@judul, `genre`=@genre, `deskripsi`=@deskripsi, `rating`=@rating where `id`=@id";
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@judul", textBox2.Text);
                cmd.Parameters.AddWithValue("@genre", textBox3.Text);
                cmd.Parameters.AddWithValue("@deskripsi", textBox4.Text);
                cmd.Parameters.AddWithValue("@rating", textBox6.Text);
                cmd.ExecuteNonQuery();
                koneksi.Close();
                dataGridView1.Columns.Clear();
                dataTable.Clear();
                resetIncrement();
                filldataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());

            MySqlCommand cmd;

            try
            {
                resetIncrement();
                koneksi.Open();
                cmd = koneksi.CreateCommand();
                cmd.CommandText = "DELETE FROM buku WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[id].Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                koneksi.Close();
                dataGridView1.Columns.Clear();
                dataTable.Clear();

                filldataTable();
            }
            catch (Exception ex)
            {

            }

        }
        public void resetIncrement()
        {
            MySqlScript script = new MySqlScript(koneksi, "SET @id :=0; Update buku SET id = @id := (@id+1); " + "ALTER TABLE buku AUTO_INCREMENT = 1;");
            script.Execute();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}





















