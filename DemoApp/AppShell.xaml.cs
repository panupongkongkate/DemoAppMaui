﻿using DemoApp.Pages;

namespace DemoApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ManageToDoPage), typeof(ManageToDoPage));
    }
}
