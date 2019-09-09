using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_canvasController : MonoBehaviour
{
    public static float End_Score = 0;
    public static float End_Time = 0;
    public static float End_Life = 0;
    public static float End_Time_Score = 0;
    public static float End_Life_Score = 0;

    public Text Text_Score = null;
    public Text Text_All_Score = null;
    public Text Text_Time = null;
    public Text Text_Life = null;

    IEnumerator Stop_time()
    {
        //Text_Score.text = "Score : " + End_Score.ToString();
        End_Time_Score = End_Score + End_Time;
        End_Life_Score = End_Score + (End_Life * 200);
        Text_All_Score.text = " ";
        Text_Score.text = "Score : " + End_Score.ToString() + " ポイント";
        yield return new WaitForSeconds(1f);
        Text_Life.text = "Life : " + End_Life.ToString() + " × 200 ";
        yield return new WaitForSeconds(1f);
        Text_Life.text = "Life : " + End_Life_Score.ToString() + " ポイント";
        yield return new WaitForSeconds(1f);
        Text_Time.text = "Time : " + End_Time.ToString("f0") + " × 1 ";
        yield return new WaitForSeconds(1f);
        Text_Time.text = "Time : " + End_Time.ToString("f0") + " ポイント";
        //Text_Score.text = "Score " + End_Score.ToString("f0") + "点 + Time " + End_Time.ToString("f0") + "秒 = " + End_Time_Score.ToString("f0");
        //End_Score = End_Time_Score;
        yield return new WaitForSeconds(1f);
        //Text_Score.text = "Score " + End_Score.ToString("f0") + "点 + Life " + End_Life.ToString() + "×100 = " + End_Life_Score.ToString("f0");
        End_Score = End_Life_Score;
        //yield return new WaitForSeconds(2f);
        Text_All_Score.text = "Score : " + End_Score.ToString("f0") + " ポイント";
        //Text_Time.text = " ";
        //Text_Life.text = " ";
    }

    void Start()
    {
        Text_Score.text = "　";
        Text_Life.text = "　";
        Text_Time.text = "　";
        Text_All_Score.text = "　";
        StartCoroutine("Stop_time");
    }
}
