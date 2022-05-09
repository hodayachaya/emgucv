using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        Image<Bgr, byte> image;
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
        //

        private void Form1_Load(object sender, EventArgs e)
        {
            ///*using (*/
            //OpenFileDialog ofd = new OpenFileDialog();/*{ Multiselect = false, Filter = "JPEG,*.jpg" }*/
            ///* {*/ //לפתוח חלון של בחירת קובץ
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    image = new Image<Bgr, byte>(ofd.FileName);
            //    Image<Gray, byte> grayimage = image.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
            //    pictureBox1.Image = grayimage.ToBitmap();

            //}
            //for (int y = 0; y < image.Height; y++)
            //{
            //    for (int x = 0; x < image.Width; x++)
            //    {
            //        Color color = image.GetPixel(x, y);
            //        var ava = (color.R + color.B + color.G) / 3;



            //        // image.SetPixel(x,y,Color.FromArgb(color.A,ava,ava,ava));
            //        int temp;
            //        if (ava > 128)
            //            temp = 255;

            //        else
            //        {
            //            temp = 0;
            //        }

            //        image.SetPixel(x, y, Color.FromArgb(color.A, temp, temp, temp));


            //    }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*using (*/
            OpenFileDialog ofd = new OpenFileDialog();/*{ Multiselect = false, Filter = "JPEG,*.jpg" }*/
            /* {*/ //לפתוח חלון של בחירת קובץ
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image = new Image<Bgr, byte>(ofd.FileName);
                Image<Gray, byte> grayimage = image.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
                pictureBox1.Image = grayimage.ToBitmap();

            }
        }

        //עם גבולות גדולים באחת יש להעתיק תמונה למטריצת עזר
        //לשנות למעל הלמטה
        //לעשות מציאת מינימום ומקסימום


        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (image.GetPixel(x, y).B!= 0)
                        continue;
                    else                          //מצאנו נקודה שחורה
                    {
                        //כדי למצוא את כל הצורה:
                        //נמצא את כל הנקודות הדכנות השחורות
                        List<Point> points = new List<Point>();
                        List<Point> shapePoints = new List<Point>();
                        
                        //כדי שבהמשך החיפוש לא נצייחס לצורה הזו  - נהפוך את הנקודות השחורות
                        points.Add(new Point(y,x));
                       // image.SetPixel(x, y, Color.Gray);
                        //נקודה נוכחית לבדיקה
                        Point currPoint = points[points.Count - 1];
                        while (points.Count > 0)
                        {
                            if (currPoint.X <=image.Width&&  currPoint.Y <=image.Height)
                            {
                                if (image.GetPixel(currPoint.X - 1, currPoint.Y - 1).B == 0)//שמאל למעלה
                                {
                                    points.Add(new Point(currPoint.X - 1, currPoint.Y - 1));
                                    image.SetPixel(currPoint.X - 1, currPoint.Y - 1, Color.Gray);
                                }
                                if (image.GetPixel(currPoint.X , currPoint.Y-1).B == 0)//למעלה 
                                {
                                    points.Add(new Point(currPoint.X, currPoint.Y- 1));
                                    image.SetPixel(currPoint.X, currPoint.Y - 1, Color.Gray);
                                }
                                if (image.GetPixel(currPoint.X+1, currPoint.Y - 1).B == 0)// למעלה ימין
                                {
                                    points.Add(new Point(currPoint.X + 1, currPoint.Y - 1));
                                    image.SetPixel(currPoint.X + 1, currPoint.Y - 1, Color.Gray);
                                }
                                if (image.GetPixel(currPoint.X + 1, currPoint.Y ).B == 0)//ימין 
                                {
                                    points.Add(new Point(currPoint.X + 1, currPoint.Y));
                                    image.SetPixel(currPoint.X+1, currPoint.Y, Color.Gray);
                                }
                                if (image.GetPixel(currPoint.X - 1, currPoint.Y).B == 0)//שמאל 
                                {
                                    points.Add(new Point(currPoint.X - 1, currPoint.Y));
                                    image.SetPixel(currPoint.X-1, currPoint.Y, Color.Gray);
                                }
                                if (image.GetPixel(currPoint.X - 1, currPoint.Y + 1).B == 0)//שמאל למטה
                                {
                                    points.Add(new Point(currPoint.X - 1, currPoint.Y+ 1));
                                    image.SetPixel(currPoint.X-1, currPoint.Y+1, Color.Gray);
                                }
                                if (image.GetPixel(currPoint.X, currPoint.Y + 1).B == 0)//למטה
                                {
                                    points.Add(new Point(currPoint.X, currPoint.Y + 1));
                                    image.SetPixel(currPoint.X, currPoint.Y+1, Color.Gray);
                                }
                                if (image.GetPixel(currPoint.X + 1, currPoint.Y - 1).B == 0)// למטה ימין
                                {
                                    points.Add(new Point(currPoint.X + 1, currPoint.Y - 1));
                                    image.SetPixel(currPoint.X+1, currPoint.Y-1, Color.Gray);
                                }
                                points.Remove(currPoint);
                                shapePoints.Add(currPoint);
                                if (points.Count > 0)
                                    currPoint = points[points.Count - 1];
                            }
                            

                        }
                        //נשמור את הגבולות של הצורה
                        int maxX, minX, maxY, minY;
                        for (int i = 0; i < shapePoints.Count(); i++)
                        {
                            Point p = shapePoints[i];
                            maxX = 0;
                            maxY = 0;
                            if (p.X >= maxX || p.Y >= maxY)
                            {
                                minX = maxX;
                                minY = maxY;
                                maxX = p.X;
                                maxY = p.Y;

                            }


                        }

                        //הצגת הצורה הנוכחית
                        Bitmap b = new Bitmap(image.Width, image.Height);
                        for (int i = 0; i < shapePoints.Count(); i++)
                        {
                            Point p = shapePoints[i];
                            b.SetPixel(p.X, p.Y, Color.Black);
                        }
                        pictureBox1.Image = b;
                    }
                }
            }


            ////}
            ////public void changecolor()
            ////{

            ////    //Bitmap BlackAndWhite = new Bitmap(@"C:\Users\נטלי\Desktop\תוכנות הודיה\Digivert-master\Digivert\ex1.JPG ");
            ////    //var pathimage = @"C:\Users\נטלי\Desktop\תוכנות הודיה\Digivert - master\Digivert\ex1.JPG ";
            ////    ////var i = Image.FromFile(pathimage);



            ////    //image.Save(newPath, ImageFormat.Png);

            ////}
            //public void extractXY()
            //{
            //    //Bitmap bitmap;
            //    //using (Stream bmpStream = System.IO.File.Open(@"", System.IO.FileMode.Open))
            //    //{
            //    //    Image image = Image.FromStream(bmpStream);
            //    //    bitmap = new Bitmap(image);
            //    //}

            //    for (int x = 0; x < image.Width; x++)
            //    {
            //        for (int y = 0; y < image.Height; y++)
            //        {
            //            Color pixelColor = image.GetPixel(x, y);
            //            Console.WriteLine(pixelColor);
            //            Console.ReadLine();
            //            // check if it's black or a shade of black
            //            // e.g. if it belongs to an array of colors..etc
            //            // if so, record the coordinates (x,y)
            //        }
            //    }
            //}


        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}