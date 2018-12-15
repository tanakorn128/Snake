using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Snake
{
    public partial class SnakeForm : Form,IMessageFilter
    {
        string name0;
        SnakePlayer Player1;
        FoodManager FoodMngr;
        Random r = new Random();
        private int score = 0;
        public SnakeForm()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
            Player1 = new SnakePlayer(this);
            FoodMngr = new FoodManager(GameCanvas.Width, GameCanvas.Height);
            FoodMngr.AddRandomFood(10);
            ScoreTxtBox.Text = score.ToString();
        }

        public void ToggleTimer()
        {
            GameTimer.Enabled = !GameTimer.Enabled;
        }

        public void ResetGame()
        {
            Player1 = new SnakePlayer(this);
            FoodMngr = new FoodManager(GameCanvas.Width, GameCanvas.Height);
            FoodMngr.AddRandomFood(10);
            score = 0;
        }

        public bool PreFilterMessage(ref Message msg)
        {
            if(msg.Msg == 0x0101) //KeyUp
                Input.SetKey((Keys)msg.WParam, false);
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(msg.Msg == 0x100) //KeyDown
                Input.SetKey((Keys)msg.WParam, true);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Player1.Draw(canvas);
            FoodMngr.Draw(canvas);
        }

        private void CheckForCollisions()
        {
            if (Player1.IsIntersectingRect(new Rectangle(-100, 0, 100, GameCanvas.Height)))
                Player1.OnHitWall(Direction.left);

            if (Player1.IsIntersectingRect(new Rectangle(0, -100, GameCanvas.Width, 100)))
                Player1.OnHitWall(Direction.up);

            if (Player1.IsIntersectingRect(new Rectangle(GameCanvas.Width, 0, 100, GameCanvas.Height)))
                Player1.OnHitWall(Direction.right);

            if (Player1.IsIntersectingRect(new Rectangle(0, GameCanvas.Height, GameCanvas.Width, 100)))
                Player1.OnHitWall(Direction.down);

            //Is hitting food
            List<Rectangle> SnakeRects = Player1.GetRects();
            foreach(Rectangle rect in SnakeRects)
            {
                if(FoodMngr.IsIntersectingRect(rect,true))
                {
                    FoodMngr.AddRandomFood();
                    Player1.AddBodySegments(1);
                    score++;
                    ScoreTxtBox.Text = score.ToString();
                }
            }
        }

        private void SetPlayerMovement()
        {
            if (Input.IsKeyDown(Keys.A))
            {
                Player1.SetDirection(Direction.left);
            }
            else if (Input.IsKeyDown(Keys.D))
            {
                Player1.SetDirection(Direction.right);
            }
            else if (Input.IsKeyDown(Keys.W))
            {
                Player1.SetDirection(Direction.up);
            }
            else if (Input.IsKeyDown(Keys.S))
            {
                Player1.SetDirection(Direction.down);
            }
            Player1.MovePlayer();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            SetPlayerMovement();
            CheckForCollisions();
            GameCanvas.Invalidate();
        }

        private void Start_Btn_Click(object sender, EventArgs e)
        {
            
                DialogResult dialog = MessageBox.Show(name0,name0,MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                ToggleTimer();
            }


                
        }

        private void DareBtn_Click(object sender, EventArgs e)
        {
            int index = r.Next(4);
            switch(index)
            {
              case 0:
                    MessageBox.Show("How dare you listen");
                    break;
              case 1:
                    MessageBox.Show("This is a dark path you are on");
                    break;
              case 2:
                    MessageBox.Show("I knew you wouldn't listen");
                    break;
              case 3:
                    MessageBox.Show("Have some food :)");
                    FoodMngr.AddRandomFood(20);
                    GameCanvas.Invalidate();
                    break;
                default:
                    break;
            }
        }

        private void GameCanvas_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        public void playcolor()
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            GameCanvas.BackColor = Color.White;
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GameCanvas.BackColor = Color.Black;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GameCanvas.BackColor = Color.White;
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            GameCanvas.BackColor = Color.Red;
        }

        private void ScoreTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ออกจากเกมสToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ออกจากเกมสToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("ddd");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SnakeForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
           
            string name = textBox1.ToString();
            name n1 = new name(name);
           
            name0 = n1.Names;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

    public class name
    {
        private string name1;

        public name(string value1)
        {
            this.name1 = value1;          
        }
        public string Names
        {
            get { return name1; }
        }


    }

}
