using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EkzTestPP01
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            int existingLoginFlag = 0;
            string inputLogin = LoginBox.Text;
            string inputPassword = PasswordBox.Password;
            string[] allLoginData = File.ReadAllLines("login_data.txt");

            if(string.IsNullOrEmpty(inputLogin) || string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Логин и пароль не должны быть пустыми");
                return;
            }

            if (allLoginData.Length <= 0) existingLoginFlag = 0;
            else
            {
                for(int i = 0; i < allLoginData.Length; i++)
                {
                    string[] currLine = allLoginData[i].Split(' ');
                    if(currLine[0] == inputLogin)
                    {
                        existingLoginFlag = 1;
                        break;
                    }
                }
            }

            if (existingLoginFlag == 1) LoginIsAlreadyInUseText.Foreground = Brushes.Red;
            else
            {
                File.AppendAllText("login_data.txt", String.Format($"{inputLogin} {inputPassword}\n"));
                LoginIsAlreadyInUseText.Foreground = Brushes.Transparent;
                MessageBox.Show("Регистрация успешно завершена!");
            }
        }

        private void GoToAuthorization_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
