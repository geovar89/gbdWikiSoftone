﻿using System;
using Microsoft.Bot.Builder.FormFlow;

public enum CarOptions { Convertible = 1, SUV, EV };
public enum ColorOptions { Red = 1, White, Blue };
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
public enum LanguageOptions { Greek = 1, English };
public enum OperationOptions { All = 1, At least one };
=======

>>>>>>> parent of 8802048... basic form position
=======

>>>>>>> parent of 8802048... basic form position
=======

>>>>>>> parent of 8802048... basic form position
// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    [Prompt("Hi! What is your {&}?")]
    public string Name { get; set; }

    [Prompt("Please select your favorite car type {||}")]
    public CarOptions Car { get; set; }

    [Prompt("Please select your favorite {&} {||}")]
    public ColorOptions Color { get; set; }

    public static IForm<BasicForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<BasicForm>().Build();
    }

    public static IFormDialog<BasicForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
