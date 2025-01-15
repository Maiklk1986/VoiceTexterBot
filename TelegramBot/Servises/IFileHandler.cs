using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Servises
{
   public interface IFileHandler
    {
        Task Download(string FileID, CancellationToken ct);
        string Process(string param);
    }
}
