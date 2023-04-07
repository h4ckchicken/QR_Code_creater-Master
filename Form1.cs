using QRCoder;

namespace QR_Code_creater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.ForeColor == Color.Red)
            {
                if(button1.Text == "QR Code Oluþtur")
                {
                    MessageBox.Show("Link uzunluðu en fazla 300 karakter olabilir!", "Uyarý!");
                }
                else
                {
                    MessageBox.Show("Link length can be up to 300 characters!", "Warning!");
                }
            }
            else
            {
                string str = tbMetin.Text;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20, "#000000", "#FFFFFF");
                pictureBox1.Image = qrCodeImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbMetin.Text = null;
            pictureBox1.Image = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void tbMetin_TextChanged(object sender, EventArgs e)
        {
            // TextBox kontrolündeki metnin uzunluðunu hesaplýyoruz.
            int textLength = tbMetin.Text.Length;


            label3.Text = textLength.ToString() + " / 300";

            if (textLength > 300)
            {
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.ForeColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "Dil Seçiniz";
            button1.Text = "QR Code Oluþtur";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = "Choose Language";
            button1.Text = "QR Code Creater";
        }
    }
}