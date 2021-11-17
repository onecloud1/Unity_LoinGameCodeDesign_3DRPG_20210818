using UnityEngine;

namespace WEI.Dialogue
{
    /// <summary>
    /// ��ܨt�Ϊ����
    /// NPC�n��ܪ��T���q
    /// �����ȫe.�i�椤.��������
    /// </summary>
    /// ScriptableObject �~�Ӧ����O�|�ܸ}���ƪ���,�i�N�}����Ʒ���O�s�b�M��
    /// CreateAssetMenu ���O�ݩ�:�������O�إ߱M�����
    [CreateAssetMenu(menuName = "WEI/��ܸ��",fileName = "NPC��ܸ��")]
    public class DataDialogue : ScriptableObject
    {
        [Header("���ȫe��ܤ��e"),TextArea(2,7)]
        public string[] beforeMission;
        [Header("���ȶi�椤��ܤ��e"), TextArea(2, 7)]
        public string[] missionning;
        [Header("���ȧ�����ܤ��e"), TextArea(2, 7)]
        public string[] afterMission;
        [Header("���ȻݨD�ƶq"),Range(0,100) ]
        public int countNeed;
        [Header("NPC ���Ȫ��A")]
        public StateNPCMission StateNPCMission = StateNPCMission.BeforeMission;
        [Header("��ܪ�NPC�W��")]
        public string nameDialogue;
    }
    //�}�C: �O�s�ۦP������������c
}
