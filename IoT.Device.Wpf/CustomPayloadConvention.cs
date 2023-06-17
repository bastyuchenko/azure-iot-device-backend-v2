using System;
using System.Text;
using Microsoft.Azure.Devices.Client;

namespace IoT.Device.Wpf
{
    public class CustomPayloadConvention : PayloadConvention
    {
        public static readonly CustomPayloadConvention Instance = new();

        /// <summary>
        ///     Used to specify what type of content will be in the payload.
        /// </summary>
        /// <value>A string representing the content type to use when sending a payload.</value>
        public override string ContentType => "application/protobuf";

        /// <summary>
        ///     The encoding used for the payload.
        /// </summary>
        public override string ContentEncoding => Encoding.UTF8.WebName;

        /// <summary>
        ///     Returns the byte array for the convention-based serialized/encoded message before send
        /// </summary>
        /// <returns>The correctly encoded object for this convention.</returns>
        public override byte[] GetObjectBytes(object objectToSendWithConvention)
        {
            //if (objectToSendWithConvention is ProtoBufSecureMessage ss)
            //{
            //    return ss.ToByteArray();
            //}

            throw new Exception(
                "It is not ProtoBufSecureMessage type message.");
        }

        /// <summary>
        ///     Returns the object as the specified type if TryGetPayload method is used.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="objectToConvert">The object to convert.</param>
        /// <returns>The converted object.</returns>
        public override T GetObject<T>(byte[] objectToConvert) => throw new NotImplementedException();
    }
}
