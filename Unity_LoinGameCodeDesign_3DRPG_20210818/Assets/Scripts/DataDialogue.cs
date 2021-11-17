using UnityEngine;

namespace WEI.Dialogue
{
    /// <summary>
    /// 對話系統的資料
    /// NPC要對話的三階段
    /// 接任務前.進行中.完成任務
    /// </summary>
    /// ScriptableObject 繼承此類別會變腳本化物件,可將腳本資料當物件保存在專案
    /// CreateAssetMenu 類別屬性:為此類別建立專內選單
    [CreateAssetMenu(menuName = "WEI/對話資料",fileName = "NPC對話資料")]
    public class DataDialogue : ScriptableObject
    {
        [Header("任務前對話內容"),TextArea(2,7)]
        public string[] beforeMission;
        [Header("任務進行中對話內容"), TextArea(2, 7)]
        public string[] missionning;
        [Header("任務完成對話內容"), TextArea(2, 7)]
        public string[] afterMission;
        [Header("任務需求數量"),Range(0,100) ]
        public int countNeed;
        [Header("NPC 任務狀態")]
        public StateNPCMission StateNPCMission = StateNPCMission.BeforeMission;
        [Header("對話的NPC名稱")]
        public string nameDialogue;
    }
    //陣列: 保存相同資料類型的結構
}
