using UnityEngine;

namespace WEI.Dialogue
{
    /// <summary>
    /// �{�Ѱj��
    /// while. do while. for. foreach
    /// </summary>
    public class LearnLoop : MonoBehaviour
    {
        private void Start()
        {
            //�j�� Loop
            //���ư���{�����e
            //�ݨD:��X�Ʀr 1 - 5 
            /*print(1);
            print(2);
            print(3);
            print(4);
            print(5);
            */

            //while �j��
            //�y�k�Gif (���L��) {�{�����e} - ���L�Ȭ� true ����@��
            //�y�k�Gwhile (���L��) {�{�����e} - ���L�Ȭ� true �������

            int a = 1;

            while (a < 6)
            {
                print("�j�� while�G" + a);
                    a++;
            }

            for (int b =0; b < 6; b++)
            {
                print("�j�� for"+ b);
            }
        }
    }






}
