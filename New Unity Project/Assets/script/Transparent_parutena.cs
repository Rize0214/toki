using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparent_parutena : MonoBehaviour
{
    //public float alfa = 1f;
    float Speed = 0.70f;
    Color color;
    bool Toumei = false;
    bool Stop = false;

    void Start()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.r = 0.4f;
        color.g = 1f;
        color.b = 1f;
        color.a = 0.5f;
        gameObject.GetComponent<Renderer>().material.color = color;
        Toumei = false;
        Stop = false;
       // GetComponent<Image>().color = new Color(0f, 0f, 0f, alfa);
    }
    IEnumerator Parutena_Fade()
    {
        Stop = true;
        Toumei = true;
        Debug.Log("true");
        yield return new WaitForSeconds(1.5f);
        Toumei = false;
        Debug.Log("1,5秒");
        yield return new WaitForSeconds(1.5f);
        Stop = false;
        Toumei = true;
        Debug.Log("3秒");
    }

    void Update()
    {
        color.r = 0.4f;
        color.g = 1f;
        color.b = 1f;
        Debug.Log(color.a);
        if (Toumei == true)
        {
            if (Stop == false)
            {
                StartCoroutine("Parutena_Fade");
            }
            color.a += Speed * Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = color;
            //GetComponent<Image>().color = new Color(0f, 0f, 0f, alfa);
           // alfa -= Speed * Time.deltaTime;
        }
        else
        {
            if (Stop == false)
            {
                StartCoroutine("Parutena_Fade");
            }
            color.a -= Speed * Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = color;
            //GetComponent<Image>().color = new Color(0f, 0f, 0f, alfa);
            //alfa += Speed * Time.deltaTime;
        }

    }

}
