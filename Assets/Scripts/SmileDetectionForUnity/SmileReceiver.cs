using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class SmileReceiver : MonoBehaviour
{
    Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;

    JumpManager jumpManager;
    PlayerMovement playerMovement;

    bool running;
    public bool smileReceived;
    string sceneName;

    private void Start()
    {
        jumpManager = GameObject.Find("JumpManager").GetComponent<JumpManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        if (SceneManager.GetActiveScene().name == "DiscreteSmile")
        {
            sceneName = "discreteSmile";
        }
        else if (SceneManager.GetActiveScene().name == "ContinuousSmile")
        {
            sceneName = "continuousSmile";
        }

        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
    }

    void GetInfo()
    {
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        client = listener.AcceptTcpClient();

        running = true;
        while (running)
        {
            if (sceneName == "discreteSmile")
            {
                SendAndReceiveDataDiscrete();
            }
            else
            {
                SendAndReceiveDataContinuous();
            }
        }
        listener.Stop();
    }

    void SendAndReceiveDataDiscrete()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //---receiving Data from the Host----
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Getting data in Bytes from Python
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Converting byte data to string, because int Values cannot be null

        if (dataReceived != null)
        {
            jumpManager.RequestJump(27.5F);
            Debug.Log("Recieved Data from SmileDetection");

            //---Sending Data to Host----
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Recieved and sent data"); //Converting string to byte data
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
        }

    }

    void SendAndReceiveDataContinuous()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //---receiving Data from the Host----
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Getting data in Bytes from Python
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Converting byte data to string, because int Values cannot be 

        if (dataReceived != null)

        {
            smileReceived = true;
            Debug.Log("Recieved Data from SmileDetection");

            byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Recieved and sent data"); //Converting string to byte data
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
        }
    }
}