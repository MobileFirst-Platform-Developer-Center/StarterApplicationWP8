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

namespace StarterApplicationWP8
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
            setPageText();
        }

        private void setPageText(){
            String strAbout;
            strAbout = "COPYRIGHT LICENSE:\nThis information contains sample code provided in source code form. You may copy, modify,";
            strAbout += " and distribute these sample programs in any form without payment to IBM® for the purposes of developing,";
            strAbout += " using, marketing or distributing application programs conforming to the application programming interface";
            strAbout += " for the operating platform for which the sample code is written.\nNotwithstanding anything to the contrary,";
            strAbout += " IBM PROVIDES THE SAMPLE SOURCE CODE ON AN \"AS IS\" BASIS AND IBM DISCLAIMS ALL WARRANTIES, EXPRESS OR IMPLIED,";
            strAbout += "INCLUDING, BUT NOT LIMITED TO, ANY IMPLIED WARRANTIES OR CONDITIONS OF MERCHANTABILITY, SATISFACTORY QUALITY,";
            strAbout += " FITNESS FOR A PARTICULAR PURPOSE, TITLE, AND ANY WARRANTY OR CONDITION OF NON-INFRINGEMENT.\n";
            strAbout += " IBM SHALL NOT BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE USE OR OPERATION OF THE SAMPLE SOURCE CODE.";
            strAbout += " IBM HAS NO OBLIGATION TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS OR MODIFICATIONS TO THE SAMPLE SOURCE CODE.";

            AboutPageText.Text = strAbout;
        }

        private void BackToFeeds(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}