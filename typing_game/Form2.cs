using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace typing_game
{
    public partial class Form2 : Form
    {
        StreamReader sr;
        long[] charSize = new long[10];
        public Form2()
        {
            InitializeComponent();
        }

        private void typingBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && typingBox.Text == jaTxtLabel.Text)
            {
                typingBox.Text = "";
                e.Handled = true;

                if (sr.Peek() != -1)
                {
                    jaTxtLabel.Text = sr.ReadLine();
                }
                else
                {
                    gameClear();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sr = new StreamReader(@"D:\Ryo\workspace\typing_game\typing_game\script.txt");

            gameClearLabel.Hide();
            jaTxtLabel.Text = sr.ReadLine();
        }

        private void gameClear()
        {
            jaTxtLabel.Hide();
            typingBox.Hide();
            gameClearLabel.Show();
        }

        private void gamePrepare()// スクリプトの区切りごとに文字数を数えて配列におさめる
        {
            long sum;
            while (true)
            {
                while (sr.ReadLine() != "")
                {
                    
                }
            }
        }
    }
}
