using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Chat
{
    public partial class Update : Window
    {
        public Update()
        {
            InitializeComponent();
            /*var res = SupabaseClient.Client.From<MessageRow>().Select(x => new object[] { x.Id, x.Context }).Where(x => x.Id == Session.id_mes).Get();
            message.Text = res.Result.Models[0].Context;*/
        }
        private async void ButtonUpdate_OnClick(object? sender, RoutedEventArgs e)
        {

            int id = Session.id_mes;
            
            var model = await SupabaseClient.Client.From<MessageRow>().Where(x => x.Id == id).Single();

            model.Context = message.Text;

            await model.Update<MessageRow>();


            mes.Text = "Successfully updated!!!";
            this.Close();


        }
        private async void ButtonClear_OnClick(object? sender, RoutedEventArgs e)
        {


            message.Text = String.Empty;

        }
    }
}
