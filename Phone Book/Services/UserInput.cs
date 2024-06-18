﻿using System.Text.RegularExpressions;
using FluentValidation;
using Spectre.Console;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

public class UserInput
{
    private Validation _validation;

    public UserInput()
    {
        _validation = new Validation();
    }

    public MainMenuOptions MainMenu()
    {
        var input = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please choose an action:")
            .PageSize(10)
            .AddChoices(Enum.GetNames(typeof(MainMenuOptions)).ToList())
            );

        return Enum.Parse<MainMenuOptions>(input);
    }

    public Contact Add()
    {
        var name = _validation.GetValidName("Add a contact name:");
        var emails = _validation.AddEmails();
        var phoneNumbers = _validation.AddPhoneNumber();

        var contact = new Contact { Name = name, EmailAddresses = emails, PhoneNumbers = phoneNumbers };

        return contact;
    }


}