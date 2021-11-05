using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantVZombie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If the user uses the arrow keys, they should move around the mushroom sprite
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X , pictureBox1.Location.Y-20);
                return true;
            }
            if (keyData == Keys.Down)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y+20);
                return true;
            }
            if (keyData == Keys.Left)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X -20, pictureBox1.Location.Y);
                return true;
            }
            if (keyData == Keys.Right)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 20, pictureBox1.Location.Y);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
