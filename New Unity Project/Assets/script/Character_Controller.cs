using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    GameObject Text_Timer;
    TimeController Time;

    public GameObject Fainal_aicon;

    float Speed = 0;
    public int Score = 0;
    public int Count = 0;
    bool Dont_use = false;
    // Start is called before the first frame update
    void Start()
    {
        Text_Timer = GameObject.Find("Text_Timer");
        Time = Text_Timer.GetComponent<TimeController>();

        //Fainal_aicon = transform.Find("Fainal_aicon").gameObject;
        Fainal_aicon.SetActive(false);

        Speed = 0.1f;
        Score = 0;
        Count = 0;
        Dont_use = true;
    }

    void Update()
    {
        transform.Translate(Speed, 0, 0);
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
        Speed = Speed -1;
        yield return new WaitForSeconds(0);
        Dont_use = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "ring")
        {
            Time.Timer_plus();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "aicon")
        {
            Score += 100;
            Count++;
            if (Count == 3)
            {
                Fainal_aicon.SetActive(true);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "End_aicon")
        {
            //スコア処理を追加
            Score += 100;
            End_canvasController.End_score = Score;
            Time.Total_Timer();
            StartCoroutine("Stop_time");
            SceneManager.LoadScene("End");
        }
    }
}
