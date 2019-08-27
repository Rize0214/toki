using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_aicon : MonoBehaviour
{
    public Text Text_Aicon = null;
    public GameObject collision_object;
    GameObject player = null;
    void Start()
    {
        Text_Aicon.text = "アイコンのある名所説明";
        player = null;
    }
    void A()
    {
        switch (collision_object.tag)
        {
            case "a":
                Text_Aicon.text = "アイコンのある名所説明";
                break;
            case "b":
                Text_Aicon.text = "アイコンのある名所説明";
                break;
            case "c":
                Text_Aicon.text = "アイコンのある名所説明";
                break;
            case "d":
                Text_Aicon.text = "アイコンのある名所説明";
                break;
            case "e":
                Text_Aicon.text = "アイコンのある名所説明";
                break;
            default:
                Text_Aicon.text = "アイコンのある名所説明";
                break;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        collision_object = collision.gameObject;
    }
    void OnTriggerExit(Collider collision)
    {
        collision_object = collision.gameObject;
    }
    
}
