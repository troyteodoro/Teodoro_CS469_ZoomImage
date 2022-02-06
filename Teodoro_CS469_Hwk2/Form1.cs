using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teodoro_CS469_Hwk2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private byte getRedValue(Bitmap original, int xCoord, int yCoord)
        {
            try
            {
                //Return value of red pixel
                Color originalRed = original.GetPixel(xCoord, yCoord);
                return originalRed.R;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        private byte getGreenValue(Bitmap original, int xCoord, int yCoord)
        {
            try
            {
                //Return value of red pixel
                Color originalGreen = original.GetPixel(xCoord, yCoord);
                return originalGreen.G;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        private byte getBlueValue(Bitmap original, int xCoord, int yCoord)
        {
            try
            {
                //Return value of red pixel
                Color originalBlue = original.GetPixel(xCoord, yCoord);
                return originalBlue.B;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagefileopen = new OpenFileDialog();
            imagefileopen.Filter = "Image Files(*.jpg;*.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg; *.gif; *.bmp ; *.png";
            if (imagefileopen.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(imagefileopen.FileName);
                pictureBox1.Size = pictureBox1.Image.Size;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            byte[,] redColorArray = new byte[8,8];
            byte[,] greenColorArray = new byte[8,8];
            byte[,] blueColorArray = new byte[8,8];
            byte x = -4, y = -4;
            Bitmap original = (Bitmap)pictureBox1.Image;

            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            //Edge Case
            if (coordinates.X < 8 || coordinates.Y < 8)
            {
                coordinateDisplay.Text = "Distance too close to edge. Please Try Again.";
                return;
            }

            Debug.WriteLine("Output coordinates:{0}, {1}\n", coordinates.X, coordinates.Y);
            coordinateDisplay.Text = coordinates.ToString();

            
            for (int i = 0; i < 8; i++)
            {
                
                for (int j = 0; j < 8; j++)
                {
                    redColorArray[i, j] = getRedValue(original, (coordinates.X + x), (coordinates.Y + y));
                    greenColorArray[i, j] = getGreenValue(original, (coordinates.X + x), (coordinates.Y + y));
                    blueColorArray[i, j] = getBlueValue(original, (coordinates.X + x), (coordinates.Y + y));
                }
                x++;
                y++;
            }

            Form redForm = new Form2();
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.RowCount = 8;
            tlp.ColumnCount = 8;


            redForm.Show();
            Form greenForm = new Form3();
            greenForm.Show();
            Form blueForm = new Form4();
            blueForm.Show();
        }
        
    }
}
