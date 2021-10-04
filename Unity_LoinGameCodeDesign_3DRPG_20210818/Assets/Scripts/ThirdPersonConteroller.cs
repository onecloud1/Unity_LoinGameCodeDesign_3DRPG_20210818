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
    //�H�����q
    private float volumeRamdom { get => Random.Range(0.7f, 1.2f); }

    [Header("�ʵe�Ѽ�")]
    public string animatroParWalk = "Walk";
    public string animatroParRun = "Run";
    public string animatroParHurt = "hurt";
    public string animatroParDead = "death";
    public string animatroParJump = "jump";
    public string animatroParIsGround = "checkground";

    public GameObject platerObject;
    private ThirdPersonCamera thirdPersonCamera;


    #endregion

    #region �ݩ� Property 

    private bool KeyJump { get => Input.GetKeyDown(KeyCode.Space); }

    #endregion

    #region ��k Method

    private int ReturnJump()
    {
        return 999;
    }

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
            transform.forward * MoveInput("Vertical") * speedMove +
            transform.right * MoveInput("Horizontal") * speedMove +
            Vector3.up * rig.velocity.y;
        
    }
    // ���ʫ����J asisName���ʫ����
    private float MoveInput(string asisName)
    {
        return Input.GetAxis(asisName);
    }
    [Header("���۳t��")]
    public float speedLookAt = 2;
    //�����b�V�j��0.1 �N�B�z ���V
    private void LookAtForward()
    {
        if (MoveInput("Vertical") > 0.1f)
        {
            Quaternion angle = Quaternion.LookRotation(thirdPersonCamera.posForward - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
        }
    }

   
    #endregion

    #region �ƥ� Event
   
    

    void Start() // �}�l����@��
    {      
        // �������W��.���o����(����(��������)) ��@ ��������
        aud = platerObject.GetComponent(typeof(AudioSource)) as AudioSource;
        //    ���}���C������.���o����<�x��>()
        rig = gameObject.GetComponent<Rigidbody>();
        // ���o����
        anim = GetComponent<Animator>();

        //��v�����O = �z�L�����M�䪫��<�x��>(); �ݭn���骫��
        //FindObjectOfType���n�Aupdata��,�|�L�j�t�� 
        thirdPersonCamera = FindObjectOfType<ThirdPersonCamera>();
    }
    void Update() 
    {
        Jump();
        UpdataAnimation();
        LookAtForward();
    }
    // 0.002�����@��
    void FixedUpdate()
    {
        Move(speed);
    }

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
        //���ĭ��ĻP�[�P�_
        if (!Isground && hits.Length > 0) aud.PlayOneShot(downSound, volumeRamdom);
       

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
            //�_������
            aud.PlayOneShot(jumpSound, volumeRamdom);
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
