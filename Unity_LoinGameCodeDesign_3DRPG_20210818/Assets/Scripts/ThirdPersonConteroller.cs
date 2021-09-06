using UnityEngine;  //�ޥ� Unity API
using UnityEngine.Video;

/// <summary>
/// 2021.0906
/// �ĤT�H�ٱ��
/// ����.���D
/// </summary>

public class ThirdPersonConteroller : MonoBehaviour
{
    #region ��� Field
    //�x�s�C����ơA�Ҧp�G���ʳt��.���D���׵���...
    //�`�Υ|�j�����G���int.�B�I��float.�r��string.���L��bool
    //���y�k�G�׹��� ������� ���W��(���w �w�]��) ����
    //�׹����G
    //1. ���} public  - ���\�Ҧ����O�s�� - ��ܦb�ݩʭ��O - �ݭn�վ�
    //2. �p�H private - �T���L���O�s�� - ���æb�ݩʭ��O
    // Unity �H�ݩʭ��O��Ƭ��D
    // ����ݩ� Attribute�G���U�����
    // ����ݩʻP�k�G[�ݩʦW��(�ݩʭ�)]
    //Header���D Tooltip�ƹ����d���� Range�d��
    [Header("���ʳt��"), Tooltip("�Ψӽվ㨤�Ⲿ�ʳt��"), Range(0,500)]
    public float speed = 10.5f;

    [Header("���D����"), Range(0, 1000)]
    public float jump = 100f;

    [Header("�O�_�b�a�O�W"), Tooltip("����O�_��b�a�O�W")]
    public bool groundCheck = false;
    public Vector3 groundDisplacement;
    public float groundRadius = 0.2f;
    
    [Header("�����ɮ�")]
    public AudioClip jumpSound;
    public AudioClip downSound;

    [Header("�ʵe�Ѽ�")]
    public string animatroParWalk ="Play_walk";
    public string animatroParRun = "Player_run";
    public string animatroParHurt = "Player_hurt";
    public string animatroParDead = "Player_death";

    public AudioSource soundSource;
    public Rigidbody rig;
    public Animator anim;

    #region Unity �������
    /** �m�� Unity �������
    // �C�� Color
    public Color color;
    public Color white = Color.white; //�����C��
    public Color yellow = Color.yellow;
    public Color color1 = new Color(0.5f, 0.5f, 0); //�ۭq�C��RGB��RGBA
    public Color color2 = new Color(0, 0.5f, 0.5f,0.5f);

    // �y�� Vector 2 - 4
    public Vector2 v2;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v20ne = Vector2.one;
    public Vector2 v2Custom = new Vector2(7.5f, 100.9f);
    public Vector3 v3 = new Vector3(1,2,3);
    public Vector4 v4 = new Vector4(1,2,3,4);

    // ���� �C�|��� enum
    public KeyCode key;
    public KeyCode move = KeyCode.W;
    public KeyCode jump = KeyCode.Space;

    // �C����������G������w�w�]��
    //�s�� Project �M�פ����
    public AudioClip sound; //���� mp3 ogg wav
    public VideoClip video; //�v�� mp4
    public Sprite sprite; // �Ϥ� png jpeg - ���䴩gif
    public Material material; //����y

    // ���� Component�G�ݩʭ��O�W�i���|
    [Header("����")]
    public Transform tra;
    public Animation aniOld;
    public Animator aniNew;
    public Light lig;
    public Camera cam;

    //���L�C 1.��ĳ���n�Ϊ��W�� 2.�ϥιL��API
    **/



    #endregion

    #endregion

    #region �ݩ� Property

    #endregion

    #region ��k Method

    #endregion

    #region �ƥ� Event
    //�S�w�ɶ��I�|���檺��k
    #endregion
}
