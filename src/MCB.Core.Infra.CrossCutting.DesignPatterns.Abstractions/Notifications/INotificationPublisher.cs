using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Notifications.Models;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Notifications;

public interface INotificationPublisher
{
    Task PublishNotificationAsync(Notification notification, CancellationToken cancellationToken);
}
