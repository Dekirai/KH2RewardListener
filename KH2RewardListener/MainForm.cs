using TwitchLib.Api;
using TwitchLib.Api.Interfaces;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Events;
using System.Diagnostics;
using KH2RewardListener.Logger;
using KHMemLibrary;
using Memory;
using KH2RewardListener.UserControls;
using KH2RewardListener.Properties;

namespace KH2RewardListener
{
    public partial class MainForm : Form
    {
        public static TwitchPubSub PubSub;
        public static KH2FM kh2 = new KH2FM();
        public static Mem mem = new Mem();
        public static TwitchClient client = new TwitchClient();
        public static ITwitchAPI API;
        public static string channel = "";
        private readonly LogService _logger;

        #region UserControls
        Attack0Reward attack0 = new Attack0Reward();
        Attack255Reward attack255 = new Attack255Reward();
        AutoAttackReward autoattack = new AutoAttackReward();
        AutoJumpReward autojump = new AutoJumpReward();
        BlindSightReward blindsight = new BlindSightReward();
        BlockInputReward blockinput = new BlockInputReward();
        BlockPauseReward blockpause = new BlockPauseReward();
        Defense0Reward defense0 = new Defense0Reward();
        Defense255Reward defense255 = new Defense255Reward();
        DriveAntiReward driveanti = new DriveAntiReward();
        DriveAnywhereReward driveanywhere = new DriveAnywhereReward();
        DriveFinalReward drivefinal = new DriveFinalReward();
        DriveLimitReward drivelimit = new DriveLimitReward();
        DriveMasterReward drivemaster = new DriveMasterReward();
        DriveValorReward drivevalor = new DriveValorReward();
        DriveWisdomReward drivewisdom = new DriveWisdomReward();
        EmptyDriveReward emptydrive = new EmptyDriveReward();
        EmptyMagicReward emptymagic = new EmptyMagicReward();
        EndDriveReward enddrive = new EndDriveReward();
        FlashbangReward flashbang = new FlashbangReward();
        FOVReward fov = new FOVReward();
        FPS30Reward fps30 = new FPS30Reward();
        GameSpeedReward gamespeed = new GameSpeedReward();
        InvisibleModelsReward invisiblemodels = new InvisibleModelsReward();
        Magic0Reward magic0 = new Magic0Reward();
        Magic255Reward magic255 = new Magic255Reward();
        MovementSpeedReward movementspeed = new MovementSpeedReward();
        NoAttackReward noattack = new NoAttackReward();
        NoDriveReward nodrive = new NoDriveReward();
        NoItemsReward noitems = new NoItemsReward();
        NoMagicReward nomagic = new NoMagicReward();
        OneHPReward onehp = new OneHPReward();
        PhoneModeReward phonemode = new PhoneModeReward();
        RandomCameraReward randomcamera = new RandomCameraReward();
        RandomConsumableReward randomconsumable = new RandomConsumableReward();
        RandomKeybladeReward randomkeyblade = new RandomKeybladeReward();
        RefillDriveReward refilldrive = new RefillDriveReward();
        RefillFormDurationReward refillformduration = new RefillFormDurationReward();
        RefillHPReward refillhp = new RefillHPReward();
        RefillMPReward refillmp = new RefillMPReward();
        SoftResetReward softreset = new SoftResetReward();
        #endregion

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
            if (tb_streameraccesstoken.Text.Length < 1 || tb_appclientid.Text.Length < 1 || tb_appclientsecret.Text.Length < 1)
            {
                MessageBox.Show("Please head over to Settings and fill everything out first.");
                return;
            }
            var API = new TwitchAPI();
            channel = tb_broadcaster.Text;
            bt_connect.Enabled = false;
            ConnectionCredentials creds = new ConnectionCredentials(tb_broadcaster.Text, tb_streameraccesstoken.Text);
            API.Settings.ClientId = tb_appclientid.Text;
            API.Settings.Secret = tb_appclientsecret.Text;

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
            PubSub.ListenToRewards(channelId);
            PubSub.ListenToChannelPoints(channelId);
        }

        [Obsolete]
        private async void PubSub_OnRewardRedeemed(object sender, OnRewardRedeemedArgs e)
        {
            GetPID();
            if (e.Status != "ACTION_TAKEN")
            {
                if (e.RewardTitle == onehp.RewardName)
                    onehp.DoAction();
                else if (e.RewardTitle == autoattack.RewardName)
                    autoattack.DoAction();
                else if (e.RewardTitle == blindsight.RewardName)
                    blindsight.DoAction();
                else if (e.RewardTitle == blockinput.RewardName)
                    blockinput.DoAction();
                else if (e.RewardTitle == blockpause.RewardName)
                    blockpause.DoAction();
                else if (e.RewardTitle == flashbang.RewardName)
                    flashbang.DoAction();
                else if (e.RewardTitle == invisiblemodels.RewardName)
                    invisiblemodels.DoAction();
                else if (e.RewardTitle == phonemode.RewardName)
                    phonemode.DoAction();
                else if (e.RewardTitle == randomcamera.RewardName)
                    randomcamera.DoAction();
                else if (e.RewardTitle == softreset.RewardName)
                    softreset.DoAction();
                else if (e.RewardTitle == refillhp.RewardName)
                    refillhp.DoAction();
                else if (e.RewardTitle == refillmp.RewardName)
                    refillmp.DoAction();
                else if (e.RewardTitle == refilldrive.RewardName)
                    refilldrive.DoAction();
                else if (e.RewardTitle == autojump.RewardName)
                    autojump.DoAction();
                else if (e.RewardTitle == gamespeed.RewardName)
                    gamespeed.DoAction();
                else if (e.RewardTitle == movementspeed.RewardName)
                    movementspeed.DoAction();
                else if (e.RewardTitle == fps30.RewardName)
                    fps30.DoAction();
                else if (e.RewardTitle == fov.RewardName)
                    fov.DoAction();
                else if (e.RewardTitle == nomagic.RewardName)
                    nomagic.DoAction();
                else if (e.RewardTitle == noattack.RewardName)
                    noattack.DoAction();
                else if (e.RewardTitle == noitems.RewardName)
                    noitems.DoAction();
                else if (e.RewardTitle == nodrive.RewardName)
                    nodrive.DoAction();
                else if (e.RewardTitle == attack0.RewardName)
                    attack0.DoAction();
                else if (e.RewardTitle == attack255.RewardName)
                    attack255.DoAction();
                else if (e.RewardTitle == magic0.RewardName)
                    magic0.DoAction();
                else if (e.RewardTitle == magic255.RewardName)
                    magic255.DoAction();
                else if (e.RewardTitle == defense0.RewardName)
                    defense0.DoAction();
                else if (e.RewardTitle == defense255.RewardName)
                    defense255.DoAction();
                else if (e.RewardTitle == emptymagic.RewardName)
                    emptymagic.DoAction();
                else if (e.RewardTitle == emptydrive.RewardName)
                    emptydrive.DoAction();
                else if (e.RewardTitle == randomconsumable.RewardName)
                    randomconsumable.DoAction();
                else if (e.RewardTitle == randomkeyblade.RewardName)
                    randomkeyblade.DoAction();
                else if (e.RewardTitle == enddrive.RewardName)
                    enddrive.DoAction();
                else if (e.RewardTitle == driveanywhere.RewardName)
                    driveanywhere.DoAction();
                else if (e.RewardTitle == refillformduration.RewardName)
                    refillformduration.DoAction();
                else if (e.RewardTitle == drivefinal.RewardName)
                    drivefinal.DoAction();
                else if (e.RewardTitle == drivelimit.RewardName)
                    drivelimit.DoAction();
                else if (e.RewardTitle == drivemaster.RewardName)
                    drivemaster.DoAction();
                else if (e.RewardTitle == drivewisdom.RewardName)
                    drivewisdom.DoAction();
                else if (e.RewardTitle == drivevalor.RewardName)
                    drivevalor.DoAction();
                else if (e.RewardTitle == driveanti.RewardName)
                    driveanti.DoAction();
                else
                {
                    //Do nothing
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
                rtb_Log.ScrollToCaret();
            }));
        }

        private void lb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {

            var module = lb_modules.GetItemText(lb_modules.SelectedItem);

            #region Modules
            if (module == "1 HP")
            {
                DisposeAllUserControls();
                SetUserControlPosition(onehp);
            }
            else if (module == "Block Input")
            {
                DisposeAllUserControls();
                SetUserControlPosition(blockinput);
            }
            else if (module == "Block Pause")
            {
                DisposeAllUserControls();
                SetUserControlPosition(blockpause);
            }
            else if (module == "Soft Reset")
            {
                DisposeAllUserControls();
                SetUserControlPosition(softreset);
            }
            else if (module == "Auto-Attack")
            {
                DisposeAllUserControls();
                SetUserControlPosition(autoattack);
            }
            else if (module == "Refill HP")
            {
                DisposeAllUserControls();
                SetUserControlPosition(refillhp);
            }
            else if (module == "Refill MP")
            {
                DisposeAllUserControls();
                SetUserControlPosition(refillmp);
            }
            else if (module == "Refill Drive")
            {
                DisposeAllUserControls();
                SetUserControlPosition(refilldrive);
            }
            else if (module == "Auto-Jump")
            {
                DisposeAllUserControls();
                SetUserControlPosition(autojump);
            }
            else if (module == "Game Speed")
            {
                DisposeAllUserControls();
                SetUserControlPosition(gamespeed);
            }
            else if (module == "Movement Speed")
            {
                DisposeAllUserControls();
                SetUserControlPosition(movementspeed);
            }
            else if (module == "30 FPS")
            {
                DisposeAllUserControls();
                SetUserControlPosition(fps30);
            }
            else if (module == "FoV")
            {
                DisposeAllUserControls();
                SetUserControlPosition(fov);
            }
            else if (module == "No Magic")
            {
                DisposeAllUserControls();
                SetUserControlPosition(nomagic);
            }
            else if (module == "No Attack")
            {
                DisposeAllUserControls();
                SetUserControlPosition(noattack);
            }
            else if (module == "No Drive")
            {
                DisposeAllUserControls();
                SetUserControlPosition(nodrive);
            }
            else if (module == "No Items")
            {
                DisposeAllUserControls();
                SetUserControlPosition(noitems);
            }
            else if (module == "Attack 0")
            {
                DisposeAllUserControls();
                SetUserControlPosition(attack0);
            }
            else if (module == "Magic 0")
            {
                DisposeAllUserControls();
                SetUserControlPosition(magic0);
            }
            else if (module == "Defense 0")
            {
                DisposeAllUserControls();
                SetUserControlPosition(defense0);
            }
            else if (module == "Empty Magic")
            {
                DisposeAllUserControls();
                SetUserControlPosition(emptymagic);
            }
            else if (module == "Empty Drive")
            {
                DisposeAllUserControls();
                SetUserControlPosition(emptydrive);
            }
            else if (module == "Random Consumable")
            {
                DisposeAllUserControls();
                SetUserControlPosition(randomconsumable);
            }
            else if (module == "Random Keyblade")
            {
                DisposeAllUserControls();
                SetUserControlPosition(randomkeyblade);
            }
            else if (module == "Attack 255")
            {
                DisposeAllUserControls();
                SetUserControlPosition(attack255);
            }
            else if (module == "Blind Sight")
            {
                DisposeAllUserControls();
                SetUserControlPosition(blindsight);
            }
            else if (module == "Defense 255")
            {
                DisposeAllUserControls();
                SetUserControlPosition(defense255);
            }
            else if (module == "Flashbang")
            {
                DisposeAllUserControls();
                SetUserControlPosition(flashbang);
            }
            else if (module == "Invisible Models")
            {
                DisposeAllUserControls();
                SetUserControlPosition(invisiblemodels);
            }
            else if (module == "Magic 255")
            {
                DisposeAllUserControls();
                SetUserControlPosition(magic255);
            }
            else if (module == "Phone Mode")
            {
                DisposeAllUserControls();
                SetUserControlPosition(phonemode);
            }
            else if (module == "Random Camera")
            {
                DisposeAllUserControls();
                SetUserControlPosition(randomcamera);
            }
            else if (module == "End Drive")
            {
                DisposeAllUserControls();
                SetUserControlPosition(enddrive);
            }
            else if (module == "Drive Anywhere")
            {
                DisposeAllUserControls();
                SetUserControlPosition(driveanywhere);
            }
            else if (module == "Refill Form Duration")
            {
                DisposeAllUserControls();
                SetUserControlPosition(refillformduration);
            }
            else if (module == "Force Final")
            {
                DisposeAllUserControls();
                SetUserControlPosition(drivefinal);
            }
            else if (module == "Force Limit")
            {
                DisposeAllUserControls();
                SetUserControlPosition(drivelimit);
            }
            else if (module == "Force Master")
            {
                DisposeAllUserControls();
                SetUserControlPosition(drivemaster);
            }
            else if (module == "Force Wisdom")
            {
                DisposeAllUserControls();
                SetUserControlPosition(drivewisdom);
            }
            else if (module == "Force Valor")
            {
                DisposeAllUserControls();
                SetUserControlPosition(drivevalor);
            }
            else if (module == "Force Anti")
            {
                DisposeAllUserControls();
                SetUserControlPosition(driveanti);
            }
            #endregion
        }

        private void GetPID()
        {
            int pid = mem.GetProcIdFromName("KINGDOM HEARTS II FINAL MIX");
            bool openProc = false;

            if (pid > 0) openProc = mem.OpenProcess(pid);
        }

        private void DisposeAllUserControls()
        {
            UserControl[] userControlArray = new UserControl[41]
            {
                #region UserControlsList
                attack0,
                attack255,
                autoattack,
                autojump,
                blindsight,
                blockinput,
                blockpause,
                defense0,
                defense255,
                driveanti,
                driveanywhere,
                drivefinal,
                drivelimit,
                drivemaster,
                drivewisdom,
                drivevalor,
                emptydrive,
                emptymagic,
                enddrive,
                flashbang,
                fov,
                fps30,
                gamespeed,
                invisiblemodels,
                magic0,
                magic255,
                movementspeed,
                noattack,
                nodrive,
                noitems,
                nomagic,
                onehp,
                phonemode,
                randomcamera,
                randomconsumable,
                randomkeyblade,
                refilldrive,
                refillformduration,
                refillhp,
                refillmp,
                softreset
                #endregion
            };
            foreach (UserControl userControl in userControlArray)
            {
                try { tp_modules.Controls.Remove(userControl); }
                catch
                {
                    //nothing
                }
            }
        }

        private void SetUserControlPosition(UserControl control)
        {
            control.Location = new Point(180, 6);
            control.Size = new Size(528, 300);
            tp_modules.Controls.Add(control);
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

            var auth = await server.Listen();
            var resp = await api.Auth.GetAccessTokenFromCodeAsync(auth.Code, tb_appclientsecret.Text, "http://localhost:8080/redirect/", tb_appclientid.Text);

            api.Settings.AccessToken = resp.AccessToken;
            api.Settings.ClientId = tb_appclientid.Text;
            var user = (await api.Helix.Users.GetUsersAsync()).Users[0];
            MessageBox.Show($"Authorization success!\n\nUser: {user.DisplayName} (id: {user.Id})\nExpires in: {resp.ExpiresIn}\nScopes: {string.Join(", ", resp.Scopes)}\n\nInfo has been stored to the settings.\nYou may start the bot now.");
            tb_broadcaster.Text = user.DisplayName;
            tb_streameraccesstoken.Text = resp.AccessToken;
            tb_streamerrefreshtoken.Text = resp.RefreshToken;
            tb_streameraccountid.Text = user.Id;
            Settings.Default.Save();
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