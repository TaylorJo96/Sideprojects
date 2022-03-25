using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace froggameeee
{
    public partial class Form1 : Form
    {
      
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        bool topCollision = false;
        bool bottomCollision = false;
        bool leftCollision = false;
        bool rightCollision = false;
        bool hasKey = false;
      
        int speed = 6;
        int birbmovement = 4;
        int birb2movement = 3;
      


        int score = 0;
        public Form1()
        {
     
            InitializeComponent();
            this.Location = new Point(1, 1);
            // makeLabelInvisible(label2);
            label2.Visible = false;
            keySymbol.Visible = false;
            //makepbInvisible(keySymbol);
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            pacman.BackColor = Color.Transparent;
          

        }
        private void keyisdown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacman.Image = Properties.Resources.frog_boi_left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                pacman.Image = Properties.Resources.frog_boy_right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                //    pacman.Image = Properties.Resources.pacup1;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                //   pacman.Image = Properties.Resources.pacdown1;
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            List<PictureBox> frogAndBoxes = new List<PictureBox>();
            frogAndBoxes.Add(pacman);
            frogAndBoxes.Add(frogbottom);
            frogAndBoxes.Add(frogtop);
            frogAndBoxes.Add(frogleft);
            frogAndBoxes.Add(frogright);
            label1.Text = "Score: " + score + " hearts:" + health.hearts; // show the score on the board

            //player movement codes start 

            //moving player to the left. 
            if (goleft)
            {
                GoLeft(frogAndBoxes);

                if (leftCollision == true)
                {
                    LeftCollide(frogAndBoxes);
                }

            }
            //moving player to the right
            if (goright)
            {
                GoRight(frogAndBoxes);
                if (rightCollision == true)
                {
                    RightCollide(frogAndBoxes);
                }
            }

            //moving to the top
            if (goup)
            {
                GoUp(frogAndBoxes); 
                if (topCollision == true)
                {
                    TopCollide(frogAndBoxes);
                }

            }
            //moving down
            if (godown)
            {
                GoDown(frogAndBoxes);
                if (bottomCollision == true)
                {
                    BottomCollide(frogAndBoxes);
                }

            }

            //for loop to check walls, ghosts and points
            foreach (Control x in this.Controls)
            {
                // birbStuff();
                if (x is PictureBox && x.Tag == "ghost")
                {

                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {

                        adjusthealth();

                    }
                    birb2.Left += birb2movement;
                    if (birb2.Bounds.IntersectsWith(pictureBox2.Bounds))
                    {
                        birb2movement = -birb2movement;
                     
                        birb2.Image = Properties.Resources.shrike2;

                    }
                    else if (birb2.Bounds.IntersectsWith(pictureBox25.Bounds))
                    {
                        birb2movement = -birb2movement;
                       
                       birb2.Image = Properties.Resources.birdright;
                    
                    }

                    //moving bird and bumping with the walls
                    birb.Left += birbmovement;

                    // if the birb hits the left side then we reverse the speed
                    if (birb.Bounds.IntersectsWith(pictureBox4.Bounds))
                    {
                        birbmovement = -birbmovement;
                        birb.Image = Properties.Resources.birdright;
                    }
                    // if the red ghost hits the right side we reverse the speed
                    else if (birb.Bounds.IntersectsWith(pictureBox2.Bounds))
                    {
                        birbmovement = -birbmovement;
                        birb.Image = Properties.Resources.shrike2;
                    }


                }
                
                if (x is PictureBox && x.Tag == ("coin"))
                {
                    //checking if the player hits the points picturebox then we can add to the score
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x); //remove that point
                        score++; // add to the score
                    }
                }
                if (x is PictureBox && x.Tag == ("key"))
                {
                    //checking if the player hits the points picturebox then we can add to the score
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x); //remove that point
                        keySymbol.Visible = true;
                        hasKey = true;
                    }
                }
                if (x is PictureBox && x.Tag == "wall")
                {
                    // checking if the player hits the wall or the ghost, then game is over
                    if (((PictureBox)x).Bounds.IntersectsWith(frogtop.Bounds))
                    {
                        topCollision = true;

                    }
                    if (((PictureBox)x).Bounds.IntersectsWith(frogbottom.Bounds))
                    {
                        bottomCollision = true;

                    }
                    if (((PictureBox)x).Bounds.IntersectsWith(frogleft.Bounds))
                    {
                        leftCollision = true;

                    }
                    if (((PictureBox)x).Bounds.IntersectsWith(frogright.Bounds))
                    {
                        rightCollision = true;

                    }
                }
                if (x is PictureBox && x.Tag == ("door"))
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {

                        if (hasKey == true)
                        {
                            pacman.Location = new Point(59, 13);
                            frogtop.Location = new Point(76, 23);

                            frogbottom.Location = new Point(57, 64);

                            frogleft.Location = new Point(50, 27);
                            frogright.Location = new Point(127, 27);

                            goleft = false;
                            goright = false;
                            goup = false;
                            godown = false;

                              this.Hide();
                            Form2 f2 = new Form2();
                            f2.ShowDialog();
                           
                        }
                        if (hasKey == false)
                        {
                            label3.Visible = true;
                            label4.Visible = true;
                            label5.Visible = true;
                            label6.Visible = true;
                            label7.Visible = true;
                        }

                    }
                }
            }
        }


        private void makeLabelInvisible(Label label)
        {
            label.Visible = false;
        }

        private void makepbInvisible(PictureBox pictureBox)
        {
            pictureBox.Visible = false;
        }
        private void adjusthealth()
        {
            if (health.hearts > 0)
            {
                health.hearts -= 1;

                if (health.hearts <= 100 && health.hearts > 90)
                { heart10.Visible = false; }
                if (health.hearts <= 90 && health.hearts > 80)
                { heart9.Visible = false; }
                if (health.hearts <= 80 && health.hearts > 70)
                { heart8.Visible = false; }
                if (health.hearts <= 70 && health.hearts > 60)
                { heart7.Visible = false; }
                if (health.hearts <= 60 && health.hearts > 50)
                { heart6.Visible = false; }
                if (health.hearts <= 50 && health.hearts > 40)
                { heart5.Visible = false; }
                if (health.hearts <= 40 && health.hearts > 30)
                { heart4.Visible = false; }
                if (health.hearts <= 30 && health.hearts > 20)
                { heart3.Visible = false; }
                if (health.hearts <= 20 && health.hearts > 10)
                { heart2.Visible = false; }
                  if (health.hearts <= 10 && health.hearts > 0)
                  { heart1.Visible = false; }
            }
            else
            {
                //    pacman.Left = 0;
                //    pacman.Top = 25;

                pacman.Image = Properties.Resources.guts;
                heart1.Visible = false;
                label2.Text = "GAME OVER";
                label2.Visible = true;
                speed = 0;
                //  timer1.Stop();

            }

        }
        private void LeftCollide(List<PictureBox> pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
               
                pictureBox.Location = new Point(pictureBox.Location.X + speed, pictureBox.Location.Y);
            }
            
            leftCollision = false;

        }
        public void RightCollide(List<PictureBox> pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                
                pictureBox.Location = new Point(pictureBox.Location.X - speed, pictureBox.Location.Y);
            }
            
            rightCollision = false;


        }
        public void TopCollide(List<PictureBox> pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {

                pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + speed);
            }

           
            topCollision = false;

        }
        public void BottomCollide(List<PictureBox> pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {

                pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - speed);
            }

            bottomCollision = false;
        }
        public void GoUp(List<PictureBox> pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Top -= speed;
            }

        }
        public void GoDown(List<PictureBox> pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Top += speed;
            }
        }
        public void GoLeft(List<PictureBox> pictureBoxes)
        {

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Left -= speed;
            }
        }
        public void GoRight(List<PictureBox> pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Left += speed;
            }

        
        }

        private void pacman_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}

