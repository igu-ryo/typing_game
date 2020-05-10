namespace typing_game
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.SelectMusicButton = new System.Windows.Forms.Button();
            this.scriptBox = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.endButton = new System.Windows.Forms.Button();
            this.addTimeButton = new System.Windows.Forms.Button();
            this.dirNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(12, 372);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(776, 66);
            this.mediaPlayer.TabIndex = 0;
            // 
            // SelectMusicButton
            // 
            this.SelectMusicButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SelectMusicButton.Location = new System.Drawing.Point(24, 322);
            this.SelectMusicButton.Name = "SelectMusicButton";
            this.SelectMusicButton.Size = new System.Drawing.Size(85, 33);
            this.SelectMusicButton.TabIndex = 1;
            this.SelectMusicButton.Text = "曲を選択";
            this.SelectMusicButton.UseVisualStyleBackColor = true;
            this.SelectMusicButton.Click += new System.EventHandler(this.SelectMusicButton_Click);
            // 
            // scriptBox
            // 
            this.scriptBox.Location = new System.Drawing.Point(299, 12);
            this.scriptBox.Multiline = true;
            this.scriptBox.Name = "scriptBox";
            this.scriptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.scriptBox.Size = new System.Drawing.Size(215, 282);
            this.scriptBox.TabIndex = 2;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(32, 12);
            this.timeBox.Multiline = true;
            this.timeBox.Name = "timeBox";
            this.timeBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.timeBox.Size = new System.Drawing.Size(215, 282);
            this.timeBox.TabIndex = 3;
            // 
            // endButton
            // 
            this.endButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.endButton.Location = new System.Drawing.Point(703, 322);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(85, 33);
            this.endButton.TabIndex = 4;
            this.endButton.Text = "完了";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // addTimeButton
            // 
            this.addTimeButton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addTimeButton.Location = new System.Drawing.Point(129, 322);
            this.addTimeButton.Name = "addTimeButton";
            this.addTimeButton.Size = new System.Drawing.Size(149, 33);
            this.addTimeButton.TabIndex = 5;
            this.addTimeButton.Text = "タイムリミットを追加";
            this.addTimeButton.UseVisualStyleBackColor = true;
            this.addTimeButton.Click += new System.EventHandler(this.addTimeButton_Click);
            // 
            // dirNameBox
            // 
            this.dirNameBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dirNameBox.Location = new System.Drawing.Point(458, 322);
            this.dirNameBox.Multiline = true;
            this.dirNameBox.Name = "dirNameBox";
            this.dirNameBox.Size = new System.Drawing.Size(239, 33);
            this.dirNameBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(340, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 34);
            this.label1.TabIndex = 7;
            this.label1.Text = "スクリプト名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(541, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 307);
            this.label2.TabIndex = 8;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dirNameBox);
            this.Controls.Add(this.addTimeButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.scriptBox);
            this.Controls.Add(this.SelectMusicButton);
            this.Controls.Add(this.mediaPlayer);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.Button SelectMusicButton;
        private System.Windows.Forms.TextBox scriptBox;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button addTimeButton;
        private System.Windows.Forms.TextBox dirNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}