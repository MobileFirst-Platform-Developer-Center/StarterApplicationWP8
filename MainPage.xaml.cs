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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using StarterApplicationWP8.Resources;
using IBM.Worklight;

namespace StarterApplicationWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        public List<String> FeedsDescriptionsList;
        public List<String> FeedsLinksList;
        public List<String> FeedsTitlesList;
        public List<String> FeedsPubDateList;

        // Constructor
        public MainPage()
        {
            FeedsDescriptionsList = new List<String>();
            FeedsLinksList = new List<String>();
            FeedsTitlesList = new List<String>();
            FeedsPubDateList = new List<String>();

            InitializeComponent();

            showFeeds(null, null);
        }

        private void showFeeds(object sender, EventArgs e)
        {
            try
            {
                WLClient client = WLClient.getInstance();
                client.connect(new MyConnectResponseListener(this));
            }
            catch (IBM.Worklight.WorklightException ex)
            {
                MessageBox.Show("Error\n" + ex.Message);
            }
        }

        private static void setProgressIndicator(bool isVisible)
        {
            SystemTray.ProgressIndicator.IsIndeterminate = isVisible;
            SystemTray.ProgressIndicator.IsVisible = isVisible;
        }

        private void refreshFeeds(object sender, EventArgs e)
        {
            SystemTray.ProgressIndicator = new ProgressIndicator();
            setProgressIndicator(true);
            SystemTray.ProgressIndicator.Text = "Loading...";

            showFeeds(null, null);
            setProgressIndicator(false);
        }

        private void showAboutPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void MyListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Find out which item was clicked
            if (e.AddedItems.Count > 0)
            {
                int curIndex = Convert.ToInt32(MyListBox.SelectedIndex);
                NavigationService.Navigate(new Uri("/FeedDescriptionPage.xaml?title=" + FeedsTitlesList[curIndex] + "&link=" + FeedsLinksList[curIndex] + "&pubDate=" + FeedsPubDateList[curIndex], UriKind.Relative));
            }
        }
    }
}