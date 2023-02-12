using TwitchLib.Api;
using TwitchLib.Api.Interfaces;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using System.Diagnostics;
using KH2RewardListener.Logger;
using Memory;
using KH2RewardListener.Properties;
using KH2RewardListener.Rewards;

namespace KH2RewardListener
{
    public partial class MainForm : Form
    {
        public static TwitchPubSub PubSub;
        public static Mem mem = new Mem();
        public static TwitchClient client = new TwitchClient();
        public static ITwitchAPI API;
        public static string channel = "";
        private readonly LogService _logger;

        public MainForm()
        {
            InitializeComponent();
            _logger = LogService.Instance;
            _logger.OnLogReceived += new EventHandler<LogEventArgs>(OnLogReceived);
            tb_broadcaster.Text = Settings.Default.channel;
            tb_streameraccesstoken.Text = Settings.Default.access_token;
            tb_streameraccountid.Text = Settings.Default.channel_id;
            tb_streamerrefreshtoken.Text = Settings.Default.refresh_token;
            tb_appclientid.Text = Settings.Default.client_id;
            tb_appclientsecret.Text = Settings.Default.client_secret;
        }

        private async void bt_connect_Click(object sender, EventArgs e)
        {
            if (tb_broadcaster.Text.Length < 1 || tb_streameraccesstoken.Text.Length < 1 || tb_appclientid.Text.Length < 1 || tb_appclientsecret.Text.Length < 1)
            {
                MessageBox.Show("Please head over to Settings and fill everything out first.");
                return;
            }
            var API = new TwitchAPI();
            channel = tb_broadcaster.Text;
            bt_connect.Enabled = false;
            API.Settings.ClientId = tb_appclientid.Text;
            API.Settings.Secret = tb_appclientsecret.Text;

            _logger.Information("Refreshing access token...");
            var refresh = await API.Auth.RefreshAuthTokenAsync(tb_streamerrefreshtoken.Text, tb_appclientsecret.Text, tb_appclientid.Text);
            tb_streameraccesstoken.Text = refresh.AccessToken;
            _logger.Information("Access token has been refreshed!");

            ConnectionCredentials creds = new ConnectionCredentials(tb_broadcaster.Text, tb_streameraccesstoken.Text);

            client.Initialize(creds, tb_broadcaster.Text);
            client.OnConnected += Client_OnConnected;
            client.Connect();

            PubSub = new TwitchPubSub();
            PubSub.OnListenResponse += OnListenResponse;
            PubSub.OnPubSubServiceConnected += OnPubSubServiceConnected;
            PubSub.OnPubSubServiceClosed += OnPubSubServiceClosed;
            PubSub.OnPubSubServiceError += OnPubSubServiceError;

            ListenToRewards(tb_streameraccountid.Text);

            PubSub.Connect();
        }

        #region Client Events
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            _logger.Information("Successfully connected to the Client.");
        }
        #endregion

        #region Reward Events

        private void ListenToRewards(string channelId)
        {
            PubSub.OnRewardRedeemed += PubSub_OnRewardRedeemed;
            PubSub.OnCustomRewardCreated += PubSub_OnCustomRewardCreated;
            PubSub.OnCustomRewardUpdated += PubSub_OnCustomRewardUpdated;
            PubSub.ListenToRewards(channelId);
            PubSub.ListenToChannelPoints(channelId);
        }

        [Obsolete]
        private async void PubSub_OnCustomRewardCreated(object sender, OnCustomRewardCreatedArgs e)
        {
            _logger.Information("A reward has been created: " + e.RewardTitle);
            _logger.Information("Reward ID: " + e.RewardId);
        }

        [Obsolete]
        private async void PubSub_OnCustomRewardUpdated(object sender, OnCustomRewardUpdatedArgs e)
        {
            _logger.Information("A reward has been updated: " + e.RewardTitle);
            _logger.Information("Reward ID: " + e.RewardId);
        }

        [Obsolete]
        private async void PubSub_OnRewardRedeemed(object sender, OnRewardRedeemedArgs e)
        {
            GetPID();
            RewardManager.GetRewardNames();
            if (e.Status != "ACTION_TAKEN")
            {
                switch (e.RewardId.ToString())
                {
                    case var value when value == RewardManager.AutoAttack:
                        AutoAttack.DoAction();
                        break;
                    case var value when value == RewardManager.AutoJump:
                        AutoJump.DoAction();
                        break;
                    case var value when value == RewardManager.BlindSight:
                        BlindSight.DoAction();
                        break;
                    case var value when value == RewardManager.BlockPause:
                        BlockPause.DoAction();
                        break;
                    case var value when value == RewardManager.DriveAnti:
                        DriveAnti.DoAction();
                        break;
                    case var value when value == RewardManager.DriveFinal:
                        DriveFinal.DoAction();
                        break;
                    case var value when value == RewardManager.DriveLimit:
                        DriveLimit.DoAction();
                        break;
                    case var value when value == RewardManager.DriveMaster:
                        DriveMaster.DoAction();
                        break;
                    case var value when value == RewardManager.DriveValor:
                        DriveValor.DoAction();
                        break;
                    case var value when value == RewardManager.DriveWisdom:
                        DriveWisdom.DoAction();
                        break;
                    case var value when value == RewardManager.EmptyDrive:
                        EmptyDrive.DoAction();
                        break;
                    case var value when value == RewardManager.EmptyMagic:
                        EmptyMagic.DoAction();
                        break;
                    case var value when value == RewardManager.FieldOfView:
                        FieldOfView.DoAction();
                        break;
                    case var value when value == RewardManager.Flashbang:
                        Flashbang.DoAction();
                        break;
                    case var value when value == RewardManager.GameSpeed:
                        GameSpeed.DoAction();
                        break;
                    case var value when value == RewardManager.InvisibleModels:
                        InvisibleModels.DoAction();
                        break;
                    case var value when value == RewardManager.MovementSpeed:
                        MovementSpeed.DoAction();
                        break;
                    case var value when value == RewardManager.NoAttack:
                        NoAttack.DoAction();
                        break;
                    case var value when value == RewardManager.NoDrive:
                        NoDrive.DoAction();
                        break;
                    case var value when value == RewardManager.NoItems:
                        NoItems.DoAction();
                        break;
                    case var value when value == RewardManager.NoMagic:
                        NoMagic.DoAction();
                        break;
                    case var value when value == RewardManager.OneHP:
                        OneHP.DoAction();
                        break;
                    case var value when value == RewardManager.PhoneMode:
                        PhoneMode.DoAction();
                        break;
                    case var value when value == RewardManager.RandomCamera:
                        RandomCamera.DoAction();
                        break;
                    case var value when value == RewardManager.RandomConsumable:
                        RandomConsumable.DoAction();
                        break;
                    case var value when value == RewardManager.RandomDefense:
                        RandomDefense.DoAction();
                        break;
                    case var value when value == RewardManager.RandomMagic:
                        RandomMagic.DoAction();
                        break;
                    case var value when value == RewardManager.RandomStrength:
                        RandomStrength.DoAction();
                        break;
                    case var value when value == RewardManager.RefillDrive:
                        RefillDrive.DoAction();
                        break;
                    case var value when value == RewardManager.RefillFormDuration:
                        RefillFormDuration.DoAction();
                        break;
                    case var value when value == RewardManager.RefillHP:
                        RefillHP.DoAction();
                        break;
                    case var value when value == RewardManager.RefillMP:
                        RefillMP.DoAction();
                        break;
                    case var value when value == RewardManager.SoftReset:
                        SoftReset.DoAction();
                        break;
                }
                _logger.Information($"User {e.DisplayName} redeemed '{e.RewardTitle}' for {e.RewardCost} Channel Points.");
            }
        }

        #endregion

        #region Pubsub events

        private void OnPubSubServiceError(object sender, OnPubSubServiceErrorArgs e)
        {

            _logger.Error($"{e.Exception.Message}");
        }

        private void OnPubSubServiceClosed(object sender, EventArgs e)
        {
            _logger.Information("Connection has been closed to PubSub Server.");
        }

        private void OnPubSubServiceConnected(object sender, EventArgs e)
        {
            PubSub.SendTopics(tb_streameraccesstoken.Text);
            _logger.Information("Successfully connected to PubSub Server.");
        }

        private void OnListenResponse(object sender, OnListenResponseArgs e)
        {
            if (!e.Successful)
            {
                _logger.Error($"Failed to listen to Rewards\n{e.Response.Error}");
            }
        }

        #endregion

        private void OnLogReceived(object sender, LogEventArgs e)
        {
            base.Invoke(new Action(delegate ()
            {
                RichTextBox richTextBox = rtb_Log;
                richTextBox.Text = richTextBox.Text + e.Text + "\n";
                richTextBox.Focus();
                richTextBox.Select(richTextBox.TextLength, 0);
                richTextBox.ScrollToCaret();
            }));
        }

        private void GetPID()
        {
            int pid = mem.GetProcIdFromName("KINGDOM HEARTS II FINAL MIX");
            bool openProc = false;

            if (pid > 0) openProc = mem.OpenProcess(pid);
        }
        private async void ll_accesstoken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var api = new TwitchAPI();
            var server = new WebServer("http://localhost:8080/redirect/");

            Process.Start(new ProcessStartInfo
            {
                FileName = $"{getAuthorizationCodeUrl(tb_appclientid.Text, "http://localhost:8080/redirect/")}",
                UseShellExecute = true
            });

            _logger.Information("Starting authorization...");
            var auth = await server.Listen();
            var resp = await api.Auth.GetAccessTokenFromCodeAsync(auth.Code, tb_appclientsecret.Text, "http://localhost:8080/redirect/", tb_appclientid.Text);

            api.Settings.AccessToken = resp.AccessToken;
            api.Settings.ClientId = tb_appclientid.Text;
            var user = (await api.Helix.Users.GetUsersAsync()).Users[0];
            _logger.Information("Authorization success! You can listen to rewards now.");
            _logger.Information($"Username: {user.DisplayName} (ID: {user.Id})");
            tb_broadcaster.Text = user.DisplayName;
            tb_streameraccesstoken.Text = resp.AccessToken;
            tb_streamerrefreshtoken.Text = resp.RefreshToken;
            tb_streameraccountid.Text = user.Id;
            Settings.Default.Save();
            _logger.Information($"User information has been stored to the settings.");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.channel = tb_broadcaster.Text;
            Settings.Default.access_token = tb_streameraccesstoken.Text;
            Settings.Default.refresh_token = tb_streamerrefreshtoken.Text;
            Settings.Default.channel_id = tb_streameraccountid.Text;
            Settings.Default.client_id = tb_appclientid.Text;
            Settings.Default.client_secret = tb_appclientsecret.Text;
            Settings.Default.Save();
        }

        private void ll_devconsole_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://dev.twitch.tv/console",
                UseShellExecute = true
            });
        }

        private static string getAuthorizationCodeUrl(string clientId, string redirectUri)
        {
            return "https://id.twitch.tv/oauth2/authorize?" +
                   $"client_id={clientId}&" +
                   $"redirect_uri={System.Web.HttpUtility.UrlEncode(redirectUri)}&" +
                   "response_type=code&" +
                   $"scope=chat:edit+chat:read+channel:manage:redemptions";
        }
    }
}