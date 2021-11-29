using UnityEngine;
using UnityEngine.Events;
namespace WEI.Dialogue
{
    /// <summary>
    /// NPC系統
    /// 偵測目標是否進入對話範圍,並開啟對話系統
    /// </summary>
    public class NPC : MonoBehaviour
    {
        #region 欄位與屬性
        [Header("對話資料")]
        public DataDialogue dataDialogue;
        [Header("相關資訊"),Range(0,10)]
        public float cgeckPlayerRadius = 3f;
        public GameObject goTip;
        public float speedLookAt = 4;


        private int countCurrent; //目前任務數量
        private Transform target;

        private bool startDialogueKey { get => Input.GetKeyDown(KeyCode.E); }

        [Header("對話系統")]
        public DialogueSystem dialogueSystem;

        [Header("完成任務事件")]
        public UnityEvent onFinish;

        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, cgeckPlayerRadius);
        }

        private void Awake()
        {
            Initialized();
        }

        private void Update()
        {
            goTip.SetActive(CheckPlayer());
            LookAtPlayer();
            StartDialogue();
        }
        /// <summary>
        /// 初始設定
        /// 狀態恢復為任務前
        /// </summary>
        private void Initialized()
        {
            dataDialogue.StateNPCMission = StateNPCMission.BeforeMission;
        }

        public void UpdateMissionCount()
        {
            countCurrent++;

            if (countCurrent == dataDialogue.countNeed)
            {
                dataDialogue.StateNPCMission = StateNPCMission.AfterMission;
                onFinish.Invoke();
            }
        }

        private bool CheckPlayer()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, cgeckPlayerRadius, 1 << 6);

            if (hits.Length > 0) target = hits[0].transform;

            return hits.Length > 0;
        } //找玩家位址

        private void LookAtPlayer()
        {
            if(CheckPlayer())
            {
                Quaternion angle = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
            }
        } //面相玩家

        /// <summary>
        /// 玩家進入範圍內 並且 按下指定按鍵 請對話系統執行 開始對話
        /// 玩家退出範圍外 停止對話
        /// 判斷狀態：任務前.任務中.任務後
        /// </summary>
        private void StartDialogue()
        {
            if (CheckPlayer() && startDialogueKey)
            {
                dialogueSystem.Dialogue(dataDialogue);

                if (dataDialogue.StateNPCMission == StateNPCMission.BeforeMission) 
                    dataDialogue.StateNPCMission = StateNPCMission.Missionning;
            }
            else if (!CheckPlayer()) dialogueSystem.StopDialogue();
        }
    }

}