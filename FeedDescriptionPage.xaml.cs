/**
* Copyright 2015 IBM Corp.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace StarterApplicationWP8
{
    public partial class FeedDescriptionPage : PhoneApplicationPage
    {
        private string title, link, pubDate;

        public FeedDescriptionPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.TryGetValue("title", out title))
            {
                FeedTitle.Text = title.Replace("\"", "");
            }
            if (NavigationContext.QueryString.TryGetValue("link", out link))
            {
                FeedDescription.Source = new Uri(link);
            }
            if (NavigationContext.QueryString.TryGetValue("pubDate", out pubDate))
            {
                FeedPubDate.Text = pubDate.Replace("\"", "");
            }
        }

        private void BackToFeeds(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void showAboutPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }
    }
}
