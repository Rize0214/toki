using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildTokiController : MonoBehaviour
{
    //Vector3.Lerp(始まりの位置, 終わりの位置, 現在の位置)

    bool Flag_toki = false;

    Vector3 cameraAngle; //カメラの角度を代入する変数
    public new GameObject camera; //カメラオブジェクトを格納

    //スタートと終わりの目印
    public Transform startMarker;
    public Transform endMarker;

    // スピード
    public float speed = 1.0f;

    //二点間の距離を入れる
    private float distance_two;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Flag_toki = true;
            //カメラの方向を取得
            cameraAngle = camera.transform.rotation * Vector3.forward;
            transform.rotation = camera.transform.rotation; //これが正しい(トキの向きを変更)
        }
    }
    void Start()
    {
        Flag_toki = false;
        //二点間の距離を代入(スピード調整に使う)
        distance_two = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        if (Flag_toki == true)
        {
            // 現在の位置
            float present_Location = (Time.time * speed) / distance_two;

            // オブジェクトの移動(ここだけ変わった！)
            transform.position = Vector3.Slerp(startMarker.position, endMarker.position, present_Location);

            cameraAngle = camera.transform.rotation * Vector3.forward;
            transform.rotation = camera.transform.rotation; //これが正しい(トキの向きを変更)
        }
    }
}
    