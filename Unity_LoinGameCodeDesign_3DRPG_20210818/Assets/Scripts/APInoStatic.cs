using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�{��API:�D�R�A Non Static
public class APInoStatic : MonoBehaviour
{
    public Transform tra1;
    public Camera cam;
    public Light lig;

    private void Start()
    {
        #region �D�R�A�ݩ�
        //�P�R�A�t��
        //1.�ݭn���骫��
        //2.���o���骫�� - �w�q���ñN�n�s��������s�J���
        //3. �C������.���󥲶��s�b������
        //���o Get
        //�y�k:���W��.�D�R�A�ݩ�
        Debug.Log("��v�����y��" + tra1.position);
        Debug.Log("��v�����`��" + cam.depth);

        tra1.position = new Vector3(99, 99, 99);
        cam.depth = 7;
        #endregion

        #region �D�R�A��k
        //�I�s
        //�y�k:
        //���W��.�D�R�A��k�W��(�����޼�)
        lig.Reset();
        #endregion
    }

}
