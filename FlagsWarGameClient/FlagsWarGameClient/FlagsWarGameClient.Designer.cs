namespace FlagsWarGameClient
{
    partial class FlagsWarGameClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlagsWarGameClient));
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.myFlagCountTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.oppFlagCountTB = new System.Windows.Forms.TextBox();
            this.ipLbl = new System.Windows.Forms.Label();
            this.ipTb = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.coorLb = new System.Windows.Forms.Label();
            this.xTb = new System.Windows.Forms.TextBox();
            this.yTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.ErrorImage = null;
            this.mapPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mapPictureBox.Image")));
            this.mapPictureBox.Location = new System.Drawing.Point(11, 132);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(869, 426);
            this.mapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.Click += new System.EventHandler(this.mapPictureBox_Click);
            this.mapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseMove);
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.SystemColors.Menu;
            this.status.Enabled = false;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.status.HideSelection = false;
            this.status.Location = new System.Drawing.Point(248, 12);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(393, 26);
            this.status.TabIndex = 1;
            this.status.Text = "Flags War Game";
            this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your Planted Flags";
            // 
            // myFlagCountTB
            // 
            this.myFlagCountTB.BackColor = System.Drawing.SystemColors.Menu;
            this.myFlagCountTB.Enabled = false;
            this.myFlagCountTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.myFlagCountTB.HideSelection = false;
            this.myFlagCountTB.Location = new System.Drawing.Point(128, 70);
            this.myFlagCountTB.Name = "myFlagCountTB";
            this.myFlagCountTB.Size = new System.Drawing.Size(55, 26);
            this.myFlagCountTB.TabIndex = 3;
            this.myFlagCountTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(664, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Opponent\'s Planted Flags";
            // 
            // oppFlagCountTB
            // 
            this.oppFlagCountTB.BackColor = System.Drawing.SystemColors.Menu;
            this.oppFlagCountTB.Enabled = false;
            this.oppFlagCountTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.oppFlagCountTB.HideSelection = false;
            this.oppFlagCountTB.Location = new System.Drawing.Point(825, 76);
            this.oppFlagCountTB.Name = "oppFlagCountTB";
            this.oppFlagCountTB.Size = new System.Drawing.Size(55, 26);
            this.oppFlagCountTB.TabIndex = 6;
            this.oppFlagCountTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ipLbl.Location = new System.Drawing.Point(245, 76);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(108, 32);
            this.ipLbl.TabIndex = 7;
            this.ipLbl.Text = "Server Computer\r\nIP Address";
            // 
            // ipTb
            // 
            this.ipTb.BackColor = System.Drawing.SystemColors.Window;
            this.ipTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ipTb.HideSelection = false;
            this.ipTb.Location = new System.Drawing.Point(359, 76);
            this.ipTb.Name = "ipTb";
            this.ipTb.Size = new System.Drawing.Size(201, 26);
            this.ipTb.TabIndex = 8;
            this.ipTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(566, 79);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 9;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // coorLb
            // 
            this.coorLb.AutoSize = true;
            this.coorLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.coorLb.Location = new System.Drawing.Point(718, 28);
            this.coorLb.Name = "coorLb";
            this.coorLb.Size = new System.Drawing.Size(80, 16);
            this.coorLb.TabIndex = 10;
            this.coorLb.Text = "Coordinates";
            // 
            // xTb
            // 
            this.xTb.BackColor = System.Drawing.SystemColors.Menu;
            this.xTb.Enabled = false;
            this.xTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xTb.HideSelection = false;
            this.xTb.Location = new System.Drawing.Point(802, 22);
            this.xTb.Name = "xTb";
            this.xTb.Size = new System.Drawing.Size(36, 26);
            this.xTb.TabIndex = 11;
            this.xTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yTb
            // 
            this.yTb.BackColor = System.Drawing.SystemColors.Menu;
            this.yTb.Enabled = false;
            this.yTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yTb.HideSelection = false;
            this.yTb.Location = new System.Drawing.Point(844, 22);
            this.yTb.Name = "yTb";
            this.yTb.Size = new System.Drawing.Size(36, 26);
            this.yTb.TabIndex = 12;
            this.yTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(812, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(857, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Y";
            // 
            // FlagsWarGameClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 570);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yTb);
            this.Controls.Add(this.xTb);
            this.Controls.Add(this.coorLb);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.ipTb);
            this.Controls.Add(this.ipLbl);
            this.Controls.Add(this.oppFlagCountTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.myFlagCountTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.mapPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FlagsWarGameClient";
            this.Text = "Flags War Game";
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox myFlagCountTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oppFlagCountTB;
        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.TextBox ipTb;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label coorLb;
        private System.Windows.Forms.TextBox xTb;
        private System.Windows.Forms.TextBox yTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

