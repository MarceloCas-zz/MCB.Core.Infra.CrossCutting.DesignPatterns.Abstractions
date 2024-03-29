﻿using MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Notifications.Models.Enums;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Notifications.Models;

public struct Notification
{
    // Properties
    public NotificationType NotificationTypeMyProperty { get; }
    public string Code { get; }
    public string Description { get; }

    // Constructors
    public Notification(NotificationType notificationType, string code, string description)
    {
        NotificationTypeMyProperty = notificationType;
        Code = code;
        Description = description;
    }

}
