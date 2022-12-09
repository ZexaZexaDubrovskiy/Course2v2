using System;
using System.Windows;

namespace Realty.BaseWindows
{
    public partial class Capcha : Window
    {
        string login = " ", password = " ";
        private Base.RealtyEntities Database;
        //конструктор
        public Capcha(string login, string password)
        {
            InitializeComponent();
            newCaptcha();
            this.login = login;
            this.password = password;
            Database = SourceCore.MyBase;
        }
        //создание капчи
        private void newCaptcha()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = " ";
            string temp = " ";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            textBox1.Text = pwd;
        }
        //обновление капчи
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            newCaptcha();
        }
        //завершение регистрации
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                Base.Accounts newUser = new Base.Accounts()
                {
                    Admin = 0,
                    Login = login,
                    Password = password,
                    money = 0
                };

                Database.Accounts.Add(newUser);
                Database.SaveChanges();
                Home home = new Home(newUser);
                home.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка в капче!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
