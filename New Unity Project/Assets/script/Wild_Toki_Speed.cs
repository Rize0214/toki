using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wild_Toki_Speed : MonoBehaviour
{
    
    //Vector3.Lerp(始まりの位置, 終わりの位置, 現在の位置)
    Animator _anim;

    Vector3 cameraAngle; //カメラの角度を代入する変数

    //スタートと終わりの目印
    public Transform startMarker;
    public Transform endMarker;

    // スピード
    public float speed = 1f;

    //二点間の距離を入れる
    private float distance_two;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "A1")
        {
            //startMarker = collision.gameObject.transform;
            endMarker = GameObject.FindGameObjectWithTag("A3").transform;
        }
        if (collision.gameObject.tag == "A2")
        {
            //startMarker = collision.gameObject.transform;
            endMarker = GameObject.FindGameObjectWithTag("A1").transform;
        }
        if (collision.gameObject.tag == "A3")
        {
            //startMarker = collision.gameObject.transform;
            endMarker = GameObject.FindGameObjectWithTag("A4").transform;
        }
        if (collision.gameObject.tag == "A4")
        {
            //startMarker = collision.gameObject.transform;
            endMarker = GameObject.FindGameObjectWithTag("A2").transform;
        }
    }
    void Start()
    {
        this._anim = GetComponent<Animator>();
        //二点間の距離を代入(スピード調整に使う)
        distance_two = Vector3.Distance(startMarker.position, endMarker.position);
        startMarker = GameObject.FindGameObjectWithTag("A0").transform;
        endMarker = GameObject.FindGameObjectWithTag("A2").transform;
    }

    void Update()
    {
        // 現在の位置
        float present_Location = (Time.time * speed) / distance_two;
        // オブジェクトの移動(ここだけ変わった！)
        transform.position = Vector3.Slerp(startMarker.position, endMarker.position, present_Location);
        //cameraAngle = endMarker.transform.rotation * Vector3.forward;
        //transform.rotation = endMarker.transform.rotation; //これが正しい(トキの向きを変更)
    }
}
