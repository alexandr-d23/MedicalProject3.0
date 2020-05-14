using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Captcha : Form
    {
        private ProfileInfo owner;
        private String text;
        public Captcha(ProfileInfo owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private Bitmap Capcha(int Width, int Length)
        {
            Random random = new Random();
            Bitmap result = new Bitmap(Width, Length);
            int xPos = 10;
            int yPos = 10;

            Brush[] colorLetters =
            {
                Brushes.DarkSeaGreen,
                Brushes.Gray,
                Brushes.BlueViolet,
                Brushes.DarkOliveGreen,
                Brushes.DarkViolet
            };

            Pen[] colorLines =
            {
                Pens.LightSlateGray,
                Pens.LightSalmon,
                Pens.LightGoldenrodYellow,
                Pens.LightBlue,
                Pens.LightSeaGreen

            };

            FontStyle[] fontstyle =
            {
            FontStyle.Bold,
            FontStyle.Italic,
            FontStyle.Regular,
            FontStyle.Strikeout,
            FontStyle.Underline
            };

            Int16[] rotate = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };

            Graphics grapth = Graphics.FromImage((Image)result);
            grapth.RotateTransform(random.Next(rotate.Length));

            text = string.Empty;
            string buffer = "IloveYouSashMilash14567FHF8CdcsXhngV9H00xsa98g76DC5hgnbHGBFkhmjghnbD43NHN234";
            for(int i = 0; i<5; ++i)
            {
                text += buffer[random.Next(buffer.Length)];
            }
            grapth.DrawString(text, new Font("Arial", 25, fontstyle[random.Next(fontstyle.Length)]),
                colorLetters[random.Next(colorLetters.Length)], new PointF(xPos,yPos));
            
            grapth.DrawLine(colorLines[random.Next(colorLines.Length)],
            new Point(0, Length - 1),
            new Point(Width - 1, 0));

            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Length; ++j)
                    if (random.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.Transparent);

            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.Capcha(pictureBox1.Width, pictureBox1.Height);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.Capcha(pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (text.ToLower() == richTextBox1.Text.ToLower())
            {
                owner.passportDataShow();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверно, попробуйте еще раз");
                pictureBox1.Image = this.Capcha(pictureBox1.Width, pictureBox1.Height);
                richTextBox1.Text = "";
            }
        }

       
    }
}
