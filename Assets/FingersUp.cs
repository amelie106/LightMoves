using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Linq;

public class FingersUp : MonoBehaviour
{
    public UDPReceive udpReceive;
    public int[] fingers;
    public int total;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        
        try {
            // Convert string to integers
            data = data.Remove(0, 1);
            data = data.Remove(data.Length-1, 1);
            fingers = Array.ConvertAll(data.Split(","), s => int.Parse(s));

            // Count the number of fingers raised
            total = fingers.Sum();
        }
        catch (Exception) {
            total = 0;
        }


    }

    public int getTotal()
    {
        return total;
    }
}