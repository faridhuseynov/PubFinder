using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Services
{
    interface IMessageService
    {
        bool ShowYesNo(string text, string title = "Your choice");
        void ShowError(string text, string title = "Error");
    }
}
