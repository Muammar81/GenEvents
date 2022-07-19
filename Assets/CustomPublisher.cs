using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPublisher : MonoBehaviour
{
    //private BaseGameEvent<float> customEvent = new BaseGameEvent<float>();
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float rand = Random.Range(0, 99);
            print($"sending{rand}");
            //customEvent?.Raise(rand);
        }
    }
}