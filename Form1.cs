using System;
using System.IO;
using System.Windows.Forms;

namespace Paperman.orxan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count = 0;

        
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text file (*.txt)|*.txt";
            sv.FileName = "Document" + count;

            if (sv.ShowDialog() == DialogResult.OK)
            {
                File.Create(sv.FileName).Close();
                MessageBox.Show("Fayl uğurla save olundu!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text file (*.txt)|*.txt";

            if (op.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(op.FileName))
                {
                    MessageBox.Show("Fayl yolu tapılmadı", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    File.AppendAllText(op.FileName, richTextBox1.Text + Environment.NewLine);
                    MessageBox.Show("Məlumat fayla yazıldı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All files (*.*)|*.*";

            if (op.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(op.FileName))
                {
                    MessageBox.Show("Fayl yolu tapılmadı", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult d = MessageBox.Show("Fayl silinsinmi?", "Sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        File.Delete(op.FileName);
                        MessageBox.Show("Fayl silindi!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text file (*.txt)|*.txt";

            if (op.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(op.FileName))
                {
                    MessageBox.Show("Fayl yolu tapılmadı", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    richTextBox1.Text = File.ReadAllText(op.FileName);
                    MessageBox.Show("Fayl oxundu!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
