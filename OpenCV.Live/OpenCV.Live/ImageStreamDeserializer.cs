namespace OpenCV.Live
{
    using Confluent.Kafka.Serialization;

    public class ImageStreamDeserializer : IDeserializer<byte[]>
    {
        public byte[] Deserialize(byte[] data)
        {
            return data;
        }
    }
}
