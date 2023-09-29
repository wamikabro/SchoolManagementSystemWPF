﻿using SchoolManagementSystem.User_Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SqlConnection connection { get; private set; }

        private static App _instance;

        public static App Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new App();
                    _instance.InitializeDatabaseConnection();
                }
                return _instance;
            }
        }
        private void InitializeDatabaseConnection()
        {
            connection = new SqlConnection("Data Source=DESKTOP-RUINSQ2\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True");
        }

        private App()
        {
            // Initialize the database connection so that the code inside App can also find the connection string.
            InitializeDatabaseConnection();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // We can not use "using" here since for that we will have to call app instance but it will break the code.
            connection.Open();

            SqlCommand themeSwitchDatabase = new
                    SqlCommand("SELECT ThemeSwitch from Settings", connection);
            SqlDataReader reader = themeSwitchDatabase.ExecuteReader();
            reader.Read();



            // if themeSwitch sends True. That means dark theme was stored. So we must apply dark on startup.
            if (reader.GetBoolean(0))
            {
                ResourceDictionary darkTheme = new ResourceDictionary
                {
                    Source = new Uri("ResourceDictionaries/DarkTheme.xaml", UriKind.Relative)
                };

                // apply dark theme
                Application.Current.Resources.MergedDictionaries.Add(darkTheme);
            }
            else // otherwise apply light theme if the answer if 0. In other words, if the last time switch state was stored as 0
            {
                ResourceDictionary lightTheme = new ResourceDictionary
                {
                    Source = new Uri("ResourceDictionaries/LightTheme.xaml", UriKind.Relative)
                };

                // apply dark theme
                Application.Current.Resources.MergedDictionaries.Add(lightTheme);
            }
            connection.Close();
        }
    }
}
