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
    private AudioSource aud;
    private Rigidbody rig;
    private Animator anim;

    

    [Header("���ʳt��"), Tooltip("�Ψӽվ㨤�Ⲿ�ʳt��"), Range(0,500)]
    public float speed = 10.5f;

    [Header("���D����"), Range(0, 1000)]
    public int jump = 100;

    [Header("�O�_�b�a�O�W"), Tooltip("����O�_��b�a�O�W")]
    public bool Isground = false;
    public Vector3 groundDisplacement;
    public float groundRadius = 0.2f;
    
    [Header("�����ɮ�")]
    public AudioClip jumpSound;
    public AudioClip downSound;

    [Header("�ʵe�Ѽ�")]
    public string animatroParWalk = "Walk";
    public string animatroParRun = "Run";
    public string animatroParHurt = "hurt";
    public string animatroParDead = "death";
    public string animatroParJump = "jump";
    public string animatroParIsGround = "checkground";


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

    private bool KeyJump { get => Input.GetKeyDown(KeyCode.Space); }

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

    //���� speedMove���ʳt��
    private void Move(float speedMove)
    {   //����.�[�t�� = �s�T���V�q �Υ[�t�ױ���
        //�ϥΫe�ᥪ�k�b�V�B�ʥB�O���쥻�a�ߤޤO
        rig.velocity =
            Vector3.forward * MoveInput("Vertical") * speedMove +
            Vector3.right * MoveInput("Horizontal") * speedMove +
            Vector3.up * rig.velocity.y;
        
    }
    // ���ʫ����J asisName���ʫ����
    private float MoveInput(string asisName)
    {
        return Input.GetAxis(asisName);
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

    public GameObject platerObject;
    void Start() // �}�l����@��
    {
        #region
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
        #endregion
        // �������W��.���o����(����(��������)) ��@ ��������
        aud = platerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        //    ���}���C������.���o����<�x��>()
        rig = gameObject.GetComponent<Rigidbody>();
        // ���o����
        anim = GetComponent<Animator>();

    }
    // ��s�ƥ�G���@�����60��
    // �B�z����ʹB��.���ʪ���.��ť���a��J����
    void Update() 
    {
        Jump();
        UpdataAnimation();
    }
    // 0.002�����@��
    void FixedUpdate()
    {
        Move(speed);
    }
    //ø�s�ϥܨƥ�
    //1.���w�C��
    //2.ø�s�ϧ�
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);

        Gizmos.DrawSphere(
            transform.position +
            transform.right * groundDisplacement.x +
            transform.up * groundDisplacement.y +
            transform.forward * groundDisplacement.z,
            groundRadius);
    }

    private bool CheckGround()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position +
            transform.right * groundDisplacement.x +
            transform.up * groundDisplacement.y +
            transform.forward * groundDisplacement.z,
            groundRadius, 1 << 3);

        //Debug.Log("�y��Ĥ@�ӸI�쪺����" + hits[0].name);
        //�Ǧ^�I���}�C�ƶq > 0 �u�n�I����w�ϼh�N�N��b�a���W

        Isground = hits.Length > 0;

        return hits.Length > 0;      
    }

    private void Jump()
    {
        Debug.Log("�O�_�b�a���W" + CheckGround());
        // &&=�åB
        //�p�G�b�a���W �åB ���U�ť���N���D
        if(CheckGround() && KeyJump)
        {
            rig.AddForce(transform.up * jump);
        }

    }

    private void UpdataAnimation()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool(animatroParWalk, true);
        } else
        anim.SetBool(animatroParWalk, false);

        anim.SetBool(animatroParIsGround, Isground);

        if (KeyJump) anim.SetTrigger(animatroParJump);
    }

    #endregion
}
