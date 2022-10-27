﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISS_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        public NotificationsPage()
        {
            InitializeComponent();
        }

        private void buttonAddNewNotif_Pressed(object sender, EventArgs e)
        {
            stackLayoutLocationNotifs.Children.Add(new NotificationView("moon", "3", "5", "house_white"));
        }
    }
}