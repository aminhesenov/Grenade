using System.Media;

namespace Grenade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random xRandom = new Random();
        PictureBox grenade;
        PictureBox grenade2;
 
        SoundPlayer soundPlayer = new SoundPlayer(
            "D:\\C++\\Grenade\\Grenade\\Resources\\explosion.wav");

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { 
                character.Location=new Point(character.Location.X-7, character.Location.Y);   
                character.Image=Resources.runner_left;
            }
            if (e.KeyCode == Keys.Right)
            {
                character.Location = new Point(character.Location.X + 7, character.Location.Y);
                character.Image = Resources.runner_right;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*G1*/
            grenade = new PictureBox();
            grenade.Image = Resources.grenade;
            grenade.SizeMode = PictureBoxSizeMode.CenterImage;
            grenade.Size = new Size(50, 50);
            grenade.Location = new Point(xRandom.Next(0, 750), 20);

            /*G2*/
            grenade2 = new PictureBox();
            grenade2.Image = Resources.grenade;
            grenade2.SizeMode = PictureBoxSizeMode.CenterImage;
            grenade2.Size = new Size(50, 50);
            grenade2.Location = new Point(xRandom.Next(0, 750), 20);


            this.Controls.Add(grenade);
            this.Controls.Add(grenade2);
            
        }
        int count=0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (grenade != null && grenade2 != null)
            {
                
                grenade.Location = new Point(grenade.Location.X, grenade.Location.Y + 7);
                grenade2.Location = new Point(grenade2.Location.X, grenade2.Location.Y + 7);

                if (440 < grenade2.Location.Y && 440 < grenade.Location.Y)
                {
                    count++;
                }
                
                if (character.Bounds.IntersectsWith(grenade.Bounds) ||
                    character.Bounds.IntersectsWith(grenade.Bounds))
                {
                    
                    grenade.Dispose();
                    grenade2.Dispose();

                    timer1.Stop();
                    timer2.Stop();

                    soundPlayer.Play();

                    MessageBox.Show("Oyun bitti, Uduzdunuz! "+count, "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Dispose();
                }
            }

        }


    }
}
