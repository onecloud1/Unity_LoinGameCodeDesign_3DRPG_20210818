using System.Collections; // �ޥ� �t��.���X �ޥδN�i�� ��P�{�� API
using UnityEngine;

namespace WEI.Practice
{

    public class LearnCoroutine : MonoBehaviour
    {
        //�w�q��P�{�Ǥ�k
        //IEnumerator ����P�{�� �Ǧ^��,�i�Ǧ^�ɶ�

        private IEnumerator TestCoroutine()
        {
            print("��P");
            yield return new WaitForSeconds(2);
            print("��P���ݨ������");
        }

        public Transform sphere;
        private IEnumerator SpherScale()
        {
            for (int i = 0; i < 10; i++)
            {
                sphere.localScale += Vector3.one;
                yield return new WaitForSeconds(1);            
            }
        }

        private void Start()
        {   //�����ϥγo�˱Ұʨ�P�{�� �~�|���ĪG
            StartCoroutine(TestCoroutine());
            StartCoroutine(SpherScale());
        }

    }
}