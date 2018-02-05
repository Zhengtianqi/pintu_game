using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 拼图
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            Bitmap lImage = new Bitmap("G:\\CS\\20160525\\1430200029\\Panel\\bin\\Debug\\Boy.jpg");
            fButtoons = new PictureBox[4, 4];
            for(int i=0;i<4;i++)
                for (int j = 0; j < 4; j++)
                {
                    fButtoons[i, j] = new PictureBox();
                    fButtoons[i, j].Size = new Size(75, 75);
                    fButtoons[i, j].Location = new Point(i * 75, j * 75);
                    fButtoons[i, j].BorderStyle = BorderStyle.FixedSingle;
                    fButtoons[i, j].Image=lImage.Clone(fButtoons[i, j].Bounds, lImage.PixelFormat);
                    fButtoons[i, j].Click += new System.EventHandler(this.fButtoons_Click);
                    //添加到拼版矩阵
                    Pnlbuttons.Controls.Add(fButtoons[i, j]);
                }
            fBlankButton=fButtoons[3,3];
            fBlankButton.Visible = false;
        }
        private void fMoveButtonWithBlank(PictureBox aButton)
        {
            Point t = aButton.Location;
            aButton.Location = fBlankButton.Location;
            fBlankButton.Location = t;
        }
     private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void fButtoons_Click(object sender, EventArgs e)
        {
           PictureBox lCurrentButton = sender as PictureBox;
           //判断一下lCurrentButton和fBlankButton的相邻关系
           if (!((lCurrentButton.Top == fBlankButton.Top && Math.Abs(lCurrentButton.Left - fBlankButton.Left) == 75) || (lCurrentButton.Left == fBlankButton.Left && Math.Abs(lCurrentButton.Top - fBlankButton.Top) == 75)))
               return;
            fMoveButtonWithBlank(lCurrentButton);
        }

        }

       
    }

