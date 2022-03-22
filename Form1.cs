using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace emgucv
{
    public partial class Form1 : Form
    {

        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string path = @"E:\hodaya\project\Digivert\ex1.png";
        //        Image<Bgr, byte> image = new Image<Bgr, byte>(path);
        //        pictureBox1.Image = image.ToBitmap();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, Filter = "JPEG,*.jpg" })
            { //לפתוח חלון של בחירת קובץ
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                   image = new Bitmap(ofd.FileName);
                   pictureBox1.Image = image;
               
                }
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color color = image.GetPixel(x, y);
                        var ava = (color.R + color.B + color.G) / 3;



                        // image.SetPixel(x,y,Color.FromArgb(color.A,ava,ava,ava));
                        int temp;
                        if (ava > 128)
                            temp = 255;

                        else
                        {
                            temp = 0;
                        }

                        image.SetPixel(x, y, Color.FromArgb(color.A, temp, temp, temp));


                    }
                }
               
               

            }
        }
        public void changecolor()
        {

            //Bitmap BlackAndWhite = new Bitmap(@"C:\Users\נטלי\Desktop\תוכנות הודיה\Digivert-master\Digivert\ex1.JPG ");
            //var pathimage = @"C:\Users\נטלי\Desktop\תוכנות הודיה\Digivert - master\Digivert\ex1.JPG ";
            ////var i = Image.FromFile(pathimage);


            
            //image.Save(newPath, ImageFormat.Png);

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
