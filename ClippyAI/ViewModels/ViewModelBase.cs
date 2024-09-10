﻿using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using ClippyAI.Views;
using Avalonia.Controls.ApplicationLifetimes;
namespace ClippyAI.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    protected ViewModelBase()
    {
        ErrorMessages = [];
    }

    [ObservableProperty]
    private ObservableCollection<string>? _errorMessages;

    protected async void ShowErrorMessage(string message)
    {
        var dialog = new ErrorMessageDialog
        {
            DataContext = new ErrorMessageDialogViewModel(message)
        };

        if (Avalonia.Application.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            await dialog.ShowDialog(desktop.MainWindow!);
        }
    }
}
