using System;

namespace KH2RewardListener.Logger
{
    public class LogService
    {
        public static LogService Instance { get; } = new LogService();

        public event EventHandler<LogEventArgs> OnLogReceived;

        public void Information(string text)
        {
            EventHandler<LogEventArgs> onLogReceived = OnLogReceived;
            if (onLogReceived == null)
                return;
            onLogReceived((object)this, new LogEventArgs()
            {
                Text = DateTime.Now.ToTimeString() + " [INF] - " + text
            });
        }

        public void Error(string text)
        {
            EventHandler<LogEventArgs> onLogReceived = OnLogReceived;
            if (onLogReceived == null)
                return;
            onLogReceived((object)this, new LogEventArgs()
            {
                Text = DateTime.Now.ToTimeString() + " [ERR] - " + text
            });
        }

        public void Debug(string text)
        {
            EventHandler<LogEventArgs> onLogReceived = OnLogReceived;
            if (onLogReceived == null)
                return;
            onLogReceived((object)this, new LogEventArgs()
            {
                Text = DateTime.Now.ToTimeString() + " [DBG] - " + text
            });
        }
    }
}
