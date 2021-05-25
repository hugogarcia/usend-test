using System.Collections.Generic;
using USend.UserApi.Application.Notifications;

namespace USend.UserApi.Application.Interfaces
{
    public interface INotificationContext
    {
        bool HasNotifications { get; }
        IReadOnlyCollection<Notification> Notifications { get; }
        void AddNotification(string message);
    }
}