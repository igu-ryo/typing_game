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
        long[] charSize = new long[10];
        long clearSize;
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
            scriptReader = new StreamReader(@"..\..\script.txt");
            timeReader = new StreamReader(@"..\..\timeLimit.txt");
            gameClearLabel.Hide();
            gamePrepare();
            for (int j = 0; j <= sectionLen; j++)
                Console.WriteLine($"charSize[{j}] = {charSize[j]}");
            setLimit();
            scriptReader = new StreamReader(@"..\..\script.txt");
            jaTxtLabel.Text = scriptReader.ReadLine();
            
        }

        private void gameEnd()
        {
            sectionClearFlg = true;// 入力を受け付けないようにする
            jaTxtLabel.Hide();
            typingBox.Hide();
            gameClearLabel.Show();
        }

        private void gamePrepare()// スクリプトの区切りごとに文字数を数えて配列におさめる
        {
            sectionLen = 0;
            
            while (true)
            {
                string text;
                do
                {
                    text = scriptReader.ReadLine();
                    charSize[sectionLen] += text.Length;
                    if (scriptReader.EndOfStream == true) return;
                }
                while (text != "");
                sectionLen++;
                if (sectionLen % 10 == 0) Array.Resize(ref charSize, charSize.Length + 10);
                
            }
            
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
