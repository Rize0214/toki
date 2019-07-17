using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_canvasController : MonoBehaviour
{
    public static float End_score = 0;
    public static float End_time = 0;
    public static float End_time_score = 0;

    public Text Text_Score = null;
    public Text Text_Time = null;

    IEnumerator Stop_time()
    {
        End_time_score = End_score + End_time;
        Text_Score.text = "Score : " + End_score.ToString();
        Text_Time.text = "Time : " + End_time.ToString("f0");
        yield return new WaitForSeconds(2f);
        Text_Score.text = "Score " + End_score.ToString("f0") + "点 + Time " + End_time.ToString("f0") + "秒 = " + End_time_score.ToString("f0");
        End_score = End_score + End_time;
        yield return new WaitForSeconds(2f);
        Text_Score.text = "Score : " + End_score.ToString("f0")+" ポイント";
        Text_Time.text = " ";
    }

    void Start()
    {
        StartCoroutine("Stop_time");
    }
}
