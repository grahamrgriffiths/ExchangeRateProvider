﻿using Common.Configuration;
using Core.Parser;
using ExchangeRateUpdater.Common.Http;
using Microsoft.Extensions.Logging;
using System.Text;
using static Common.Enums;

namespace Core.Client
{
    /// <summary>
    /// Common client logic
    /// </summary>
    public abstract class BaseClient
    {
        internal readonly ILogger<BaseClient> _logger;
        internal readonly IConfigurationWrapper _configurationWrapper;
        internal readonly IHttpWrapper _httpWrapper;
        internal readonly IResponseParser _responseParser;
        public BaseClient(ILogger<BaseClient> logger, IConfigurationWrapper configurationWrapper, IHttpWrapper httpWrapper, IResponseParser responseParser)
        {
            _logger = logger;
            _configurationWrapper = configurationWrapper;
            _httpWrapper = httpWrapper;
            _responseParser = responseParser;
        }

        /// <summary>
        /// Proof of concept method to track outgoing call statistics
        /// Could log to APM, SEQ or similar
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">Request to log</param>
        /// <param name="response">Response to log (if set)</param>
        /// <param name="command">Command to log</param>
        /// <param name="status">Status of the command</param>
        /// <param name="executionTime">How long the command took</param>
        public void LogOutGoingCall<K, T>(K request, T response, string command, ResponseStatus status, TimeSpan? executionTime)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Outgoing call log:");
            builder.AppendLine($"Command: {command}");
            builder.AppendLine($"Status: {status}");
            builder.AppendLine($"Execution time: {executionTime}");
            builder.AppendLine($"Request:\r\n {request}");
            builder.AppendLine($"Response:\r\n {response}");
            builder.AppendLine();
            _logger.LogInformation(builder.ToString());
        }
    }
}
