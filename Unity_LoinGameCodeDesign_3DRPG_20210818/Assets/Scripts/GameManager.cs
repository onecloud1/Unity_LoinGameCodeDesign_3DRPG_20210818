using UnityEngine;
using UnityEngine.UI;

namespace WEI
{
    /// <summary>
    /// �C���޲z��
    /// �����B�z
    /// 1.���ȧ���
    /// 2.���a���`
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [Header("�s�ժ���")]
        public CanvasGroup groupFinal;
        [Header("�����e�����D")]
        public Text textTitle;

        private string titleWin = "You Win";
        private string titleLose = "You Failed";
    }
}
