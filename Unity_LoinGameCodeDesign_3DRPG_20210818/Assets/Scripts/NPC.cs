using UnityEngine;

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

        private Transform target;

        private bool startDialogueKey { get => Input.GetKeyDown(KeyCode.E); }

        [Header("��ܨt��")]
        public DialogueSystem dialogueSystem;

        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, cgeckPlayerRadius);
        }

        private void Update()
        {
            goTip.SetActive(CheckPlayer());
            LookAtPlayer();
            StartDialogue();
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

        private void StartDialogue()
        {
            if(CheckPlayer() && startDialogueKey)
            {
                dialogueSystem.Dialogue(dataDialogue);
            }
        }
    }

}