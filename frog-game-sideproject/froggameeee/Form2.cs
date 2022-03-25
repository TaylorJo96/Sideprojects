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
    public partial class Form2 : Form
    {
        bool goleft = false; // boolean which will control players going left
        bool goright = false; // boolean which will control players going right
        bool jumping = false; // boolean to check if player is jumping or not
        bool hasKey = false; // default value of whether the player has the key

        int jumpSpeed = 10; // integer to set jump speed
        int force = 8; // force of the jump in an integer
        int score = 0; // default score integer set to 0

        int playSpeed = 12; //this integer will set players speed to 18
        int backLeft = 8; // this integer will set the background moving speed to 8

        int fallingDistance = 0;
        public Form2()
        {
            InitializeComponent();
            this.Location = new Point(1, 1);

           

        }


        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            List<Object> stuff = new List<Object>();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin"
                    || x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
                {
                    stuff.Add(x);

                }
            }
            fallingDistance++;

            if (health.hearts < 100)
            { heart10.Visible = false; }
            if (health.hearts <= 90)
            { heart9.Visible = false; }
            if (health.hearts <= 80)
            { heart8.Visible = false; }
            if (health.hearts <= 70)
            { heart7.Visible = false; }
            if (health.hearts <= 60)
            { heart6.Visible = false; }
            if (health.hearts <= 50)
            { heart5.Visible = false; }
            if (health.hearts <= 40)
            { heart4.Visible = false; }
            if (health.hearts <= 30)
            { heart3.Visible = false; }
            if (health.hearts <= 20)
            { heart2.Visible = false; }
            if (health.hearts <= 10)
            { heart1.Visible = false; }
            label1.Text = " hearts:" + health.hearts + " falling Distance:" + fallingDistance;

            List<PictureBox> frogandbox = new List<PictureBox>();
            frogandbox.Add(player);
            frogandbox.Add(frogbot);

            // linking the jumpspeed integer with the player picture boxes to location
            foreach (PictureBox picture in frogandbox)
            {
                picture.Top += jumpSpeed;

            }


            // refresh the player picture box consistently
            //  player.Refresh();

            // if jumping is true and force is less than 0
            // then change jumping to false
            if (jumping && force < 0)
            {
                jumping = false;
            }

            // if jumping is true
            // then change jump speed to -12 
            // reduce force by 1
            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                // else change the jump speed to 12
                jumpSpeed = 12;
            }


            //stopping player from going outside the right or left side of the screen
            if (goleft && player.Left > 100)
            {
                foreach (PictureBox picture in frogandbox)
                {
                    picture.Left -= playSpeed-2;

                }
            }

            if (goright && player.Left + (player.Width + 100) < this.ClientSize.Width)
            {

                foreach (PictureBox picture in frogandbox)
                {
                    picture.Left += playSpeed ;

                }


            }
          
            if (goright && background.Left > -1600)
            {
                background.Left -= backLeft;
                foreach (PictureBox x in stuff)
                {
                    x.Left -= backLeft;
                
                }


            }

            // if go left is true and the background pictures left is less than 2
            // then we move the background picture towards the right
            if (goleft && background.Left < 2)
            {
                background.Left += backLeft;

                // below the is the for loop thats checking to see the platforms and coins in the level
                // when they are found in the level it will move them all towards the right with the background
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" || x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key" )
                    {
                        x.Left += backLeft;
                    }
                }
            }


            // below if the for loop thats checking for all of the controls in this form
            foreach (Control x in this.Controls)
            {
                //// is X is a picture box and it has a tag of platform
                if (x is PictureBox && x.Tag == "platform" || x.Tag == "ground")
                {
                    //    // then we are checking if the player is colliding with the platform
                    //    // and jumping is set to false
                    if (frogbot.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        //        // then we do the following
                        force = 8; // set the force to 8
                        player.Top = x.Top - player.Height; // also we place the player on top of the picture box
                        frogbot.Top = frogbot.Top - frogbot.Height;
                        jumpSpeed = 0; // set the jump speed to 0
                                       //   player.Location = new Point(player.Location.X - playSpeed, player.Location.Y);
                                       // frogbot.Location = new Point(frogbot.Location.X - playSpeed, frogbot.Location.Y);

                        if(x.Tag == "platform")
                        { fallingDistance = 0; }
                        if (x.Tag == "ground")
                        {
                            if( fallingDistance > 20)
                            {
                                health.hearts = health.hearts - 5;
                            
                            }
                            if (fallingDistance > 35)
                            {

                                health.hearts = health.hearts - 10;
                            }
                            fallingDistance = 0;
                        
                        }
                    }
                }
                if (x is PictureBox && x.Tag == "key")
                {

                    if (frogbot.Bounds.IntersectsWith(x.Bounds))
                    {
                        hasKey = true;
                        this.Controls.Remove(x);
                        keySymbol.Visible = true;

                    }

                }
            }
            


            //// if the player collides with the door and has key boolean is true

            if (player.Bounds.IntersectsWith(door.Bounds) && hasKey== true)
            {
                //    // then we change the image of the door to open
                //    door.Image = Properties.Resources.door_open;
                //    // and we stop the timer
                    gameTimer.Stop();
               // MessageBox.Show("You Completed the level!!");

                this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();

                //// if the player collides with the key picture box
            }
            if (health.hearts <= 0 || player.Top + player.Height > this.ClientSize.Height + 60 )
            {
                player.Image = Properties.Resources.guts;
                gameTimer.Stop(); // stop the timer
                MessageBox.Show("You Died!!!"); // show the message box
            }
        }


        private void keyisdown(object sender, KeyEventArgs e)
        {
            //if the player pressed the left key AND the player is inside the panel
            // then we set the car left boolean to true
            if (e.KeyCode == Keys.Left)
            {
       
                goleft = true;
                player.Image = Properties.Resources.frog_boi_left;
            }
            // if player pressed the right key and the player left plus player width is less then the panel1 width          

            if (e.KeyCode == Keys.Right)
            {
          
                goright = true;
                player.Image = Properties.Resources.frog_boy_right;
            }


            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
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
            //when the keys are released we check if jumping is true
            // if so we need to set it back to false so the player can jump again
            if (jumping)
            {
                jumping = false;
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
