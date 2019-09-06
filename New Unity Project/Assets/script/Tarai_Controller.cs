using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarai_Controller : MonoBehaviour
{
    float X_speed = 0.5f;
    float Y_speed = 0.5f;
    float Z_speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            X_speed = 100;
            Y_speed = 100;
            Z_speed = 100;
        }
    }
        // Update is called once per frame
        void Update()
    {
        transform.Translate(0, Y_speed * Time.deltaTime, Z_speed * Time.deltaTime);
        transform.Rotate(0, Y_speed * Time.deltaTime, 0);
    }
}
