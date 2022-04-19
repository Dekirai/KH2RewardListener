namespace KH2RewardListener.UserControls
{
    partial class RefillDriveReward
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_RewardName = new System.Windows.Forms.GroupBox();
            this.bt_Save = new System.Windows.Forms.Button();
            this.label80 = new System.Windows.Forms.Label();
            this.tb_chatmessage = new System.Windows.Forms.TextBox();
            this.tb_rewardname = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.gb_RewardName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_RewardName
            // 
            this.gb_RewardName.Controls.Add(this.bt_Save);
            this.gb_RewardName.Controls.Add(this.label80);
            this.gb_RewardName.Controls.Add(this.tb_chatmessage);
            this.gb_RewardName.Controls.Add(this.tb_rewardname);
            this.gb_RewardName.Controls.Add(this.label79);
            this.gb_RewardName.Location = new System.Drawing.Point(3, 3);
            this.gb_RewardName.Name = "gb_RewardName";
            this.gb_RewardName.Size = new System.Drawing.Size(321, 115);
            this.gb_RewardName.TabIndex = 14;
            this.gb_RewardName.TabStop = false;
            this.gb_RewardName.Text = "Refill Drive Reward";
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(186, 86);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(123, 23);
            this.bt_Save.TabIndex = 12;
            this.bt_Save.Text = "Save settings";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(15, 18);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(91, 14);
            this.label80.TabIndex = 8;
            this.label80.Text = "Reward Name:";
            // 
            // tb_chatmessage
            // 
            this.tb_chatmessage.Location = new System.Drawing.Point(109, 41);
            this.tb_chatmessage.Name = "tb_chatmessage";
            this.tb_chatmessage.Size = new System.Drawing.Size(200, 22);
            this.tb_chatmessage.TabIndex = 11;
            // 
            // tb_rewardname
            // 
            this.tb_rewardname.Location = new System.Drawing.Point(109, 15);
            this.tb_rewardname.Name = "tb_rewardname";
            this.tb_rewardname.Size = new System.Drawing.Size(200, 22);
            this.tb_rewardname.TabIndex = 9;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(8, 44);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(98, 14);
            this.label79.TabIndex = 10;
            this.label79.Text = "Chat message:";
            // 
            // RefillDriveReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_RewardName);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RefillDriveReward";
            this.Size = new System.Drawing.Size(528, 300);
            this.gb_RewardName.ResumeLayout(false);
            this.gb_RewardName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gb_RewardName;
        private Button bt_Save;
        private Label label80;
        private TextBox tb_chatmessage;
        private TextBox tb_rewardname;
        private Label label79;
    }
}
