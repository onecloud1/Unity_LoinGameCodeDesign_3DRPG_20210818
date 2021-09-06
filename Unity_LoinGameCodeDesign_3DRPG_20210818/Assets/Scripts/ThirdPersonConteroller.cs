using UnityEngine;  //�ޥ� Unity API
using UnityEngine.Video;

/// <summary>
/// 2021.0906
/// �ĤT�H�ٱ��
/// ����.���D
/// </summary>

public class ThirdPersonConteroller : MonoBehaviour
{
    
     /** �Ұ�m�� �����k

    // �P�| Cart + M O  �i�} Cart + M L
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="moveSpeed">���ʳt��</param>
    private void move(float moveSpeed)
    {
        
    }
    /// <summary>
    /// ���ʫ����J
    /// </summary>
    /// <returns>���ʫ����</returns>
    private float moveKey()
    {
        return 0f;
    }
    /// <summary>
    /// �ˬd�a�O
    /// </summary>
    /// <returns>�O�_�I��a�O</returns>
    private bool groundCheck()
    {
        return false;
    }
    /// <summary>
    /// ���D
    /// </summary>
    private void jump()
    {

    }
    /// <summary>
    /// ��s�ʵe
    /// </summary>
    private void animationUpdate()
    {

    }

    **/
    





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
    /** �ݩʽm��
    //�x�s��ƻP���ۦP
    //�t���b��G�i�H�]�w�s���v�� Get Set
    //�ݩʻy�k�G�׹��� ������� �ݩʦW�� { ��; �s; }
    public int readAndWritr { get; set; }

    public int read { get; } //��Ū�ݩʡG�u����o get

    public int readValue //��Ū�ݩʡG�z�Lget�]�w�w�]��,return���Ǧ^��
    {
        get
        {
            return 77;
        }
    }
    //�߼g�ݩʸT���Wset
    private int _hp;
    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    */

    public KeyCode KeyJump { get; }

    #endregion

    #region ��k Method

    //�w�q�P��@�������{�����϶�.�\��
    //��k�y�k�G�׹��� �Ǧ^������� ��k�W�� (�Ѽ�1,�Ѽ�N){�{���϶�}
    //�`�ζǦ^�����G�L�Ǧ^ void - ����k�S���Ǧ^���

    //�榡�۰ʱƪ��ֱ��� Ctrl+ K D

    //�W�ٲH��-�S�Q�I�s  �W�٫G��-���Q�I�s
    private void Test()
    {
        print("�ڬO�ۭq��k~");
    }

    private int ReturnJump()
    {
        return 999;
    }

    //���C���@�P�X�R�ʪ���k�� ������� �ѼƦW��
    //���w�]�Ȫ��Ѽƥi�H����J�޼ơA��񦡰Ѽ�
    //����񦡰Ѽƥu���b()�k��
    private void Skill(int damage, string effect = "�ǹЯS��",string sound = "�ǹǹ�")
    {
        print("�Ѽƪ��� - �ˮ`��" + damage);
        print("�Ѽƪ��� - �ޯ�S��" + effect);
        print("�Ѽƪ��� - ����" + sound);
    }

    //��Ӳ� ���ϥΰѼơ�
    /**��Ӳ�
    private void Skill100()
    {
        print("�ˮ`��" + 100);
        print("�ޯ�S��");
    }
    private void Skill200()
    {
        print("�ˮ`��" + 200);
        print("�ޯ�S��");
    }
    **/
    #endregion

    #region �ƥ� Event
    // �S�w�ɶ��I�|���檺��k

    // BMI = �魫 / ���� * ���� (����)
    /// <summary>
    /// �p��BMI����k
    /// </summary>
    /// <param name="weight">�魫�A��쬰����</param>
    /// <param name="height">�����A��쬰����</param>
    /// <param name="name">�W�l</param>
    /// <returns></returns>
    private float BMI(float weight,float height,string name = "����")
    {
        print(name + "�� BMI");

        return weight / (height * height);
    }

 
    void Start() // �}�l����@��
    {

        print(BMI(70, 1.75f, "WEI"));

        #region ��X��k



        #endregion
        /**�ݩʿ�X�m��
        // ���P�ݩ� ���o Get �]�wSet
        print("����� - ���ʳt�סG" + speed);
        print("�ݩʸ�� - Ū�g�t�סG" + readAndWritr);
        speed = 20.5f;
        readAndWritr = 90;
        print("�ק�᪺���");
        print("����� - ���ʳt�סG" + speed);
        print("����� - ���ʳt�סG" + readAndWritr);

        print("��Ū�ݩʡG" + read);
        print("��Ū�ݩ�.���w�]�ȡG" + readValue);

        //�ݩʦs���m��
        print("HP�G" + hp);
        hp = 100;
        print("HP�G" + hp);
        */
        //�I�s�ۭq��k�y�k�G��k�W��();
        Test();
        //�I�s�覡
        //1.�ϰ��ܼ� -�ȯ�b�j�A�����s��
        int j = ReturnJump();
        print("���D��" + j);
        //2.�N�Ǧ^��k���Ȩϥ�
        print("���D��.��Ȩϥ�" + (ReturnJump() + 1));

        
        //���Ѽƪ�������
        Skill(300);
        Skill(999,"�z���S��");
        Skill(500, sound:"������");

    }
    // ��s�ƥ�G���@�����60��
    // �B�z����ʹB��.���ʪ���.��ť���a��J����
    void Update() 
    {

    }

    #endregion
}
