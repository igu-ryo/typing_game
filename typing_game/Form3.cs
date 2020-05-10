using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace typing_game
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void setMusic()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:";
            ofd.Filter = "m4aファイル(*.m4a)|*.m4a";
            ofd.Title = "曲を選択";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mediaPlayer.URL = ofd.FileName;
            }
        }

        private void SelectMusicButton_Click(object sender, EventArgs e)
        {
            setMusic();
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            int cts = countTimeSection();
            if (cts == -1)
            {
                MessageBox.Show(
                    "タイムリミットの形式が違います。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else if (cts == -2)
            {
                MessageBox.Show(
                    "タイムリミットに空行を含まないでください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else if (cts == countScriptSection())
            {
                string dirname = dirNameBox.Text;
                if (
                    dirname.Contains(@"\") ||
                    dirname.Contains("/") ||
                    dirname.Contains(":") ||
                    dirname.Contains("*") ||
                    dirname.Contains("?") ||
                    dirname.Contains("\"") ||
                    dirname.Contains("<") ||
                    dirname.Contains(">") ||
                    dirname.Contains("|")
                    )
                {
                    MessageBox.Show(
                        "\\ / : * ? \" < > | は名前に使えません。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                else if (mediaPlayer.URL == "")
                {
                    MessageBox.Show(
                        "曲が選択されていません。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                else if (dirname == "")
                {
                    MessageBox.Show(
                        "スクリプト名を記入してください。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        "作成を終了しますか？",
                        "終了確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );

                    if (result == DialogResult.Yes)
                    {
                        dirname = @"..\..\..\MUSIC\" + dirname;
                        if (!Directory.Exists(dirname))
                        {
                            Directory.CreateDirectory(dirname);
                        }

                        File.WriteAllText(dirname + @"\script.txt", scriptBox.Text);
                        File.WriteAllText(dirname + @"\timeLimit.txt", timeBox.Text);
                        File.WriteAllText(dirname + @"\trackName.txt", "This is for typing-game.\r\n" + mediaPlayer.URL);
                        this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show(
                    "スクリプトのセクション数と、それに対するタイムリミットの数が一致しません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private int countScriptSection()
        {
            int cnt = 0;
            string s = scriptBox.Text;
            StringReader reader = new StringReader(s);
            while (reader.Peek() != -1)
            {
                if (reader.ReadLine() == "") cnt++;
            }
            return cnt + 1;
        }

        private int countTimeSection()
        {
            int cnt = 0;
            string s = timeBox.Text;
            StringReader reader = new StringReader(s);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                if (Regex.IsMatch(line, "([0-9]{2}:){2}[0-9]{2}.[0-9]{7}") == false)// 00:00:00.0000000 の形式でない場合
                {
                    cnt = -1;
                    break;
                }
                else if (line == "")
                {
                    cnt = -2;
                    break;
                }
                cnt++;
            }
            return cnt;
        }

        private void addTimeButton_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)(mediaPlayer.Ctlcontrols.currentPosition * 1000));
            timeBox.AppendText(timeSpan.ToString() + "\r\n");
        }
    }
}
