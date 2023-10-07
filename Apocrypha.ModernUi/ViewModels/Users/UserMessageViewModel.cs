﻿using System;
using System.Windows.Input;
using Apocrypha.ModernUi.Services.UserInformationService;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Users;

public delegate UserMessageViewModel CreateUserMessageViewModel(string message, InformationType type, int? deleteAfter, string messageDetails = "");

public class UserMessageViewModel : BaseViewModel
{
    private string _messageHeader;
    private string _messageContent;
    private InformationType _informationType;
    private DateTime _createdAt;
    private int? _deleteAfter;

    private readonly IUserInformationMessageService _userInformationMessageService;

    public UserMessageViewModel(string message, InformationType type, int? deleteAfter, string messageDetails,
        IUserInformationMessageService userInformationMessageService)
    {
        MessageHeader = message;
        MessageContent = messageDetails;
        InformationType = type;
        CreatedAt = DateTime.Now;
        _deleteAfter = deleteAfter;
        _userInformationMessageService = userInformationMessageService;

        RemoveMessageCommand = new RelayCommand(ExecuteRemoveMessageCommand, CanExecuteRemoveMessageCommand);
    }

    private bool CanExecuteRemoveMessageCommand()
    {
        return true;
    }

    private void ExecuteRemoveMessageCommand()
    {
        _userInformationMessageService.RemoveDisplayMessage(this);
    }

    public string MessageHeader
    {
        get => _messageHeader;
        set
        {
            if (value == _messageHeader)
                return;

            _messageHeader = value;
            OnPropertyChanged();
        }
    }

    public string MessageContent
    {
        get => _messageContent;
        set
        {
            if (value == _messageContent)
                return;

            _messageContent = value;
            OnPropertyChanged();
        }
    }

    public InformationType InformationType
    {
        get => _informationType;
        set
        {
            if (value == _informationType)
                return;

            _informationType = value;
            OnPropertyChanged();
        }
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set
        {
            if (value.Equals(_createdAt))
                return;

            _createdAt = value;
            OnPropertyChanged();
        }
    }

    public int DeleteAfter
    {
        get => _deleteAfter ?? 0;
        set
        {
            if (value == _deleteAfter)
                return;

            _deleteAfter = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TimeRemaining));
        }
    }

    public double TimeRemaining
    {
        get
        {
            if (_deleteAfter == null)
                return 1;

            return (CreatedAt.AddMilliseconds(DeleteAfter) - DateTime.Now).TotalMilliseconds;
        }
    }

    public ICommand RemoveMessageCommand { get; }
}