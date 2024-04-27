using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Chat
{
    public partial class MainWindow : Window
    {
        public class MainWindowDataContext
        {
            public string Login { get; set; } = "";
            public string Password { get; set; } = "";
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowDataContext();
        }

        private async void ButtonLogin_OnClick(object? sender, RoutedEventArgs e)
        {
            // Получаем данные контекста
            if (DataContext is MainWindowDataContext data)
            {
                // Производим вход пользователя
                //await SupabaseClient.Client.Auth.SignIn(data.Login, data.Password);
                
                    await SupabaseClient.Client.Auth.SignIn(login.Text, pass.Text);
                    //var dataWindow = new FormaMessage(name.Text, login.Text, pass.Text);

                    //await dataWindow.ShowDialog(this);
                    var model = new UserRow
                    {
                        Name = name.Text,
                        Email = login.Text,
                        Password = pass.Text
                    };
                    var result = await SupabaseClient.Client.From<UserRow>().Select(x => new object[] { x.Id, x.Name, x.Password }).Where(x => x.Name == model.Name).Get();
                    if (result.Models.Count>0)
                    {
                    Session.id = result.Models[0].Id;
                }
                    else {
                        await SupabaseClient.Client.From<UserRow>().Insert(model);
                    var res = await SupabaseClient.Client.From<UserRow>().Select(x => new object[] { x.Id, x.Name, x.Password }).Where(x => x.Name == model.Name).Get();
                    Session.id = res.Models[0].Id;
                }
                    var dataWindow = new FormaMessage();
                   
                    await dataWindow.ShowDialog(this);

                
                // Показываем окно с данными
                // var dataWindow = new FormaMessage(name.Text, login.Text, pass.Text);
                // await dataWindow.ShowDialog(this);
            }
        }

        private async void ButtonRegister_OnClick(object? sender, RoutedEventArgs e)
        {
            // Получаем данные контекста
            if (DataContext is MainWindowDataContext data)
            {
                try
                {
                    // Производим регистрацию пользователя
                    await SupabaseClient.Client.Auth.SignUp(login.Text, pass.Text);
                    
                }catch(Exception ex)
                {
                    messageerr.Text = "Вы уже зарегистрированны!";
                }

                
            }
        }
        
        
    }
}
