using UnityEngine;
using UnityEngine.Events;
namespace WEI.Dialogue
{
    /// <summary>
    /// NPC�t��
    /// �����ؼЬO�_�i�J��ܽd��,�ö}�ҹ�ܨt��
    /// </summary>
    public class NPC : MonoBehaviour
    {
        #region ���P�ݩ�
        [Header("��ܸ��")]
        public DataDialogue dataDialogue;
        [Header("������T"),Range(0,10)]
        public float cgeckPlayerRadius = 3f;
        public GameObject goTip;
        public float speedLookAt = 4;


        private int countCurrent; //�ثe���ȼƶq
        private Transform target;

        private bool startDialogueKey { get => Input.GetKeyDown(KeyCode.E); }

        [Header("��ܨt��")]
        public DialogueSystem dialogueSystem;

        [Header("�������Ȩƥ�")]
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
        /// ��l�]�w
        /// ���A��_�����ȫe
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
        } //�䪱�a��}

        private void LookAtPlayer()
        {
            if(CheckPlayer())
            {
                Quaternion angle = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
            }
        } //���۪��a

        /// <summary>
        /// ���a�i�J�d�� �åB ���U���w���� �й�ܨt�ΰ��� �}�l���
        /// ���a�h�X�d��~ ������
        /// �P�_���A�G���ȫe.���Ȥ�.���ȫ�
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