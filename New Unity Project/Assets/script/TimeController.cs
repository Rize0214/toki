using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    // メンバ変数
    public float totalTime = 0.0f;
    GameObject toki;
    Character_Controller Cyara;
    void Start()
    {
        toki = GameObject.Find("toki");
        Cyara = toki.GetComponent<Character_Controller>();
    }
    void FixedUpdate()
    {
        totalTime -= Time.deltaTime;
        if (totalTime <= 0)
        {
            End_canvasController.End_Score = Cyara.Score;
            End_canvasController.End_Life = Cyara.Life;
            SceneManager.LoadScene("End");
        }
    }
    
    public void Timer_plus()
    {
        totalTime += 20;
    }
    public void Total_Timer()
    {
        End_canvasController.End_Time = totalTime;
    }
}
