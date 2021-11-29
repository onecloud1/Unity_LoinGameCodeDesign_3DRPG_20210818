using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WEI.Dialogue
{
    /// <summary>
    /// ��ܨt��
    /// ��ܹ�ܮ�.��ܤ��e���r�ĪG
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        [Header("��ܨt�λݭn����������")]
        public CanvasGroup groupDialogue;
        public Text textName;
        public Text textContent;
        public GameObject goTriangle;
        [Header("��ܶ��j"), Range(0, 10)]
        public float dialogueInterval = 0.3f;
        [Header("��ܶ��j")]
        public KeyCode dialogueKey = KeyCode.Z;
        [Header("���r�t��")]
        public UnityEvent onType;


        //�I�s��P�{�� �}�l���
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
        /// ������ܮظs��
        /// </summary>
        /// �O�_�H�J true �H�J false �H�X
        private IEnumerator SwitchDialogueGroup(bool fadeIn = true)
        {
            //�T���B��l
            //�y�k�G���L�� ? ture���G  �Gfalse ���G 
            float increase = fadeIn ? 0.1f : -0.1f;    //�z�L���L�� �M�w�W�[0.1f �� false �W�[-0.1f

            for (int i = 0; i < 10; i++)    //�j��H�J�H�X
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.03f);
            }
        }

        private IEnumerator ShowDialogueContent(DataDialogue data)
        {
            textContent.text = ""; //�C���]�U�q��ܲM�����e
            textName.text = data.nameDialogue;

            #region �B�z���A�P��ܸ��
            string[] dialogueCountents = { };  //�x�s ��ܤ��e

            switch (data.StateNPCMission)
            {
                case StateNPCMission.BeforeMission:
                    dialogueCountents = data.beforeMission;
                    break;
                case StateNPCMission.Missionning:
                    dialogueCountents = data.missionning;
                    break;
                case StateNPCMission.AfterMission:
                    dialogueCountents = data.afterMission;
                    break;
            }
            #endregion

            //�M�M�C�@�q���
            for (int j = 0; j < dialogueCountents.Length; j++)
            {
                textContent.text = ""; //�C���]�U�q��ܲM�����e
                textName.text = data.nameDialogue;

                goTriangle.SetActive(false); //���åk�U�{�{����

                //�M�M��ܨC�@�Ӧr
                for (int i = 0; i < dialogueCountents[j].Length; i++)
                {
                    onType.Invoke();
                    textContent.text += dialogueCountents[j][i];
                    yield return new WaitForSeconds(dialogueInterval);
                }

                goTriangle.SetActive(true);

                // ����ɶ� ��J ��ܫ��� null ���ݲĤ@�Ӽv��ɶ�
                while(!Input.GetKeyDown(dialogueKey)) yield return null;           
            }
            StartCoroutine(SwitchDialogueGroup(false)); //�H�X
        }
    }
}