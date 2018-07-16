﻿using System;
using System.Timers;
using Microsoft.Extensions.Logging;

namespace AdventureBot
{
    public class UserContext : IDisposable
    {
        private readonly User.User _user;
        private Timer _timer;
        private DateTime _opened;
        private readonly ILogger _logger = Logger.CreateLogger<UserContext>();
        
        public UserContext(UserId userId)
        {
            _user = UserManager.Instance.Get(userId);
            InitializeTimer();
        }

        public UserContext(UserId userId, ChatId chatId)
        {
            _logger.LogDebug($"Opening user {userId}@{chatId}");
            _user = UserManager.Instance.Get(userId);
            _user.MessageManager.ChatId = chatId;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _timer = new Timer
            {
                Interval = 3000,
                AutoReset = true
            };
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
            _opened = DateTime.Now;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            throw new TimeoutException("User have been opened too long");
        }

        public void Dispose()
        {
            _logger.LogDebug($"User closed in {DateTime.Now - _opened}");
            _timer.Stop();
            UserManager.Instance.Save(_user);
            _timer.Dispose();
        }

        public static implicit operator User.User(UserContext userContext)
        {
            return userContext._user;
        }
    }
}