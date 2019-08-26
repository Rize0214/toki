using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//カメラの親オブジェクトなどにアタッチ

public class CameraAngle : MonoBehaviour
{
    Vector3 cameraAngle;　//カメラの角度を代入する変数
    public new GameObject camera; //カメラオブジェクトを格納


    //オブジェクトを動かすために必要
    public float thrust;　//勢いの強さ
    Rigidbody rb;        //リジットボディー
    public float moveForceMultiplier;    // 移動速度の入力に対する追従度

    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); //リジッドボディー参照
        thrust = 10f;　　　　　　　　　　　　　　//勢いの初期化
        moveForceMultiplier = 1;
    }

    void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;    // 移動速度の入力

        //カメラの方向を取得
        cameraAngle = camera.transform.rotation * Vector3.forward;

        //アタッチしているオブジェクトをカメラの向きに向けてthrustだけの力をかける
        rb.AddForce(cameraAngle * thrust);

        rb.AddForce(moveForceMultiplier * (cameraAngle * thrust - rb.velocity));
    }
}

