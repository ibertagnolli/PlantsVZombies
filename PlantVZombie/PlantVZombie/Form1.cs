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
        Random rand = new Random();
        List<PictureBox> foods = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void MakePictureBox()
        {
            PictureBox food = new PictureBox();
            food.Height = 20;
            food.Width = 20;
            food.BackColor = Color.Red;

            int x = rand.Next(10, this.ClientSize.Width - food.Width);
            int y = rand.Next(10, this.ClientSize.Height- food.Height);
            food.Location = new Point(x, y);
            //food.Image = deadplant.png;
            food.Click += food_Click;

            foods.Add(food);
            this.Controls.Add(food);

        }

        private void food_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        private void TimerEvent(object sender, EventArgs e)
        {
            MakePictureBox();

        }
    }
}
