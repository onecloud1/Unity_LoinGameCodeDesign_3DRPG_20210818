using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace WEI
{

    public class HurtSystemWithUI : HurtSystem
    {
        [Header("�n��s�����")]
        public Image imgHp;

        private float hpeffectOriginal;
        // �Ƽg�����O���� override
        public override void Hurt(float damage)
        {
            hpeffectOriginal = hp;

            //base �Ӧ����������O�� �����O�������e
            base.Hurt(damage);

            StartCoroutine(HpBarEffect());
        }

        private IEnumerator HpBarEffect()
        {
            while (hpeffectOriginal != hp)
            {
                hpeffectOriginal--;
                imgHp.fillAmount = hpeffectOriginal / hpMax;
                yield return new WaitForSeconds(0.01f);

            }
        }

    }
}
