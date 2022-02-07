using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teodoro_CS469_Hwk2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            //if ((e.Column + e.Row) % 2 == 1)
            //    e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
            //else
            //    e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
        }   //
    }
}
