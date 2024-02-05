using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 5052;
    public bool printToConsole = false;
    public string data;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        StartReceiving();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(StopAndStartReceiving(2f));
    }

    IEnumerator StopAndStartReceiving(float delay)
    {
        StopReceiving();
        Debug.Log("Stopped receiving. Waiting for " + delay + " seconds...");
        yield return new WaitForSeconds(delay);
        StartReceiving();
        Debug.Log("Started receiving in the second scene.");
    }

    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);

                if (printToConsole) { print(data); }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    void StartReceiving()
    {
        StopReceiving();

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    void StopReceiving()
    {
        if (client != null)
        {
            client.Close();
            client = null;
        }

        if (receiveThread != null && receiveThread.IsAlive)
        {
            receiveThread.Abort();
        }
    }

    void OnDestroy()
    {
        StopReceiving();
    }
}
