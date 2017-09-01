using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace OpenCV.Live
{
    using Confluent.Kafka;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var config = new Dictionary<string, object>
            {
                { "group.id", "live-no99-group" },
                { "bootstrap.servers", "localhost:9092" }
            };
            Task.Factory.StartNew(() =>
            {
                using (var consumer = new Consumer<Null, byte[]>(config, null, new ImageStreamDeserializer()))
                {
                    consumer.Assign(new List<TopicPartitionOffset> { new TopicPartitionOffset("live-no99", 0, Offset.End) });
                    
                    while (true)
                    {
                        Message<Null, byte[]> msg;
                        if (consumer.Consume(out msg, TimeSpan.FromSeconds(1)))
                        {
                            using (var stream = new MemoryStream(msg.Value))
                            {
                                this.Dispatcher.Invoke(() =>
                                {
                                    videoLiveView.Source = BitmapFrame.Create(stream,
                                                                      BitmapCreateOptions.None,
                                                                      BitmapCacheOption.OnLoad);
                                });
                            }
                        }
                    }
                }
            });
        }
       
    }
}
