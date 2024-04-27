using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Chat
{
    public partial class FormaMessage : Window
    {
        public int id;
        public FormaMessage()
        {
            InitializeComponent();
          // message.Text = Session.id.ToString();
        }
        private async void ButtonAddMess_OnClick(object? sender, RoutedEventArgs e)
        {

            var model = new MessageRow
            {
                Context = message.Text,
                Id_user = Session.id
            };
                
            await SupabaseClient.Client.From<MessageRow>().Insert(model);
            
                var dataWindow = new ShowMessage();

                await dataWindow.ShowDialog(this);

                 await dataWindow.ShowDialog(this);

        }
        private async void ButtonClear_OnClick(object? sender, RoutedEventArgs e)
        {


            message.Text = String.Empty;
                  
        }
        private async void ButtonShow_OnClick(object? sender, RoutedEventArgs e)
        {


            var dataWindow = new ShowMessage();

            await dataWindow.ShowDialog(this);

        }


    }
}
