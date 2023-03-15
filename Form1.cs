using System.Drawing.Drawing2D;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = (textBox1.Text = OPF.FileName) + ".h";
                //MessageBox.Show(OPF.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = OPF.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var FileBytes = File.ReadAllBytes(textBox1.Text);

            var Data = ByteArrayToString(FileBytes);

            var Result = textBox3.Text;
            Result = Result.Replace("__name__", Path.GetFileNameWithoutExtension(textBox1.Text).ToLower());
            Result = Result.Replace("__ext__", Path.GetExtension(textBox1.Text).Replace(".", "_").ToLower());
            Result = Result.Replace("__data__", Data);

            File.WriteAllText(textBox2.Text, Result);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder();

            for (int i = 0; i < ba.Length; i++)
            {
                hex.AppendFormat("0x{0:x2}, ", ba[i]);
                if ((i + 1) % 16 == 0)
                    hex.Append("\n");
            }

            hex.Remove(hex.Length - 2, 2);
            return hex.ToString();
        }
    }
}