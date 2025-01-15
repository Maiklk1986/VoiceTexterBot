using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Models;

namespace TelegramBot.Servises
{
    internal interface IStorage
    {
        public Session GetSession(long chatId);
    }
}
