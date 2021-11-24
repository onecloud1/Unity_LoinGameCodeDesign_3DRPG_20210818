using UnityEngine;
using UnityEngine.Events;

namespace WEI
{

    public class HurtSystem : MonoBehaviour
    {
        [Header("��q"), Range(0, 5000)]
        public float hp = 100;
        [Header("���˨ƥ�")]
        public UnityEvent onHurt;
        [Header("���`�ƥ�")]
        public UnityEvent onDead;
        [Header("�ʵe�Ѽ�:���˻P���`")]
        public string parameterHurt = "hurt";
        public string parameterDead = "death";

        //�p�H�����\�A�l���O�s��
        private Animator anim;

        protected float hpMax;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            hpMax = hp;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="damage">�����쪺�ˮ`</param>
        /// �����n�Q�l���O�Ƽg�����[�W virtual ����
        public virtual bool Hurt(float damage)
        {
            if (anim.GetBool(parameterDead)) return true; //�p�G ���`�ѼƤĿ� �N���X
            hp -= damage;
            anim.SetTrigger(parameterHurt);
            onHurt.Invoke();
            if (hp <= 0)
            {
                Dead();
                return true;
            }
            else return false;
        }

        private void Dead()
        {
            anim.SetBool(parameterDead,true);
            onDead.Invoke();
        }
    }
}
