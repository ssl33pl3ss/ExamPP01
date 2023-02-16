using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PR03_Frames.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreationPage.xaml
    /// </summary>
    public partial class CreationPage : Page
    {
        public CreationPage()
        {
            InitializeComponent();
            this.DataContext = new ValidationClass();
        }

        public void FileWrite(object sender, RoutedEventArgs e)
        {
            string res = ValidationClass._id + "\t" + ValidationClass._imya + "\t" + ValidationClass._familiya + "\t" + ValidationClass._otchestvo + "\t" + ValidationClass._passport + "\t" + ValidationClass._phone + "\t" + ValidationClass._email;

            using (StreamWriter writer = File.AppendText("employee.txt"))
            {
                writer.WriteLine(res);
                writer.Close();
            }

            MessageBox.Show("Сотрудник успешно зарегистрирован");
        }

        private void BackAuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AuthorizationPage());
        }
    }
    public class ValidationClass : Window
    {
        public static string _familiya, _imya, _otchestvo, _phone, _email, _id, _passport;
        public static string Id
        {
            get { return _id; }
            set
            {
                List<string> UsedId = new List<string>();
                using (StreamReader reader = new StreamReader("employee.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        UsedId.Add(line.Substring(0, line.IndexOf("\t")));
                    }
                }

                for (int i = 0; i < UsedId.Count; i++)
                {
                    if (UsedId[i] == value)
                        throw new ArgumentException("Данный идентификатор занят");
                }

                foreach (char a in value)
                {
                    if (char.IsLetter(a))
                        throw new ArgumentException("Строка содержит не только цифры");
                }
                _id = value;
            }
        }

        public string Familiya
        {
            get { return _familiya; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Строка пуста");
                else if (!char.IsUpper(value[0]))
                    throw new ArgumentException("Первая буква не является заглавной");
                else if (!Regex.IsMatch(value, "^[А-Яа-я]+$"))
                    throw new ArgumentException("В строке не только кириллица");
                else
                {
                    foreach (char a in value)
                    {
                        if (!char.IsLetter(a))
                            throw new ArgumentException("Строка содержит цифры");
                    }
                }
                _familiya = value;
            }
        }

        public string Imya
        {
            get { return _imya; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Строка пуста");
                else if (!char.IsUpper(value[0]))
                    throw new ArgumentException("Первая буква не является заглавной");
                else if (!Regex.IsMatch(value, "^[А-Яа-я]+$"))
                    throw new ArgumentException("В строке не только кириллица");
                else
                {
                    foreach (char a in value)
                    {
                        if (!char.IsLetter(a))
                            throw new ArgumentException("Строка содержит цифры");
                    }
                }
                _imya = value;
            }
        }

        public string Otchestvo
        {
            get { return _otchestvo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Строка пуста");
                else if (!char.IsUpper(value[0]))
                    throw new ArgumentException("Первая буква не является заглавной");
                else if (!Regex.IsMatch(value, "^[А-Яа-я]+$"))
                    throw new ArgumentException("В строке не только кириллица");
                else
                {
                    foreach (char a in value)
                    {
                        if (!char.IsLetter(a))
                            throw new ArgumentException("Строка содержит цифры");
                    }
                }
                _otchestvo = value;
            }
        }

        public string Passport
        {
            get { return _passport; }
            set
            {
                if (!Regex.IsMatch(value, @"^[0-9]{10}$"))
                    throw new ArgumentException("Неверный формат паспорта");
                _passport = value;
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (!Regex.IsMatch(value, @"^[+]7[0-9]{10}$|^8[0-9]{10}$"))
                    throw new ArgumentException("Неверный формат телефона");
                _phone = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (!Regex.IsMatch(value, @"^\D\w+[@]firma[.]ru$"))
                    throw new ArgumentException("Неверный формат почты");
                else if (!char.IsLetter(value[0]))
                    throw new ArgumentException("Неверный формат почты");
                else
                    foreach (char a in value)
                    {
                        if (Regex.IsMatch(a.ToString(), "^[А-Яа-я]+$"))
                            throw new ArgumentException("Почта содержит кириллицу");
                    }
                _email = value;
            }
        }
    }
}
