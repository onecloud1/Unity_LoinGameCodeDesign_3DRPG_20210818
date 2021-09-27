using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIStaticPractice : MonoBehaviour
{

    void Start()
    {
        Debug.Log("總共有幾架攝影機" + Camera.allCamerasCount); //1
        Debug.Log("2D重力" + Physics2D.gravity); //0,-9.8
        Debug.Log("圓周率" + Mathf.PI); //3.14159

        Physics2D.gravity = new Vector2(0, -20); //修改重力
        Time.timeScale = 0.5f;

        Debug.Log("9.999無條件進位 = " + Mathf.Round(9.999f)); // 10

        Vector3 a = new Vector3(1, 1, 1);
        Vector3 b = new Vector3(22, 22, 22);
        Debug.Log("a b 兩點距離" + Vector3.Distance(a,b));

        Application.OpenURL("https://unity.com/");
    }
    void Update()
    {
        Debug.Log("是否輸入任意鍵" + Input.anyKey);
        Debug.Log("時間經過" + Time.time);
        Debug.Log("是否按下空白鍵" + Input.GetKeyDown(KeyCode.Space));
    }
}
