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
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Threading;
using StarterApplicationWP8.Resources;
using Newtonsoft.Json;
using IBM.Worklight;

namespace StarterApplicationWP8
{
    public class MyConnectResponseListener : WLResponseListener
    {
        StarterApplicationWP8.MainPage myMainPage;

        public MyConnectResponseListener(StarterApplicationWP8.MainPage page)
        {
            myMainPage = page;
        }

        public void onSuccess(WLResponse response)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                WLProcedureInvocationData invocationData = new WLProcedureInvocationData("StarterApplicationAdapter", "getEngadgetFeeds");
                invocationData.setParameters(new Object[] { });
                String myContextObject = "StarterApplicationWP8";
                WLRequestOptions options = new WLRequestOptions();
                options.setInvocationContext(myContextObject);
                WLClient.getInstance().invokeProcedure(invocationData, new MyInvokeListener(myMainPage), options);
            });

        }

        public void onFailure(WLFailResponse response)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                MessageBox.Show("Connection failure : " + response.getErrorMsg());
            });
        }
    }
}
