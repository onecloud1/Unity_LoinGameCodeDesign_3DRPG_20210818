using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�{��API�R�A
public class APIStatic : MonoBehaviour
{
    private void Start()
    {
        #region �R�A�ݩ�
        //���o get
        //�y�k:
        //���O�W��.�R�A�ݩ�
        float r = Random.value;
        print("���o�R�A�ݩ�.�H����:" + r);

        //�]�w Set
        //�y�k:
        //���O�W��.�R�A�ݩ� ���w ��;
        //�u�n�ݨ� Read Onliy �N����]�w
        //Cursor.visible = false;
        #endregion


        #region �R�A��k
        //�I�s.�Ѽ�.�Ǧ^
        //ñ��:�Ѽ�.�Ǧ^
        //�y�k:
        //���O�W��.�R�A��k(�����޼�)
        float range = Random.Range(10.5f, 20.9f);
        print("�H���d�� 10.5 ~ 20.9" + range);

        //�ϥξ�Ʈɤ��]�t�̤j��
        float rangeInt = Random.Range(1, 3);
        print("�H���d�� 1 ~ 3" + rangeInt);
        #endregion

    }

    private void Update()
    {
        #region �R�A�ݩ�
        //print("�g�L�h�[" + Time.timeSinceLevelLoad);
        #endregion

        #region �R�A��k
        float h = Input.GetAxis("Horizontal");
        print("������" + h);
    #endregion

    }

}