using Microsoft.Azure.Devices.Client;
//using Serilog;
using System;
using System.Windows;

namespace IoT.Device.Wpf
{
    /// <summary>
    ///     An exponential backoff without jitter to implement the same logic as IOTHUB_CLIENT_RETRY_EXPONENTIAL_BACKOFF
    ///     policy has in Azure IoT Device Client C SDK
    /// </summary>
    /// <remarks>
    ///     The first re-connection attempt happens immediately, then again in 1 second, then again 2 seconds,
    ///     4 seconds, 8 seconds, 16, 32, 64, ... until it succeeds.
    /// </remarks>
    public class CustomIotHubClientExponentialBackoffRetryPolicy : IotHubClientRetryPolicyBase
    {
        private const uint InfiniteRetries = 0;
        //private readonly ILogger _logger;

        public CustomIotHubClientExponentialBackoffRetryPolicy(/*ILogger logger*/)
            : base(InfiniteRetries)
        {
            //_logger = logger;
        }

        /// <inheritdoc />
        public override bool ShouldRetry(uint currentRetryCount, Exception lastException, out TimeSpan retryDelay)
        {
            if (!base.ShouldRetry(currentRetryCount, lastException, out retryDelay))
            {
                return false;
            }

            // currentRetryCount == 0 for the first attempt to retry
            retryDelay = currentRetryCount == 0
                ? TimeSpan.Zero
                : TimeSpan.FromSeconds(Math.Pow(2.0, currentRetryCount - 1));

            MessageBox.Show("retry");

            //_logger.Error(
            //    lastException,
            //    "Retry performed. Current attempt: {Attempt}, "
            //    + "delay before the next retry: {RetryDelay}.",
            //    currentRetryCount + 1,
            //    retryDelay);

            return true;
        }
    }
}
