using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Supabase;
using Supabase.Realtime.PostgresChanges;

namespace Chat
{
    public partial class ShowMessage : Window
    {
        public IEnumerable<MessageInfo?> First { get; set; } = new List<MessageInfo>();
        public IEnumerable<MessageInfo?> Items { get; set; } = new List<MessageInfo>();
        public IEnumerable<MessageInfo> SelItems { get; set; } = new List<MessageInfo>();
        public ShowMessage()
        {
            InitializeComponent();
            LoadData(messages);
        }
        public async void LoadData(ListBox l)
        {
            var data = await SupabaseClient.Client.From<MessageRow>().Select(x => new object[] {x.Id, x.Context, x.Date, x.Id_user }).Get();
            foreach (MessageRow m in data.Models)
            {
                var result = await SupabaseClient.Client.From<UserRow>().Select(x => new object[] { x.Id, x.Name }).Where(x => x.Id == m.Id_user).Get();
                var model = new MessageInfo
                {
                    Id = m.Id,
                    Name = result.Models[0].Name,
                    Date = m.Date,
                    Context = m.Context,
                    Id_u = result.Models[0].Id
                };
                First = First.Append(model);
            }
            Items = First;
            l.Items = First;


        }
        private async void ButtonUpdate_OnClick(object? sender, RoutedEventArgs e)
        {
            int id_message = 0;
            


            foreach (MessageInfo m in messages.SelectedItems)
            {
                id_message = m.Id;
                MessageInfo r = m;
                if (id_message != 0 && Session.id == r.Id_u)
                {
                    Session.id_mes = id_message;
                    var dataWindow = new Update();

                    await dataWindow.ShowDialog(this);
                    this.Close();
                    //LoadData(messages);
                    return;
                }
                else
                {
                    err.Text = "¬ы не выбрали сообщение или это не ваше сообщение!";
                }
            }
            
        }
        private async void ButtonDelete_OnClick(object? sender, RoutedEventArgs e)
        {
            int id_message = 0;



            foreach (MessageInfo m in messages.SelectedItems)
            {
                id_message = m.Id;
                MessageInfo r = m;
                if (id_message != 0 && Session.id == r.Id_u)
                {
                    Session.id_mes = id_message;
                    await SupabaseClient.Client.From<MessageRow>().Where(x => x.Id == id_message).Delete();
                    this.Close();
                    return;
                }
                else
                {
                    err.Text = "¬ы не выбрали сообщение или это не ваше сообщение!";
                }
            }

        }

        }
    
}
