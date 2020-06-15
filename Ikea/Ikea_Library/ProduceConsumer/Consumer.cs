using HalconDotNet;
using Ikea_Library.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ikea_Library.ProduceConsumer
{
    public class Consumer
    {
        private string _name { get; set; }
        private string _camName { get; set; }

        public event EventHandler<TileImageReadyEventArgs> TileImageReady;

        private bool Run;
        private Thread ConsumerThread;
        private HSmartWindowControl _hWindow;
        private BlockingCollection<Message> Messages = new BlockingCollection<Message>(10);
        private Message Message;
        HObject ImagesBuffer = new HObject();

        public Consumer(string name, string camName, HSmartWindowControl hWindow)
        {
            _name = name;
            _camName = camName;
            _hWindow = hWindow;
        }

        public void Enqueue(Message message)
        {
            Messages.Add(message);
            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{Messages.Count} image(s) in collection", "|OK|");
        }

        private void MainFunction()
        {
            ImagesBuffer.GenEmptyObj();
            Message = new Message();

            while (Run == true)
            {

                if (ImagesBuffer.CountObj() == 100)
                {
                    HOperatorSet.TileImages(ImagesBuffer, out HObject BigImage, 1, "vertical");
                    

                    TileImageReady?.Invoke(this,new TileImageReadyEventArgs(_camName,BigImage));
                    BigImage = null;

                    ImagesBuffer.GenEmptyObj();
                }

                else
                {
                    Message = Messages.Take();
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Took 1 image from collection, {Messages.Count} images left", "|OK|");
                    HOperatorSet.ConcatObj(Message.Image, ImagesBuffer, out ImagesBuffer);
                }
            }
        }

        public void Start()
        {
            Run = true;

            ConsumerThread = new Thread(MainFunction)
            {
                Name = $"ConsumerThread {_camName}",
                IsBackground = true,
                Priority = ThreadPriority.Normal
            };

            ConsumerThread.Start();
        }
        public void AbortThread()
        {
            Run = false;
            ConsumerThread.Join(5000);
            ConsumerThread.Abort();
            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Aborted Thread {ConsumerThread.Name}", "|OK|");

        }
        
    }

}
