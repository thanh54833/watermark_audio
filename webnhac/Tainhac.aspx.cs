using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SteganoWave;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Download;
using Google.Apis.Util.Store;
using GoogleDriveRestAPI_v3.Models;
using System.Data.SqlClient;
using System.Configuration;

public partial class Trangtainhac : System.Web.UI.Page
{
    XuLiDB db = new XuLiDB();
    
    string fullPath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/"));
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = db.Laydsbh();
        GridView1.DataBind();
    }
    private static byte GetKeyValue(Stream keyStream)
    {
        int keyValue;
        if ((keyValue = keyStream.ReadByte()) < 0)
        {
            keyStream.Seek(0, SeekOrigin.Begin);
            keyValue = keyStream.ReadByte();
            if (keyValue == 0) { keyValue = 1; }
        }
        return (byte)keyValue;
    }
    private Stream GetMessageStream()
    {
        BinaryWriter messageWriter = new BinaryWriter(new MemoryStream());


        messageWriter.Write(txtMessage.Text.Length);
        messageWriter.Write(Encoding.ASCII.GetBytes(txtMessage.Text));

        messageWriter.Seek(0, SeekOrigin.Begin);
        return messageWriter.BaseStream;
    }
    public void SaveStreamToFile(string fileFullPath, MemoryStream stream)
    {
        if (stream.Length == 0) return;
        if (System.IO.File.Exists(fileFullPath))
            System.IO.File.Delete(fileFullPath);

        using (System.IO.FileStream file = new FileStream(fileFullPath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        
    }
    
   

  
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        GoogleDriveFilesRepository grsp = new GoogleDriveFilesRepository();
        DriveService driveService = grsp.GetService();
        var fileId = db.GetIDdrive(TextBox1.Text);
        var request = driveService.Files.Get(fileId);
        var stream = new System.IO.MemoryStream();
        Label1.Text = fileId;

        // Add a handler which will be notified on progress changes.
        // It will notify on each chunk download and when the
        // download is completed or failed.
        request.MediaDownloader.ProgressChanged +=
            (IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
        request.Download(stream);
        SaveStreamToFile(fullPath + "temp.wav",stream);
        

        {


            Stream sourceStream = null;
            FileStream destinationStream = null;
            WaveStream audioStream = null;

            //create a stream that contains the message, preceeded by its length
            Stream messageStream = GetMessageStream();
            //open the key file
            Stream keyStream = new FileStream(fullPath + "hash.txt", FileMode.Open);

            try
            {

                //how man samples do we need?
                long countSamplesRequired = WaveUtility.CheckKeyForMessage(keyStream, messageStream.Length);

                if (countSamplesRequired > Int32.MaxValue)
                {
                    throw new Exception("Message too long, or bad key! This message/key combination requires " + countSamplesRequired + " samples, only " + Int32.MaxValue + " samples are allowed.");
                }

                sourceStream = new FileStream(fullPath+"temp.wav",FileMode.Open);

                //create an empty file for the carrier wave
                destinationStream = new FileStream(fullPath + "temp2.wav", FileMode.Create);

                //copy the carrier file's header
                audioStream = new WaveStream(sourceStream, destinationStream);
                int a = audioStream.Format.wBitsPerSample;
                if (audioStream.Length <= 0)
                {
                    throw new Exception("Invalid WAV file");
                }

                //are there enough samples in the carrier wave?
                if (countSamplesRequired > audioStream.CountSamples)
                {
                    String errorReport = "The carrier file is too small for this message and key!\r\n"
                        + "Samples available: " + audioStream.CountSamples + "\r\n"
                        + "Samples needed: " + countSamplesRequired;
                    throw new Exception(errorReport);
                }

                //hide the message
                WaveUtility utility = new WaveUtility(audioStream, destinationStream);
                
                utility.Hide(messageStream, keyStream);
            }


            catch (Exception ex)
            {

            }
            finally
            {
                if (keyStream != null) { keyStream.Close(); }
                if (messageStream != null) { messageStream.Close(); }
                if (audioStream != null) { audioStream.Close(); }
                if (sourceStream != null) { sourceStream.Close(); }
                if (destinationStream != null) { destinationStream.Close(); }
            }


        } 
       
        // It's a file name displayed on downloaded file on client side.
       string FileName = fullPath + "temp2.wav";
       System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
       response.ClearContent();
       response.Clear();
       response.ContentType = "audio/mpeg";
       response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
       response.TransmitFile(FileName);
       response.Flush();
       response.End(); 





    }
}