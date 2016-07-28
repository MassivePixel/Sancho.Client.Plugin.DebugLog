// Copyright (c) Massive Pixel.  All Rights Reserved.  Licensed under the MIT License (MIT). See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Sancho.Client.Core;

namespace Sancho.Client.Plugin.DebugLog
{
    public class DebugLogPlugin : IPlugin
    {
        Connection connection;

        public string Name => "plugin-debuglog";

        public bool IsEnabled { get; set; }

        public DebugLogPlugin(Connection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            this.connection = connection;
        }

        public void Recieve(Message message)
        {
            // this plugin doesn't receive any messages
        }

        public Task Log(string text) =>
            IsEnabled
                ? connection.SendAsync(Name, "log", text)
                : Task.FromResult(false);
    }
}
