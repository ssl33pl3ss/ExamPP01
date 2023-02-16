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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int authorizationSuccessfulFlag = 0;
            string inputLogin = LoginBox.Text;
            string inputPassword = PasswordBox.Password;
            string[] allLoginData = File.ReadAllLines("login_data.txt");
            if (allLoginData.Length <= 0) authorizationSuccessfulFlag = 0;
            else
            {
                for (int i = 0; i < allLoginData.Length; i++)
                {
                    string[] currLine = allLoginData[i].Split(' ');
                    if (currLine[0] == inputLogin)
                    {
                        if (currLine[1] == inputPassword)
                        {
                            authorizationSuccessfulFlag = 1;
                            break;
                        }
                    }
                }
            }

            if (authorizationSuccessfulFlag == 0) InvalidPasswordText.Foreground = Brushes.Red;
            else
            {
                InvalidPasswordText.Foreground = Brushes.Transparent;
                MessageBox.Show("Авторизация пройдена успешно!");
            }
        }

        private void GoToRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
