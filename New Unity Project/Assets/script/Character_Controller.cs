using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    GameObject Text_Timer;
    TimeController Time;

    public GameObject Fainal_aicon;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;
    public GameObject collision_object;

    float Speed = 0;
    public int Score = 0;
    public int Count = 0;
    public int Life = 0;
    bool Dont_use = false;
    bool Invincible_Time = false;
    // Start is called before the first frame update
    void Start()
    {
        Text_Timer = GameObject.Find("Text_Timer");
        Time = Text_Timer.GetComponent<TimeController>();
        
        Fainal_aicon.SetActive(false);
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
        Heart4.SetActive(true);
        Heart5.SetActive(true);

        Speed = 0.5f;
        Score = 0;
        Count = 0;
        Life = 5;
        Dont_use = true;
        Invincible_Time = false;
    }

    void Update()
    {
        transform.Translate(0, 0, Speed);
        if (Input.GetKeyDown(KeyCode.Space) && Dont_use == true)
        {
            StartCoroutine("Speed_UP");
        }
    }

    IEnumerator Stop_time()
    {
        yield return new WaitForSeconds(0);
    }

    IEnumerator Speed_UP()
    {
        Dont_use = false;
        Speed = Speed + 1;
        yield return new WaitForSeconds(1);
        Speed = Speed - 1;
        yield return new WaitForSeconds(0);
        Dont_use = true;

    }

    IEnumerator Ring_Get()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(collision_object);
    }
    IEnumerator Speed_Down()
    {
        Speed = 0;
        yield return new WaitForSeconds(1);
        Invincible_Time = true;
        Speed = 0.5f;
        yield return new WaitForSeconds(2);
        Invincible_Time = false;
        collision_object.SetActive(true);
    }
    void Life_Down()
    {
        Life--;
        StartCoroutine("Speed_Down");
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
        if (collision.gameObject.tag == "tatemono" && Invincible_Time == false)
        {
            if (Life == 5)
            {
                Heart5.SetActive(false);
                FadeManager.Instance.LoadScene("Main", 1.0f);
            }
            else if (Life == 4)
            {
                Heart4.SetActive(false);
                FadeManager.Instance.LoadScene("Main", 1.0f);
            }
            else if (Life == 3)
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
            this.transform.position = new Vector3(0, 0, 0);
            collision_object.SetActive(false);
            Life_Down();
        }
        if (collision.gameObject.tag == "aicon")
        {
            Score += 100;
            Count++;
            if (Count == 9)
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
            StartCoroutine("Stop_time");
            SceneManager.LoadScene("End");
        }
    }
}
