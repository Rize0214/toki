using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_aicon : MonoBehaviour
{
    public Text Text_Aicon = null;
    public GameObject collision_object;
    void Start()
    {
        Text_Aicon.text = " ";
    }
    void A()
    {
        switch (collision_object.tag)
        {
            case "tokimori":
                Text_Aicon.text = "アイコンのある名所説明 : (トキ森)";
                break;
            case "kamoko":
                Text_Aicon.text = "アイコンのある名所説明 : (加茂湖)";
                break;
            case "hasamiiwa":
                Text_Aicon.text = "アイコンのある名所説明 : (弁慶のはさみ岩)";
                break;
            case "tarai":
                Text_Aicon.text = "アイコンのある名所説明 : (たらい船)";
                break;
            case "hutatugame":
                Text_Aicon.text = "アイコンのある名所説明 : (二ツ亀海水浴場)";
                break;
            case "kinnzann":
                Text_Aicon.text = "アイコンのある名所説明 : (金銀山)";
                break;
            case "sadokisenn":
                Text_Aicon.text = "アイコンのある名所説明 : (佐渡汽船)";
                break;
            case "f":
                Text_Aicon.text = "アイコンのある名所説明 : (f)";
                break;
            default:
                Text_Aicon.text = " ";
                break;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        collision_object = collision.gameObject;
        A();
    }
    void OnTriggerExit(Collider collision)
    {
        Text_Aicon.text = " ";
    }

}
