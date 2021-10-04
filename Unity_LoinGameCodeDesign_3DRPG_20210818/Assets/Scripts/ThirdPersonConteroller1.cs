using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonConteroller1 : MonoBehaviour
{
    #region ��� Field
 
    private AudioSource aud;
    private Rigidbody rig;
    private Animator anim;



    [Header("���ʳt��"), Tooltip("�Ψӽվ㨤�Ⲿ�ʳt��"), Range(0, 500)]
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
   



    #endregion

    #endregion

    #region �ݩ� Property

    private bool KeyJump { get => Input.GetKeyDown(KeyCode.Space); }

    #endregion

    #region ��k Method

    
    private void Test()
    {
        print("�ڬO�ۭq��k~");
    }

    private int ReturnJump()
    {
        return 999;
    }

   
    private void Skill(int damage, string effect = "�ǹЯS��", string sound = "�ǹǹ�")
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

    
    #endregion

    #region �ƥ� Event
    
    private float BMI(float weight, float height, string name = "����")
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
        
        Test();
        //�I�s�覡
        //1.�ϰ��ܼ� -�ȯ�b�j�A�����s��
        int j = ReturnJump();
        print("���D��" + j);
        //2.�N�Ǧ^��k���Ȩϥ�
        print("���D��.��Ȩϥ�" + (ReturnJump() + 1));


        //���Ѽƪ�������
        Skill(300);
        Skill(999, "�z���S��");
        Skill(500, sound: "������");
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
        if (CheckGround() && KeyJump)
        {
            rig.AddForce(transform.up * jump);
        }

    }

    private void UpdataAnimation()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool(animatroParWalk, true);
        }
        else
            anim.SetBool(animatroParWalk, false);

        anim.SetBool(animatroParIsGround, Isground);

        if (KeyJump) anim.SetTrigger(animatroParJump);
    }
   #endregion
}