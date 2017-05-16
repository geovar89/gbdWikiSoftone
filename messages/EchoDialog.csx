using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Net.Http;

// For more information about this template visit http://aka.ms/azurebots-csharp-basic
[Serializable]
public class EchoDialog : IDialog<object>
{
    protected int count = 1;
    private static readonly HttpClient client = new HttpClient();
    public Task StartAsync(IDialogContext context)
    {
        try
        {
            context.Wait(MessageReceivedAsync);
        }
        catch (OperationCanceledException error)
        {
            return Task.FromCanceled(error.CancellationToken);
        }
        catch (Exception error)
        {
            return Task.FromException(error);
        }

        return Task.CompletedTask;
    }

    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var message = await argument;
        if (message.Text == "reset")
        {
            PromptDialog.Confirm(
                context,
                AfterResetAsync,
                "Are you sure you want to reset the count?",
                "Didn't get that!",
                promptStyle: PromptStyle.Auto);
        }
        else{
            var values = new Dictionary<string, string>
            {
               { "op", "search" },
               { "ver", "v01" },
               { "lang", "el" },
               { "words",message.Text }
            };

            //var content = new FormUrlEncodedContent(values);
			var responseString = "xx";
            /*var response = await client.PostAsync("http://wiki.softone.gr/main.ashx", content);
            var responseString = await response.Content.ReadAsStringAsync();
            
            responseString = responseString.Replace("&","&amp");
            responseString = responseString.Replace("<","&lt");
            responseString = responseString.Replace(">","&lg");
            //var replacedString = await ReplaceAsync(responseString);*/
            await context.PostAsync(responseString);
            context.Wait(MessageReceivedAsync);
        }
        /*else
        {
            await context.PostAsync($"{this.count++}: You said {message.Text}");
            context.Wait(MessageReceivedAsync);
        }*/
    }

    public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
    {
        var confirm = await argument;
        if (confirm)
        {
            this.count = 1;
            await context.PostAsync("Reset count.");
        }
        else
        {
            await context.PostAsync("Did not reset count.");
        }
        context.Wait(MessageReceivedAsync);
    }
    
    public async Task<string> ReplaceAsync(String input)
    {
        String responseString = input;
        String temp = "";
        
        temp = responseString.Replace("&","&amp");
        temp = responseString.Replace("<","&lt");
        temp = responseString.Replace(">","&lg");
        
        //return responseString;
        //await Task.Delay(100);
        //var sb = new StringBuilder();
        //var lastIndex = 0;
    
        
        return temp;
    }
    
}