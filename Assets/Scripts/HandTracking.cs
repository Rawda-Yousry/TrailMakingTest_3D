using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpRecieve;
    public GameObject[] handPoints;

    // void Awake()
    // {
    //     DontDestroyOnLoad(gameObject);
    // }

    void Start()
    {
        Debug.Log("handtracking..............");
    }

    void Update()
    {
        string data = udpRecieve.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(',');

        for (int i = 0; i < 21; i++)
        {
            float x = float.Parse(points[3 * i]) / 100 - 8;
            float y = float.Parse(points[3 * i + 1]) / 100 - 2.5f;
            float z = float.Parse(points[3 * i + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }


}
