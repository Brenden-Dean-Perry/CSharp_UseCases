using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace UseCases
{
    public interface INotify
    {
        public NotificationResponse Notify(string Message);
        public NotificationResponse NotifyWarning(string Message);
        public NotificationResponse NotifyError(string Message);
        public NotificationResponse NotifyYesNo(string Message);
        public NotificationResponse NotifyWarningYesNo(string Message);
        public NotificationResponse NotifyErrorYesNo(string Message);
        public NotificationResponse Inputbox(string Message, int MaxAllowedCharaters = 100);
        public NotificationResponse InputboxDateTime(string Message, DateTime DefaultDateTime);
        public string GetInputBoxValue();
        public DateTime GetInputBoxDate();
    }
}
