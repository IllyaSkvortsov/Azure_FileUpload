using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure_FileUpload
{
    class Download
    {

        public static void DownloadFileFromBlob()
        {
            string conn = "DefaultEndpointsProtocol=https;AccountName=fileuploadblobstorage;" +
                "AccountKey=aLlBt7ryXfuMAWjfE9iOU7hQztRV6lnwYyq35CNvXjHIvI9KfZm/8E9yMWVZSyE1/" +
                "1sdwCtTTXG8jBaKt7aDTQ==;EndpointSuffix=core.windows.net";

            CloudStorageAccount acc = CloudStorageAccount.Parse(conn);

            CloudBlobClient blobClient = acc.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("container");
            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("DemoBlob1");

            using (var filestream = System.IO.File.OpenWrite(@"C:\Users\Illya SKvortsov\source\repos\Azure_FileUpload\Azure_FileUpload\resources\downloadTest"))
            {
                blockBlob.DownloadToStream(filestream);
            }
            Console.WriteLine("Done");

        }

    }
}
