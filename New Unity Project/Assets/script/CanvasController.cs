using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasController : MonoBehaviour
{
    GameObject Text_Timer;
    GameObject Character;

    TimeController Time;
    Character_Controller Chara;

    public Text Text_Time = null;
    public Text Text_Score = null;
    public Text Text_Life = null;

    void Start()
    {
        Text_Timer = GameObject.Find("Text_Timer"); 
        Time = Text_Timer.GetComponent<TimeController>();
        Character = GameObject.Find("Character");
        Chara = Character.GetComponent<Character_Controller>();
        Text_Time.text = "時間 :" + Time.totalTime.ToString("f1");
        Text_Score.text = "スコア :" + Chara.Score;
        Text_Life.text = "Life :" + Chara.Life;
    }
    
    void Update()
    {
        Text_Time.text = "時間 :" + Time.totalTime.ToString("f1");
        Text_Score.text = "スコア :" + Chara.Score;
        Text_Life.text = "Life :" + Chara.Life;
    }
}
