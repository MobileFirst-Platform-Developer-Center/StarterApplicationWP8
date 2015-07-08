/*
 * COPYRIGHT LICENSE: This information contains sample code provided in source code form. You may copy, modify, and distribute
 * these sample programs in any form without payment to IBM® for the purposes of developing, using, marketing or distributing
 * application programs conforming to the application programming interface for the operating platform for which the sample code is written.
 * Notwithstanding anything to the contrary, IBM PROVIDES THE SAMPLE SOURCE CODE ON AN "AS IS" BASIS AND IBM DISCLAIMS ALL WARRANTIES,
 * EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, ANY IMPLIED WARRANTIES OR CONDITIONS OF MERCHANTABILITY, SATISFACTORY QUALITY,
 * FITNESS FOR A PARTICULAR PURPOSE, TITLE, AND ANY WARRANTY OR CONDITION OF NON-INFRINGEMENT. IBM SHALL NOT BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE USE OR OPERATION OF THE SAMPLE SOURCE CODE.
 * IBM HAS NO OBLIGATION TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS OR MODIFICATIONS TO THE SAMPLE SOURCE CODE.
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