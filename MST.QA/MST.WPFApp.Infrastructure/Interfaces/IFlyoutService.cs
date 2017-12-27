﻿namespace MST.WPFApp.Infrastructure.Interfaces
{
    public interface IFlyoutService
    {
        void ShowFlyout(string flyoutName);

        bool CanShowFlyout(string flyoutName);
    }
}
