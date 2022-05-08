namespace KH2RewardListener
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ll_devconsole = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.ll_accesstoken = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Authenticate = new System.Windows.Forms.GroupBox();
            this.tb_broadcaster = new System.Windows.Forms.TextBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tp_modules = new System.Windows.Forms.TabPage();
            this.lb_modules = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gb_Authenticate.SuspendLayout();
            this.tp_modules.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tp_modules);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 337);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.ll_devconsole);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ll_accesstoken);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.gb_Authenticate);
            this.tabPage1.Controls.Add(this.rtb_Log);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Authentication";
            // 
            // ll_devconsole
            // 
            this.ll_devconsole.AutoSize = true;
            this.ll_devconsole.Location = new System.Drawing.Point(537, 28);
            this.ll_devconsole.Name = "ll_devconsole";
            this.ll_devconsole.Size = new System.Drawing.Size(73, 13);
            this.ll_devconsole.TabIndex = 7;
            this.ll_devconsole.TabStop = true;
            this.ll_devconsole.Text = "Dev Console";
            this.ll_devconsole.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_devconsole_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Create your Client App here:";
            // 
            // ll_accesstoken
            // 
            this.ll_accesstoken.AutoSize = true;
            this.ll_accesstoken.Location = new System.Drawing.Point(537, 44);
            this.ll_accesstoken.Name = "ll_accesstoken";
            this.ll_accesstoken.Size = new System.Drawing.Size(127, 13);
            this.ll_accesstoken.TabIndex = 5;
            this.ll_accesstoken.TabStop = true;
            this.ll_accesstoken.Text = "TwitchTokenGenerator";
            this.ll_accesstoken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_accesstoken_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Get your access token here:";
            // 
            // gb_Authenticate
            // 
            this.gb_Authenticate.Controls.Add(this.tb_broadcaster);
            this.gb_Authenticate.Controls.Add(this.bt_connect);
            this.gb_Authenticate.Location = new System.Drawing.Point(6, 6);
            this.gb_Authenticate.Name = "gb_Authenticate";
            this.gb_Authenticate.Size = new System.Drawing.Size(246, 51);
            this.gb_Authenticate.TabIndex = 3;
            this.gb_Authenticate.TabStop = false;
            this.gb_Authenticate.Text = "Broadcaster Name";
            // 
            // tb_broadcaster
            // 
            this.tb_broadcaster.Location = new System.Drawing.Point(6, 19);
            this.tb_broadcaster.Name = "tb_broadcaster";
            this.tb_broadcaster.Size = new System.Drawing.Size(146, 20);
            this.tb_broadcaster.TabIndex = 2;
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(165, 17);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(75, 23);
            this.bt_connect.TabIndex = 0;
            this.bt_connect.Text = "Start Bot";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rtb_Log.ForeColor = System.Drawing.SystemColors.Info;
            this.rtb_Log.Location = new System.Drawing.Point(6, 63);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(680, 242);
            this.rtb_Log.TabIndex = 1;
            this.rtb_Log.Text = "";
            // 
            // tp_modules
            // 
            this.tp_modules.BackColor = System.Drawing.SystemColors.Control;
            this.tp_modules.Controls.Add(this.lb_modules);
            this.tp_modules.Location = new System.Drawing.Point(4, 22);
            this.tp_modules.Name = "tp_modules";
            this.tp_modules.Padding = new System.Windows.Forms.Padding(3);
            this.tp_modules.Size = new System.Drawing.Size(692, 311);
            this.tp_modules.TabIndex = 1;
            this.tp_modules.Text = "Rewards";
            // 
            // lb_modules
            // 
            this.lb_modules.FormattingEnabled = true;
            this.lb_modules.Items.AddRange(new object[] {
            "1 HP",
            "30 FPS",
            "Attack 0",
            "Attack 255",
            "Auto-Attack",
            "Auto-Jump",
            "Blind Sight",
            "Block Input",
            "Block Pause",
            "Defense 0",
            "Defense 255",
            "Drive Anywhere",
            "Empty Drive",
            "Empty Magic",
            "End Drive",
            "Flashbang",
            "FoV",
            "Force Anti",
            "Force Final",
            "Force Limit",
            "Force Master",
            "Force Wisdom",
            "Force Valor",
            "Game Speed",
            "Invisible Models",
            "Magic 0",
            "Magic 255",
            "Movement Speed",
            "No Attack",
            "No Drive",
            "No Items",
            "No Magic",
            "Phone Mode",
            "Random Camera",
            "Random Consumable",
            "Random Keyblade",
            "Refill Drive",
            "Refill Form Duration",
            "Refill HP",
            "Refill MP",
            "Soft Reset"});
            this.lb_modules.Location = new System.Drawing.Point(6, 6);
            this.lb_modules.Name = "lb_modules";
            this.lb_modules.Size = new System.Drawing.Size(146, 303);
            this.lb_modules.TabIndex = 2;
            this.lb_modules.SelectedIndexChanged += new System.EventHandler(this.lb_modules_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 356);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "KHII - Reward Listener";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gb_Authenticate.ResumeLayout(false);
            this.gb_Authenticate.PerformLayout();
            this.tp_modules.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tp_modules;
        private ListBox lb_modules;
        private Button bt_connect;
        private RichTextBox rtb_Log;
        private GroupBox gb_Authenticate;
        private TextBox tb_broadcaster;
        private LinkLabel ll_accesstoken;
        private Label label2;
        private LinkLabel ll_devconsole;
        private Label label1;
    }
}