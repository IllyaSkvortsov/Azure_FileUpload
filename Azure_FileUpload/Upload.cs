using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure;
using Microsoft.ServiceBus.Messaging;

namespace Azure_FileUpload
{
    class Upload
    {

        public static void ToBlob()
        {
            string conn = "(connection string)";

            CloudStorageAccount acc = CloudStorageAccount.Parse(conn);
            CloudBlobClient blobClient = acc.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("container");
            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("UID_Email");
            using (var filestream = System.IO.File.OpenRead(
                @"C:\Users\Illya SKvortsov\source\repos\Azure_FileUpload\Azure_FileUpload\resources\UID_Email.csv"))
            {
                blockBlob.UploadFromStream(filestream);
            }
            Console.WriteLine("Done");
        }

        public static void ToQueue()
        {
            string conn = "(connection string)";
            string queue = "queue";

            var myClient = QueueClient.CreateFromConnectionString(conn, queue);
            var message = new BrokeredMessage("Arbitrary message");
            myClient.Send(message);
            Console.WriteLine("Done");

        }

        public static void ToSQL()
        {

        }

    }
}
