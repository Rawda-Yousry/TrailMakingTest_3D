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
        Debug.Log("udpreceive......................");
        
        // Register a method to be called when a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Start the receiving thread
        StartReceiving();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the name of the loaded scene
        // if (scene.name == "Main Menu")  // Replace with the actual name of your first scene
        // {
        //     // Stop receiving in the first scene
        //     StopReceiving();
        // }
        // else if (scene.name == "SampleScene")  // Replace with the actual name of your second scene
        // {
            // Stop and wait before starting receiving in the second scene
            StartCoroutine(StopAndStartReceiving(2f)); // Replace 2f with the desired delay in seconds
            Debug.Log("Scene 222222");
        // }
    }

    IEnumerator StopAndStartReceiving(float delay)
    {
        StopReceiving();
        Debug.Log("Stopped receiving. Waiting for " + delay + " seconds...");

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Start receiving in the second scene
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

    // Start receiving thread
    void StartReceiving()
    {
        // Make sure to stop the existing thread before starting a new one
        StopReceiving();

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // Stop receiving thread
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

    // Ensure that resources are cleaned up when the script is destroyed
    void OnDestroy()
    {
        StopReceiving();
    }
}
