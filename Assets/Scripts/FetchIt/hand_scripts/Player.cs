using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length-1, 1);
        string[] points = data.Split(",");

        float x = float.Parse(points[0]);
        float y = float.Parse(points[1]);

        x = 30*x/640 - 16;
        y = 15*y/480 - 4;

        Debug.Log(x);
        Debug.Log(y);
        handPoints[0].transform.localPosition = new Vector3(x, y);

    }
}