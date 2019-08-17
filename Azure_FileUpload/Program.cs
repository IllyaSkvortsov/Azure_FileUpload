using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_FileUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Process and Parse a .csv file to the database(1)\nDownload the file from the blob(2)\nUpload it to the blob storage(3)\nUpload send it to the queue(4)\nExit(5)");
            int caseSwitch;
            bool exit = false;

            do
            {
                caseSwitch = Int32.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        ProcessSQLInput.ParseFiles();
                        break;
                    case 2:
                        Download.DownloadFileFromBlob();
                        break;
                    case 3:
                        Upload.ToBlob();
                        break;
                    case 4:
                        Upload.ToQueue();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        break;
                }
            } while (exit == false);

            

            
            
        }
    }
}
