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

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Column + e.Row) % 2 == 1)
                e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
        }   



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            byte[,] redColorArray = new byte[8, 8];
            byte[,] greenColorArray = new byte[8, 8];
            byte[,] blueColorArray = new byte[8, 8];
            sbyte x = -4, y = -4;
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


            //Create tablelayoutpanel to put in the next forms
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.ColumnCount = 8;
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.Location = new System.Drawing.Point(12, 12);
            tlp.Name = "tableLayoutPanel1";
            tlp.RowCount = 8;
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp.Size = new System.Drawing.Size(460, 437);
            tlp.TabIndex = 0;
            //tlp.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);

            //Label currLabel = System.Windows.Forms.Label();
            //PictureBox currBox = System.Windows.Forms.PictureBox();
            Label currLabel = new Label();
            TableLayoutPanelCellPosition pos;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    currLabel = new System.Windows.Forms.Label();
                    currLabel.Text = "R: " + redColorArray[ i, j].ToString();
                    currLabel.BackColor = Color.FromArgb(redColorArray[i, j],greenColorArray[i, j], blueColorArray[i, j] );
                    tlp.Controls.Add(currLabel, i, j);
                    pos = tlp.GetCellPosition(currLabel);
                    currLabel.Width = tlp.GetColumnWidths()[pos.Column] - 10;
                    currLabel.Height = tlp.GetRowHeights()[pos.Row] - 10;

                }
            }
            Form redForm = new Form2();
            redForm.Controls.Add(tlp);
            redForm.Show();


            //Create tablelayoutpanel to put in the next forms
            TableLayoutPanel tlp1 = new TableLayoutPanel();
            tlp1.ColumnCount = 8;
            tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.Location = new System.Drawing.Point(12, 12);
            tlp1.Name = "tableLayoutPanel1";
            tlp1.RowCount = 8;
            tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp1.Size = new System.Drawing.Size(460, 437);
            tlp1.TabIndex = 0;
            //tlp.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);

            //Label currLabel = System.Windows.Forms.Label();
            //PictureBox currBox = System.Windows.Forms.PictureBox();
            Label currLabel1 = new Label();
            TableLayoutPanelCellPosition pos1;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    currLabel1 = new System.Windows.Forms.Label();
                    currLabel1.Text = "G: " + greenColorArray[i, j].ToString();
                    currLabel1.BackColor = Color.FromArgb(redColorArray[i, j], greenColorArray[i, j], blueColorArray[i, j]);
                    tlp1.Controls.Add(currLabel1, i, j);
                    pos1 = tlp1.GetCellPosition(currLabel1);
                    currLabel1.Width = tlp1.GetColumnWidths()[pos1.Column] - 10;
                    currLabel1.Height = tlp1.GetRowHeights()[pos1.Row] - 10;

                }
            }
            Form greenForm = new Form3();
            greenForm.Controls.Add(tlp1);
            greenForm.Show();

            //Create tablelayoutpanel to put in the next forms
            TableLayoutPanel tlp2 = new TableLayoutPanel();
            tlp2.ColumnCount = 8;
            tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.Location = new System.Drawing.Point(12, 12);
            tlp2.Name = "tableLayoutPanel1";
            tlp2.RowCount = 8;
            tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tlp2.Size = new System.Drawing.Size(460, 437);
            tlp2.TabIndex = 0;
            //tlp.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);

            //Label currLabel = System.Windows.Forms.Label();
            //PictureBox currBox = System.Windows.Forms.PictureBox();
            Label currLabel2 = new Label();
            TableLayoutPanelCellPosition pos2;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    currLabel2 = new System.Windows.Forms.Label();
                    currLabel2.Text = "B: " + blueColorArray[i, j].ToString();
                    currLabel2.BackColor = Color.FromArgb(redColorArray[i, j], greenColorArray[i, j], blueColorArray[i, j]);
                    tlp2.Controls.Add(currLabel2, i, j);
                    pos2 = tlp2.GetCellPosition(currLabel2);
                    currLabel2.Width = tlp2.GetColumnWidths()[pos2.Column] - 10;
                    currLabel2.Height = tlp2.GetRowHeights()[pos2.Row] - 10;

                }
            }

            Form blueForm = new Form4();
            blueForm.Controls.Add(tlp2);
            blueForm.Show();
        }
        
    }
}
