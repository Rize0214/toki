using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    void Start()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 1;
        gameObject.GetComponent<Renderer>().material.color = color;
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Interval")
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color.a = 0.3f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
        else
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;
            color.a = 1;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
