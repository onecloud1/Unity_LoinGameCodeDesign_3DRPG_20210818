using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIStaticPractice : MonoBehaviour
{

    void Start()
    {
        Debug.Log("�`�@���X�[��v��" + Camera.allCamerasCount); //1
        Debug.Log("2D���O" + Physics2D.gravity); //0,-9.8
        Debug.Log("��P�v" + Mathf.PI); //3.14159

        Physics2D.gravity = new Vector2(0, -20); //�קﭫ�O
        Time.timeScale = 0.5f;

        Debug.Log("9.999�L����i�� = " + Mathf.Round(9.999f)); // 10

        Vector3 a = new Vector3(1, 1, 1);
        Vector3 b = new Vector3(22, 22, 22);
        Debug.Log("a b ���I�Z��" + Vector3.Distance(a,b));

        Application.OpenURL("https://unity.com/");
    }
    void Update()
    {
        Debug.Log("�O�_��J���N��" + Input.anyKey);
        Debug.Log("�ɶ��g�L" + Time.time);
        Debug.Log("�O�_���U�ť���" + Input.GetKeyDown(KeyCode.Space));
    }
}
