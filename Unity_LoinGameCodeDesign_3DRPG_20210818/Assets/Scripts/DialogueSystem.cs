using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WEI.Dialogue
{
    /// <summary>
    /// 對話系統
    /// 顯示對話框.對話內容打字效果
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        [Header("對話系統需要的介面物件")]
        public CanvasGroup groupDialogue;
        public Text textName;
        public Text textContent;
        public GameObject goTriangle;
        [Header("對話間隔"), Range(0, 10)]
        public float dialogueInterval = 0.3f;
        [Header("對話間隔")]
        public KeyCode dialogueKey = KeyCode.Z;

        //呼叫協同程序 開始對話
        public void Dialogue(DataDialogue data)
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup());
            StartCoroutine(ShowDialogueContent(data));
        }

        public void StopDialogue()
        {
            StopAllCoroutines();
            StartCoroutine(SwitchDialogueGroup(false));
        }

        /// <summary>
        /// 切換對話框群組
        /// </summary>
        /// 是否淡入 true 淡入 false 淡出
        private IEnumerator SwitchDialogueGroup(bool fadeIn = true)
        {
            //三元運算子
            //語法：布林值 ? ture結果  ：false 結果 
            float increase = fadeIn ? 0.1f : -0.1f;    //透過布林值 決定增加0.1f 或 false 增加-0.1f

            for (int i = 0; i < 10; i++)    //迴圈淡入淡出
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.03f);
            }
        }

        private IEnumerator ShowDialogueContent(DataDialogue data)
        {
            
            //遍尋每一段對話
            for (int j = 0; j < data.beforeMission.Length; j++)
            {
                textContent.text = ""; //每次跑下段對話清除內容
                textName.text = data.nameDialogue;
                goTriangle.SetActive(false); //隱藏右下閃爍提示

                //遍尋對話每一個字
                for (int i = 0; i < data.beforeMission[j].Length; i++)
                {
                    textContent.text += data.beforeMission[j][i];
                    yield return new WaitForSeconds(dialogueInterval);
                }

                goTriangle.SetActive(true);

                // 持續時間 輸入 對話按鍵 null 等待第一個影格時間
                while(!Input.GetKeyDown(dialogueKey)) yield return null;           
            }
            StartCoroutine(SwitchDialogueGroup(false)); //淡出
        }
    }
}