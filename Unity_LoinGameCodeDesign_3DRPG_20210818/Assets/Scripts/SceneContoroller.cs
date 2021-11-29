using UnityEngine;
using UnityEngine.SceneManagement;

namespace WEI
{
    /// <summary>
    /// ��������
    /// ���w�e�����ӳ���
    /// ���}��ӹC��
    /// </summary>
    public class SceneContoroller : MonoBehaviour
    {
        /// <summary>
        /// ���J���w����
        /// </summary>
        /// <param name="nameScene">�����W��</param>
        public void LoadScene(string nameScene)
        {
            SceneManager.LoadScene(nameScene);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
