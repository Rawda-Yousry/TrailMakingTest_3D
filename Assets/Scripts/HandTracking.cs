using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpRecieve;
    public GameObject[] handPoints;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string data = udpRecieve.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        // print(data);
        string[] points = data.Split(',');
        // print(points[0]);

        for (int i = 0; i < 21; i++)
        {
            float x = 7- float.Parse(points[3 * i]) / 100;
            float y = float.Parse(points[3 * i + 1]) / 100;
            float z = float.Parse(points[3 * i + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }


}