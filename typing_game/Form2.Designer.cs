﻿namespace typing_game
{
    partial class Form2
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
            this.jaTxtLabel = new System.Windows.Forms.Label();
            this.typingBox = new System.Windows.Forms.TextBox();
            this.gameClearLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.countDownLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // jaTxtLabel
            // 
            this.jaTxtLabel.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.jaTxtLabel.Location = new System.Drawing.Point(54, 88);
            this.jaTxtLabel.Name = "jaTxtLabel";
            this.jaTxtLabel.Size = new System.Drawing.Size(690, 50);
            this.jaTxtLabel.TabIndex = 0;
            this.jaTxtLabel.Text = "サンプル";
            // 
            // typingBox
            // 
            this.typingBox.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.typingBox.Location = new System.Drawing.Point(60, 268);
            this.typingBox.Name = "typingBox";
            this.typingBox.Size = new System.Drawing.Size(683, 41);
            this.typingBox.TabIndex = 1;
            this.typingBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.typingBox_KeyPress);
            // 
            // gameClearLabel
            // 
            this.gameClearLabel.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gameClearLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.gameClearLabel.Location = new System.Drawing.Point(46, 137);
            this.gameClearLabel.Name = "gameClearLabel";
            this.gameClearLabel.Size = new System.Drawing.Size(711, 128);
            this.gameClearLabel.TabIndex = 2;
            this.gameClearLabel.Text = "GAME OVER!!";
            this.gameClearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.scoreLabel.ForeColor = System.Drawing.Color.Crimson;
            this.scoreLabel.Location = new System.Drawing.Point(151, 268);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(486, 73);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "label1";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Aquamarine;
            this.startButton.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.startButton.Location = new System.Drawing.Point(285, 196);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(216, 69);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // countDownLabel
            // 
            this.countDownLabel.BackColor = System.Drawing.SystemColors.Control;
            this.countDownLabel.Font = new System.Drawing.Font("MS UI Gothic", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.countDownLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.countDownLabel.Location = new System.Drawing.Point(315, 142);
            this.countDownLabel.Name = "countDownLabel";
            this.countDownLabel.Size = new System.Drawing.Size(166, 159);
            this.countDownLabel.TabIndex = 5;
            this.countDownLabel.Text = "1";
            this.countDownLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.countDownLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.gameClearLabel);
            this.Controls.Add(this.typingBox);
            this.Controls.Add(this.jaTxtLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label jaTxtLabel;
        private System.Windows.Forms.TextBox typingBox;
        private System.Windows.Forms.Label gameClearLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label countDownLabel;
    }
}