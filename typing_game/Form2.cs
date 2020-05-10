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
using WMPLib;

namespace typing_game
{
    public partial class Form2 : Form
    {
        Timer timer1;
        StreamReader scriptReader;
        StreamReader timeReader;
        StreamReader trackReader;
        string playDirName;
        long charSize, clearSize;
        bool sectionClearFlg;
        int preTimeLimit = 0;
        WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
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

                // スクリプトが最後までいったらゲームを終了する
                if (scriptReader.Peek() == -1)
                {
                    timer1.Stop();
                    endGame();
                }

                string text = scriptReader.ReadLine();
                if (text == "")
                {
                    sectionClearFlg = true;
                }
                jaTxtLabel.Text = text;

                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            prepareGame();
        }

        private void endGame()
        {
            typingBox.Enabled = false;// 入力を受け付けないようにする
            jaTxtLabel.Hide();
            typingBox.Hide();
            if (clearSize == charSize) gameClearLabel.Text = "GAME CLEAR!!";
            gameClearLabel.Show();
            scoreLabel.Text = $"{(int)(100 * clearSize / charSize)}/100 pt";
            scoreLabel.Show();
        }

        private void prepareGame()
        {
            gameClearLabel.Hide();
            scoreLabel.Hide();
            jaTxtLabel.Hide();
            typingBox.Hide();
            countDownLabel.Hide();

            playDirName = getPlayDir();
            if (playDirName == null)
            {
                this.Close();
                return;
            }

            countScriptChar(playDirName);
        }

        private void startGame()
        {
            jaTxtLabel.Show();
            typingBox.Show();
            mediaPlayer.URL = trackReader.ReadLine();
            mediaPlayer.controls.play();
            timeReader = new StreamReader(playDirName + @"\timeLimit.txt");
            setLimit();
            scriptReader = new StreamReader(playDirName + @"\script.txt");
            jaTxtLabel.Text = scriptReader.ReadLine();

        }

        private string getPlayDir()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "遊びたいスクリプト名のフォルダを選んでください。";
            string path = Directory.GetCurrentDirectory();
            fbd.SelectedPath = path;
            while (true)
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string dirPath = fbd.SelectedPath;
                    if (!File.Exists(dirPath + @"\trackName.txt"))
                    {
                        MessageBox.Show(
                            "タイピングゲーム用のフォルダを選択してください。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                        return null;
                    }
                    trackReader = new StreamReader(dirPath + @"\trackName.txt");
                    // このタイピングゲーム用のフォルダのtrackName.txtには、一行目に"This is for typing-game."の文字列がある。
                    if (trackReader.ReadLine() == "This is for typing-game.") return dirPath;
                    else
                    {
                        MessageBox.Show(
                            "タイピングゲーム用のフォルダを選択してください。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        private void countScriptChar(string playDirName)
        {
            scriptReader = new StreamReader(playDirName + @"\script.txt");
            while (true)
            {
                charSize += scriptReader.ReadLine().Length;
                if (scriptReader.EndOfStream == true) break;
            }

        }

        private void countDown()
        {
            startButton.Hide();
            int count = 3;
            countDownLabel.Text = "3";
            countDownLabel.Show();
            timer1 = new Timer();
            timer1.Tick += new EventHandler(func);
            timer1.Interval = 1000;
            timer1.Start();

            void func(Object myObject, EventArgs myEventArgs)
            {
                count--;
                if (count == 0)
                {
                    countDownLabel.Hide();
                    startGame();
                }
                countDownLabel.Text = count.ToString();
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
            string time = timeReader.ReadLine();
            string[] timeSplitted = time.Split(':');
            int h = Int32.Parse(timeSplitted[0]);
            int m = Int32.Parse(timeSplitted[1]);
            int ms = (int)(1000 * Double.Parse(timeSplitted[2]));// 0.0000000の形式で書かれているため、1000倍して(整数)ミリ秒に変換
            int timeLimit = (h * 3600 + m * 60) * 1000 + ms;
            setTimer(timeLimit - preTimeLimit);
            preTimeLimit = timeLimit;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            mediaPlayer.controls.stop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            countDown();
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

                    // 次のセクションがなければゲームを終了する
                    if (scriptReader.Peek() == -1)
                    {
                        endGame();
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
