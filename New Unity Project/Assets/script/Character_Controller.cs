using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    GameObject Text_Timer;
    public GameObject Particle_speed;
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
    int Wild_toki_Count;

    float Speed = 0;
    public float Score = 0;
    public int Count = 0;
    public int Lost_Count = 0;
    public int Life = 0;
    public Text Text_number_Aicon = null;

    bool Flag_Gold_toki = false;
    float Gold_point = 0;
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
        Wild_toki_Count = 0;

        Speed = 1.5f;
        Score = 0;
        Count = 0;
        Lost_Count = 5;
        Life = 3;
        Text_number_Aicon.text = "0";
        collision_Save = GameObject.FindGameObjectWithTag("A0");

        Flag_Gold_toki = false;
        Gold_point = 1;
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
            Particle_speed.transform.position = new Vector3(0, 3, 30);
            Time.Timer_plus();
            Score += 100 * Gold_point;
            Destroy(collision_object);
        }
        if (collision.gameObject.tag == "tatemono")
        {
            if (Life == 3)
            {
                Heart3.SetActive(false);
                //FadeManager.Instance.LoadScene("Main", 1.0f);
            }
            else if (Life == 2)
            {
                Heart2.SetActive(false);
                //FadeManager.Instance.LoadScene("Main", 1.0f);
            }
            else
            {
                Heart1.SetActive(false);
                End_Life();
            }
            if (Wild_toki_Count >= 1)
            {
                Wild_toki_Count--;
                Gold_point = Gold_point - 0.5f;
            }
            collision_object = collision.gameObject;
            collision_object.SetActive(false);
            Life--;
            this.transform.position = collision_Save.transform.position;
        }
        if (collision.gameObject.tag == "WildToki")
        {
            collision_object = collision.gameObject;
            Score += 500 * Gold_point;
            Gold_point = Gold_point + 0.5f;
            Wild_toki_Count++;
        }
        if (collision.gameObject.tag == "aicon")
        {
            if (collision.gameObject.name == "kinnzann")
            {
                Gold_point = 0.5f;
            }
            if (collision.gameObject.name == "kamoko")
            {
                switch (Life)
                {
                    case 1:
                        Life++;
                        Heart3.SetActive(true);
                        break;
                    case 2:
                        Life++;
                        Heart3.SetActive(true);
                        break;
                    case 3:
                        Score += 200 * Gold_point;
                        break;
                    default:
                        Score += 100;
                        break;
                }
            }
            if (collision.gameObject.name == "hasi")
            {
                switch (Life)
                {
                    case 1:
                        Life++;
                        Heart3.SetActive(true);
                        break;
                    case 2:
                        Life++;
                        Heart3.SetActive(true);
                        break;
                    case 3:
                        Score += 200 * Gold_point;
                        break;
                    default:
                        Score += 100;
                        break;
                }
            }
            Score += 1000 * Gold_point;
            Count++;
            Lost_Count--;
            if (Count == 5)
            {
                Fainal_aicon.SetActive(true);
            }
            Destroy(collision.gameObject);
        }

        {
            //if (collision.gameObject.tag == "kinnzann_point")
            //{
            //    Gold_point = 1.5f;
            //}
            //if (collision.gameObject.tag == "kamoko_Life")
            //{
            //    switch (Life)
            //    {
            //        case 1:
            //            Life++;
            //            Heart3.SetActive(true);
            //            break;
            //        case 2:
            //            Life++;
            //            Heart3.SetActive(true);
            //            break;
            //        case 3:
            //            Score += 200 * Gold_point;
            //            break;
            //        default:
            //            Score += 100;
            //            break;
            //    }
            //}
            //if (collision.gameObject.tag == "hasi_Life")
            //{
            //    switch (Life)
            //    {
            //        case 1:
            //            Life++;
            //            Heart3.SetActive(true);
            //            break;
            //        case 2:
            //            Life++;
            //            Heart3.SetActive(true);
            //            break;
            //        case 3:
            //            Score += 200 * Gold_point;
            //            break;
            //        default:
            //            Score += 100;
            //            break;
            //    }
            //}
        }

        if (collision.gameObject.tag == "End_aicon")
        {
            //スコア処理を追加
            Score += 1000 * Gold_point;
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
//private ParticleSystem ps;
//public float hSliderValue = 5.0f;

//void Start()
//{
//    ps = GetComponent<ParticleSystem>();
//}

//void Update()
//{
//    var emission = ps.emission;
//    emission.rateOverTime = hSliderValue;
//}

//void OnGUI()
//{
//    hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 5.0f, 200.0f);
//}