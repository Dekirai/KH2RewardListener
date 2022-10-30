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
            this.tp_authentication = new System.Windows.Forms.TabPage();
            this.gb_Authenticate = new System.Windows.Forms.GroupBox();
            this.tb_broadcaster = new System.Windows.Forms.TextBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tp_modules = new System.Windows.Forms.TabPage();
            this.lb_modules = new System.Windows.Forms.ListBox();
            this.tp_settings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_streameraccountid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_streamerrefreshtoken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ll_accesstoken = new System.Windows.Forms.LinkLabel();
            this.tb_streameraccesstoken = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_appclientsecret = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ll_devconsole = new System.Windows.Forms.LinkLabel();
            this.tb_appclientid = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tp_authentication.SuspendLayout();
            this.gb_Authenticate.SuspendLayout();
            this.tp_modules.SuspendLayout();
            this.tp_settings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_authentication);
            this.tabControl1.Controls.Add(this.tp_modules);
            this.tabControl1.Controls.Add(this.tp_settings);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 337);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_authentication
            // 
            this.tp_authentication.BackColor = System.Drawing.SystemColors.Control;
            this.tp_authentication.Controls.Add(this.gb_Authenticate);
            this.tp_authentication.Controls.Add(this.rtb_Log);
            this.tp_authentication.Location = new System.Drawing.Point(4, 22);
            this.tp_authentication.Name = "tp_authentication";
            this.tp_authentication.Padding = new System.Windows.Forms.Padding(3);
            this.tp_authentication.Size = new System.Drawing.Size(692, 311);
            this.tp_authentication.TabIndex = 0;
            this.tp_authentication.Text = "Authentication";
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
            this.tp_modules.Location = new System.Drawing.Point(4, 24);
            this.tp_modules.Name = "tp_modules";
            this.tp_modules.Padding = new System.Windows.Forms.Padding(3);
            this.tp_modules.Size = new System.Drawing.Size(692, 309);
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
            // tp_settings
            // 
            this.tp_settings.BackColor = System.Drawing.SystemColors.Control;
            this.tp_settings.Controls.Add(this.groupBox2);
            this.tp_settings.Controls.Add(this.groupBox1);
            this.tp_settings.Location = new System.Drawing.Point(4, 22);
            this.tp_settings.Name = "tp_settings";
            this.tp_settings.Size = new System.Drawing.Size(692, 311);
            this.tp_settings.TabIndex = 2;
            this.tp_settings.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_streameraccountid);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_streamerrefreshtoken);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ll_accesstoken);
            this.groupBox2.Controls.Add(this.tb_streameraccesstoken);
            this.groupBox2.Location = new System.Drawing.Point(7, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 145);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Streamer Account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Account ID";
            // 
            // tb_streameraccountid
            // 
            this.tb_streameraccountid.Location = new System.Drawing.Point(6, 116);
            this.tb_streameraccountid.Name = "tb_streameraccountid";
            this.tb_streameraccountid.ReadOnly = true;
            this.tb_streameraccountid.Size = new System.Drawing.Size(173, 20);
            this.tb_streameraccountid.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Refresh Token";
            // 
            // tb_streamerrefreshtoken
            // 
            this.tb_streamerrefreshtoken.Location = new System.Drawing.Point(6, 74);
            this.tb_streamerrefreshtoken.Name = "tb_streamerrefreshtoken";
            this.tb_streamerrefreshtoken.ReadOnly = true;
            this.tb_streamerrefreshtoken.Size = new System.Drawing.Size(173, 20);
            this.tb_streamerrefreshtoken.TabIndex = 10;
            this.tb_streamerrefreshtoken.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Access Token";
            // 
            // ll_accesstoken
            // 
            this.ll_accesstoken.AutoSize = true;
            this.ll_accesstoken.Location = new System.Drawing.Point(199, 16);
            this.ll_accesstoken.Name = "ll_accesstoken";
            this.ll_accesstoken.Size = new System.Drawing.Size(55, 13);
            this.ll_accesstoken.TabIndex = 5;
            this.ll_accesstoken.TabStop = true;
            this.ll_accesstoken.Text = "Generate";
            this.ll_accesstoken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_accesstoken_LinkClicked);
            // 
            // tb_streameraccesstoken
            // 
            this.tb_streameraccesstoken.Location = new System.Drawing.Point(6, 32);
            this.tb_streameraccesstoken.Name = "tb_streameraccesstoken";
            this.tb_streameraccesstoken.ReadOnly = true;
            this.tb_streameraccesstoken.Size = new System.Drawing.Size(173, 20);
            this.tb_streameraccesstoken.TabIndex = 8;
            this.tb_streameraccesstoken.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_appclientsecret);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ll_devconsole);
            this.groupBox1.Controls.Add(this.tb_appclientid);
            this.groupBox1.Location = new System.Drawing.Point(273, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 145);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twitch Application";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 30);
            this.label6.TabIndex = 15;
            this.label6.Text = "As \"OAuth Redirect URL\" use http://localhost:8080/redirect/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Client Secret";
            // 
            // tb_appclientsecret
            // 
            this.tb_appclientsecret.Location = new System.Drawing.Point(6, 74);
            this.tb_appclientsecret.Name = "tb_appclientsecret";
            this.tb_appclientsecret.Size = new System.Drawing.Size(173, 20);
            this.tb_appclientsecret.TabIndex = 13;
            this.tb_appclientsecret.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Client ID";
            // 
            // ll_devconsole
            // 
            this.ll_devconsole.AutoSize = true;
            this.ll_devconsole.Location = new System.Drawing.Point(187, 16);
            this.ll_devconsole.Name = "ll_devconsole";
            this.ll_devconsole.Size = new System.Drawing.Size(67, 13);
            this.ll_devconsole.TabIndex = 7;
            this.ll_devconsole.TabStop = true;
            this.ll_devconsole.Text = "Create App";
            this.ll_devconsole.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_devconsole_LinkClicked);
            // 
            // tb_appclientid
            // 
            this.tb_appclientid.Location = new System.Drawing.Point(6, 33);
            this.tb_appclientid.Name = "tb_appclientid";
            this.tb_appclientid.Size = new System.Drawing.Size(173, 20);
            this.tb_appclientid.TabIndex = 11;
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
            this.tp_authentication.ResumeLayout(false);
            this.gb_Authenticate.ResumeLayout(false);
            this.gb_Authenticate.PerformLayout();
            this.tp_modules.ResumeLayout(false);
            this.tp_settings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tp_authentication;
        private TabPage tp_modules;
        private ListBox lb_modules;
        private Button bt_connect;
        private RichTextBox rtb_Log;
        private GroupBox gb_Authenticate;
        private TextBox tb_broadcaster;
        private LinkLabel ll_accesstoken;
        private LinkLabel ll_devconsole;
        private TabPage tp_settings;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox tb_appclientsecret;
        private Label label1;
        private TextBox tb_appclientid;
        private Label label2;
        private TextBox tb_streameraccesstoken;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox tb_streamerrefreshtoken;
        private Label label5;
        private TextBox tb_streameraccountid;
        private Label label6;
    }
}