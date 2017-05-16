using System;
using Microsoft.Bot.Builder.FormFlow;

public enum ColorOptions { Red = 1, White, Blue };
public enum LanguageOptions { Greek = 1, English };
public enum OperationOptions { Όλες = 1, Μία τουλάχιστον };
// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    [Prompt("Γεια σας!Ποιο είναι το username σας {&}?")]
    public string Name { get; set; }

    [Prompt("Παρακαλώ επιλέξτε γλώσσα{||}")]
    public LanguageOptions Language { get; set; }

	[Prompt("Συμπληρώστε τις λέξεις που θέλετε να αναζητήσουμε {&}")]
    public string Words { get; set; }

	[Prompt("Θέλετε τα αποτελέσματα να περιέχουν όλες τις λέξεις ή τουλάχιστον 1{||}?")]
    public LanguageOptions Language { get; set; }

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
