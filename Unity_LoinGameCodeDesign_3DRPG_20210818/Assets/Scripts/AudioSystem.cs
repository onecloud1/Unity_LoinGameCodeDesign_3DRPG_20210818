using UnityEngine;

namespace WEI
{
    /// <summary>
    /// ���Ĩt��
    /// ���ѵ��f���n���񭵮Ī�����
    /// 
    /// �M�Τ���� �|�n�D����G�|�۰ʲK�[���w������
    /// [�n�D����(����(����1),����(����2)...)]
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AudioSystem : MonoBehaviour
    {

        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }



        /// <summary>
        /// ���`���q���񭵮�
        /// </summary>
        /// <param name="sound">����</param>
        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }

        /// <summary>
        /// ���񭵮Ĩ��H�����q 
        /// </summary>
        /// <param name="sound">����</param>
        public void playSoundRandowVolume(AudioClip sound)
        {
            float volume = Random.Range(0.2f, 0.4f);
            aud.PlayOneShot(sound,volume);
        }
    }

}
