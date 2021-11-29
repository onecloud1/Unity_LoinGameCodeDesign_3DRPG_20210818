using UnityEngine;
using UnityEngine.SceneManagement;

namespace WEI
{
    /// <summary>
    /// 場景控制
    /// 指定前往哪個場景
    /// 離開整個遊戲
    /// </summary>
    public class SceneContoroller : MonoBehaviour
    {
        /// <summary>
        /// 載入指定場景
        /// </summary>
        /// <param name="nameScene">場景名稱</param>
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
