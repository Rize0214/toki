using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    GameObject Text_Timer;
    TimeController Time;

    //Vector3 cameraAngle; //カメラの角度を代入する変数
    //public new GameObject camera; //カメラオブジェクトを格納

    public GameObject Fainal_aicon;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    //public GameObject Heart4;
    //public GameObject Heart5;
    public GameObject collision_object;
    public GameObject collision_Save;

    float Speed = 0;
    public int Score = 0;
    public int Count = 0;
    public int Lost_Count = 0;
    public int Life = 0;
    public Text Text_number_Aicon = null;

    //bool Flag_toki = false;
    // Start is called before the first frame update
    void Start()
    {
        Text_Timer = GameObject.Find("Text_Timer");
        Time = Text_Timer.GetComponent<TimeController>();

        Fainal_aicon.SetActive(false);
        Fainal_aicon.SetActive(false);
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
        //Heart4.SetActive(true);
        //Heart5.SetActive(true);

        Speed = 1.5f;
        Score = 0;
        Count = 0;
        Lost_Count = 8;
        Life = 3;
        Text_number_Aicon.text = "0";
        collision_Save = GameObject.FindGameObjectWithTag("A0");

        //Flag_toki = false;
    }

    void Update()
    {
        transform.Translate(0, 0, Speed);
        if (Lost_Count >= 1)
        {
            Text_number_Aicon.text = "残りのアイコンの数 ： " + Lost_Count.ToString();
        }
        else
        {
            Text_number_Aicon.text = "最後のアイコンをとれ！！";
        }
    }

    void End_Life()
    {
        Life--;
        Time.Total_Timer();
        End_canvasController.End_Score = Score;
        End_canvasController.End_Life = Life;
        SceneManager.LoadScene("End");
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ring")
        {
            collision_object = collision.gameObject;
            collision_object.GetComponent<ParticleSystem>().Play();
            Time.Timer_plus();
            StartCoroutine("Ring_Get");
        }
        if (collision.gameObject.tag == "tatemono")
        {
            if (Life == 3)
            {
                Heart3.SetActive(false);
                FadeManager.Instance.LoadScene("Main", 1.0f);
            }
            else if (Life == 2)
            {
                Heart2.SetActive(false);
                FadeManager.Instance.LoadScene("Main", 1.0f);
            }
            else
            {
                Heart1.SetActive(false);
                End_Life();
            }
            collision_object = collision.gameObject;
            //this.transform.position = new Vector3(0, 0, 0);
            collision_object.SetActive(false);
            Life--;
            this.transform.position = collision_Save.transform.position;
        }
        if (collision.gameObject.tag == "WildToki")
        {
            collision_object = collision.gameObject;
            Score += 100;
            //Flag_toki = false;
            ////カメラの方向を取得
            //cameraAngle = camera.transform.rotation * Vector3.forward;
            //collision_object.transform.rotation = camera.transform.rotation; //これが正しい(トキの向きを変更)

        }
        if (collision.gameObject.tag == "aicon")
        {
            Score += 100;
            Count++;
            Lost_Count--;
            if (Count == 8)
            {
                Fainal_aicon.SetActive(true);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "End_aicon")
        {
            //スコア処理を追加
            Score += 100;
            End_canvasController.End_Score = Score;
            End_canvasController.End_Life = Life;
            Time.Total_Timer();
            SceneManager.LoadScene("End");
        }
        if (collision.gameObject.tag == "A1")
        {
            collision_Save = collision.gameObject;
        }
        if (collision.gameObject.tag == "A2")
        {
            collision_Save = collision.gameObject;
        }
        if (collision.gameObject.tag == "A3")
        {
            collision_Save = collision.gameObject;
        }
        if (collision.gameObject.tag == "A4")
        {
            collision_Save = collision.gameObject;
        }
    }
}
