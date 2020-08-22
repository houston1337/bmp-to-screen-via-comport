using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace bmpTogrb

{
    public partial class Form1 : Form
    {
        string[] pic = new string[240*135]; 
        public Form1()
        {
            InitializeComponent();
            
        }
       

        public void rgb(int x, int y, int R, int G, int B)
        {
            
           
           int r5 = (R >> 3);
           int g5 = (G >> 2);
           int b5 = (B >> 3);
           

            string hex = Convert.ToString(r5, 2).PadLeft(5, '0') + Convert.ToString(g5, 2).PadLeft(6, '0') + Convert.ToString(b5, 2).PadLeft(5, '0');
            string hexres =  Convert.ToString(Convert.ToInt32(hex, 2), 16);
            pic[(x*135)+ y] = "0x" + hexres;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap image1;
            try
            {
                // Retrieve the image.
                image1 = new Bitmap(@"C:\img\j.bmp", true);

                int x, y;

                // Loop through the images pixels to reset color.
                for (x = 0; x < 240; x++)
                {
                    for (y = 0; y < 135; y++)
                    {
                        Color pixelColor = image1.GetPixel(x, y);
                        rgb(x, y, pixelColor.R, pixelColor.G, pixelColor.B);
                        //richTextBox1.Text += pic[x, y]+ ", ";
                       
                    }
                }
                label1.Text = "конвертирование завершино";
                


            }
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the image file.");
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            string writePath = @"C:\img\jtxt";

            
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < 240; i++)
                    {
                        for (int j = 0; j < 135; j++)
                        {

                            sw.WriteLine(pic[(i * 135) + j] + ", ");

                            
                        }
                    }

                    label1.Text = "запись завершина";
                }

               
            }
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." +
                   "Check the path to the image file.");
            }
        }
    }
}
