using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool[] a = { false, false, false, false, false};
        List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            List<string> styles = new List<string> { "light", "dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "dark";
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Contains("@gmail.com")){
                bool flag = false;
                foreach (var user in users)
                {
                    if(user.email == textBox1.Text)
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    if (progressBar1.Value == 100)
                    {

                        if (PassBox1.Password == PassBox2.Password)
                        {
                            users.Add(new User(textBox1.Text, PassBox1.Password));
                            MessageBox.Show("User is registered successfully");
                        }
                        else
                        {
                            MessageBox.Show("Your repeated passwors is not correct");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your password is not 100% safe. Use lower and upper cases, symbols and numbers. Also you password length must be minimum 8 symbols");
                    }
                }
                else
                {
                    MessageBox.Show("User is already registered");
                }
            }
            else
            {
                MessageBox.Show("Registration only for gmail users");
            }
        }

        private void PassBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (a[0] == false){
                if (PassBox1.Password.Contains("_") || PassBox1.Password.Contains("@") || PassBox1.Password.Contains("-") || PassBox1.Password.Contains("*") || PassBox1.Password.Contains("?") || PassBox1.Password.Contains("!") || PassBox1.Password.Contains("/"))
                {
                    progressBar1.Value += 20;
                    a[0] = true;
                }
            }
            if (a[0] == true)
            {
                if ((PassBox1.Password.Contains("_") || PassBox1.Password.Contains("@") || PassBox1.Password.Contains("-") || PassBox1.Password.Contains("*") || PassBox1.Password.Contains("?") || PassBox1.Password.Contains("!") || PassBox1.Password.Contains("/")) == false)
                {
                    progressBar1.Value -= 20;
                    a[0] = false;
                }
            }
            if (a[1] == false) { 
                for (int i = 65; i <= 90; i++) 
                { 
                    if(PassBox1.Password.Contains((char)i))
                    {
                        progressBar1.Value += 20;
                        a[1] = true;
                    }
                }
            }
            if (a[1] == true)
            {
                int ii = 0;
                for (int i = 65; i <= 90; i++)
                {
                    if (PassBox1.Password.Contains((char)i))
                    {
                        ii++;
                    }
                }
                if (ii == 0)
                {
                    progressBar1.Value -= 20;
                    a[1] = false;
                }
            }
            if (a[2] == false)
            {
                for (int i = 97; i <= 122; i++)
                {
                    if (PassBox1.Password.Contains((char)i))
                    {
                        progressBar1.Value += 20;
                        a[2] = true;
                    }
                }
            }
            if (a[2] == true)
            {
                int ii = 0;
                for (int i = 97; i <= 122; i++)
                {
                    if (PassBox1.Password.Contains((char)i))
                    {
                        ii++;
                    }
                }
                if (ii == 0)
                {
                    progressBar1.Value -= 20;
                    a[2] = false;
                }
            }
            if (a[3] == false)
            {
                for (int i = 48; i <= 57; i++)
                {
                    if (PassBox1.Password.Contains((char)i))
                    {
                        progressBar1.Value += 20;
                        a[3] = true;
                    }
                }
            }
            if (a[3] == true)
            {
                int ii = 0;
                for (int i = 48; i <= 57; i++)
                {
                    if (PassBox1.Password.Contains((char)i))
                    {
                        ii++;
                    }
                }
                if (ii == 0)
                {
                    progressBar1.Value -= 20;
                    a[3] = false;
                }
            }
            if (a[4] == false && PassBox1.Password.Length >= 8)
            {
                progressBar1.Value += 20;
                a[4] = true;
            }
            if (a[4] == true && PassBox1.Password.Length < 8)
            {
                progressBar1.Value -= 20;
                a[4] = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{PassBox1.Password}");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{PassBox2.Password}");
        }
    }
}