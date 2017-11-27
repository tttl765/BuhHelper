using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
//using Consol = 

namespace BuhHelp
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://focus-api.kontur.ru/api3/req?key=3208d29d15c507395db770d0e65f3711e40374df&inn=6663003127";
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            System.IO.Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();

            Console.ReadKey();
        }
    }
}
