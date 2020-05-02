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
        Timer timer1;
        StreamReader scriptReader;
        StreamReader timeReader;
        long charSize, clearSize;
        int sectionLen = 0;
        bool sectionClearFlg;
        public Form2()
        {
            InitializeComponent();
        }

        private void typingBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sectionClearFlg == true)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Enter && typingBox.Text == jaTxtLabel.Text)
            {
                clearSize += typingBox.Text.Length;
                typingBox.Text = "";
                e.Handled = true;

                string text = scriptReader.ReadLine();
                if (text == "")
                {
                    sectionClearFlg = true;
                }
                jaTxtLabel.Text = text;// 何も表示しない
                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gamePrepare();
        }

        private void gameEnd()
        {
            sectionClearFlg = true;// 入力を受け付けないようにする
            jaTxtLabel.Hide();
            typingBox.Hide();
            if (clearSize == charSize) gameClearLabel.Text = "GAME CLEAR!!";
            gameClearLabel.Show();
            scoreLabel.Text = $"{(int)(100 * clearSize / charSize)}/100 pt";
            scoreLabel.Show();
        }

        private void gamePrepare()
        {
            scriptReader = new StreamReader(@"..\..\..\test\script.txt");
            timeReader = new StreamReader(@"..\..\..\test\timeLimit.txt");
            gameClearLabel.Hide();
            scoreLabel.Hide();

            // スクリプトの文字数合計を数える
            while (true)
            {
                charSize += scriptReader.ReadLine().Length;
                if (scriptReader.EndOfStream == true) break;
            }

            // ゲーム開始
            setLimit();
            scriptReader = new StreamReader(@"..\..\..\test\script.txt");
            jaTxtLabel.Text = scriptReader.ReadLine();
        }

        private void setTimer(int interval)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(TimerEventProcessor);
            timer1.Interval = interval;
            timer1.Start();
        }

        private void setLimit()
        {
            int timeLimit = Int32.Parse(timeReader.ReadLine());
            setTimer(timeLimit);
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            timer1.Stop();
            if (sectionClearFlg == true)
            {
                

                sectionClearFlg = false;
            }
            else
            {
                // 時間内に終わらなかったら次のセクションへ
                while (true)
                {
                    if (scriptReader.ReadLine() == "") break;
                    else if (scriptReader.EndOfStream == true)
                    {
                        gameEnd();
                        return;
                    }
                }
                typingBox.Text = "";
                
            }
            setLimit();
            jaTxtLabel.Text = scriptReader.ReadLine();
        }
    }
}
