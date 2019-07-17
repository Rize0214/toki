using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    // メンバ変数
    public float totalTime = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        totalTime -= Time.deltaTime;
        if (totalTime <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }
    
    public void Timer_plus()
    {
        totalTime += 20;
    }
    public void Total_Timer()
    {
        End_canvasController.End_time = totalTime;
    }
}
