using BotYoutube.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotYoutube.Extensions
{
    public static class TaskExtension
    {
        public static void DoTaskNotNull<T>(this T task, Action<T> action) {
            if (task != null) { action(task); TaskBase.Sleep(500); }
        }
    }
}
