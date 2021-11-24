using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using WEI.Dialogue;

namespace WEI.Enemy
{
    public class Enemy : MonoBehaviour
    {   //�ݩ�
        [Header("���ʳt��"), Range(0, 20)]
        public float speed = 2.5f;
        [Header("�����O"), Range(0, 200)]
        public float attack = 35;
        [Header("�d��:�l�ܻP����")]
        [Range(0, 7)]
        public float rangeattack = 5;
        [Range(7, 20)]
        public float rangeTrack = 15;
        [Header("�����H�����")]
        public Vector2 v2RandomWait = new Vector2(1f, 5f);
        [Header("�����H�����")]
        public Vector2 v2RandomWalk = new Vector2(3, 7);
        [Header("�����ϰ�첾�P�ؤo")]
        public Vector3 v3AttackOffset;
        public Vector3 v3AttackSize = Vector3.one;
        [Header("NPC�W��")]
        public string nameNPC = "NPC�p��";

        private NPC npc;
        private HurtSystem hurtSystem;

        //�O�_���ݵ���...���A
        private bool isIdle;
        private bool isWalk;

        private Animator anim;
        private string parameterIdleWalk = "Walk";

        [Header("�����ɶ�"), Range(0, 5)]
        public float timeAttack = 2.5f;
        private string parameterAttack = "atk";
        private bool isAttack;
        [Header("��������ǰe�ˮ`�ɶ�"), Range(0, 5)]
        public float delaySenDamage = 0.5f;
        [Header("���۪��a�t��"), Range(0, 50)]
        public float speedLookAt = 10;


        private NavMeshAgent nma;

        private Vector3 v3RandomWalkFinal;
        private Vector3 v3RandomWalk
        {
            get => Random.insideUnitSphere * rangeTrack + transform.position;
        }

        private Transform traPlayer;
        private string namePlayer = "Player";

        [SerializeField]
        private StateEnemy state;
        private bool targetIsDead;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            nma.speed = speed;
            hurtSystem = GetComponent<HurtSystem>();

            traPlayer = GameObject.Find(namePlayer).transform;
            npc = GameObject.Find(nameNPC).GetComponent<NPC>();

            hurtSystem.onDead.AddListener(npc.UpdateMissionCount);

            nma.SetDestination(transform.position);              //������
        }

        //ø�s�ϧ�
        private void OnDrawGizmos()
        {
            #region ����.�l��.�H���樫
            Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeattack);

            Gizmos.color = new Color(0.2f, 1, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeTrack);

            if(state == StateEnemy.Walk)
            {
                Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
                Gizmos.DrawSphere(v3RandomWalkFinal, 0.3f);
            }
            #endregion

            #region �����I���P�w�ϰ�
            Gizmos.color = new Color(0.8f, 0.2f, 0.7f, 0.3f);
            //ø�s���.�ݭn��ۨ������ �ϥ� matrix ���w�y�Ш��׻P�ؤo
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                transform.rotation, transform.localScale);

            Gizmos.DrawCube(Vector3.zero,v3AttackSize);
            #endregion
        }

        private void Update()
        {
            StateManager();
        }

        private void StateManager()
        {
            switch(state)
            {
                case StateEnemy.Idle:
                    Idle();
                    break;
                case StateEnemy.Walk:
                    Walk();
                    break;
                case StateEnemy.Track:
                    Track();
                    break;
                case StateEnemy.Attack:
                    Attack();
                    break;
                case StateEnemy.Hurt:
                    break;
                case StateEnemy.Dead:
                    break;
                default:
                    break;
            }
        }
        
        private void Idle()
        {
            if (!targetIsDead && playerInTrackRange) state = StateEnemy.Track; //�p�G���a�i�J �l�ܽd�� �������l�ܪ��A

            //�i�J����
            if (isIdle) return;
            isIdle = true;
            print("����");

            anim.SetBool(parameterIdleWalk, false);
            StartCoroutine(IdleEffect());
        }

        private IEnumerator IdleEffect()
        {
            float randomWait = Random.Range(v2RandomWait.x, v2RandomWait.y);
            yield return new WaitForSeconds(randomWait);

            state = StateEnemy.Walk;
            //�X�h����
            isIdle = false;
        }

        private void Walk()
        {
            if (!targetIsDead && playerInTrackRange) state = StateEnemy.Track; //�p�G���a�i�J �l�ܽd�� �������l�ܪ��A

            //�N�z��.�]�w�ت��a(�y��)
            nma.SetDestination(v3RandomWalkFinal);
            anim.SetBool(parameterIdleWalk, nma.remainingDistance > 0.1f); //�����ʵe - ���ت��a�j��0.1�ɨ���

            if (isWalk) return;
            isWalk = true;
            print("�H���y��" + v3RandomWalk);        

            NavMeshHit hit;  //��������I��.�x�s�I����T
            NavMesh.SamplePosition(v3RandomWalk, out hit,rangeTrack,NavMesh.AllAreas); //��������.���o�y��.���椺�i���y��
            v3RandomWalkFinal = hit.position; //�̲׮y�� = �I����T �� �y��

            
            StartCoroutine(WalkEffect());           
        }

        private IEnumerator WalkEffect()
        {
            float randomWalk = Random.Range(v2RandomWalk.x, v2RandomWalk.y);
            yield return new WaitForSeconds(randomWalk);

            state = StateEnemy.Idle;

            //���}����
            isWalk = false;
        }

        private bool playerInTrackRange { get => Physics.OverlapSphere(transform.position, rangeTrack, 1 << 6).Length > 0; }


        /// <summary>
        /// �l�ܪ��a
        /// </summary>
        private bool isTrack;
        private void Track()
        {         
            if(!isTrack)
            {
                StopAllCoroutines();
            }

            nma.isStopped = false;
            nma.SetDestination(traPlayer.position);
            anim.SetBool(parameterIdleWalk, true);

            if (nma.remainingDistance <= rangeattack) state = StateEnemy.Attack;
        }
        /// <summary>
        /// �������a
        /// </summary>
        private void Attack()
        {
            nma.isStopped = true;                                   //������ ����
            anim.SetBool(parameterIdleWalk, false);                 //�����
            nma.SetDestination(traPlayer.position);
            LookAtPlayer();

            if (nma.remainingDistance > rangeattack) state = StateEnemy.Track;

            if (isAttack) return;       //�p�G ���b������ �N���X(�קK���Ƨ���)
            isAttack = true;            //���b ������
            anim.SetTrigger(parameterAttack);

            StartCoroutine(DelaySendDamageToTarget());      //�Ұʩ���ǰe�ˮ`���ؼШ�{
        }

        /// <summary>
        /// ����ǰe�ˮ`���ؼ�
        /// </summary>
        private IEnumerator DelaySendDamageToTarget()
        {
            yield return new WaitForSeconds(delaySenDamage);

            //���z ���θI��(�����I.�@�b�ؤo.����.�ϼh)
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.right * v3AttackOffset.x +
                transform.up * v3AttackOffset.y +
                transform.forward * v3AttackOffset.z,
                v3AttackSize / 2, Quaternion.identity, 1 << 6);

            //�p�G �I������ƶq�j�� �s . �ǰe�����O���I�����󪺨��˨t��
            if (hits.Length > 0) targetIsDead = hits[0].GetComponent<HurtSystem>().Hurt(attack);
            if (targetIsDead) TargetDead();

            float waitToNextAttack = timeAttack - delaySenDamage;     //�p��Ѿl�N�o�ɶ�
            yield return new WaitForSeconds(waitToNextAttack);        //����

            isAttack = false;                                         //��_ �������A
        }
        /// <summary>
        /// �ؼЦ��`
        /// </summary>
        private void TargetDead()
        {
            state = StateEnemy.Walk;
            isIdle = false;
            isWalk = false;
            nma.isStopped = false;
        }

        

        private void LookAtPlayer()
        {
            Quaternion angle = Quaternion.LookRotation(traPlayer.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * speedLookAt);
        }
    }
}
