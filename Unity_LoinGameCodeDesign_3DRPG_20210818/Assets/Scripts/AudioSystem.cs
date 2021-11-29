using UnityEngine;

namespace WEI
{
    /// <summary>
    /// 音效系統
    /// 提供窗口給要播放音效的物件
    /// 
    /// 套用元件時 會要求元件：會自動添加指定的元件
    /// [要求元件(類型(元件1),類型(元件2)...)]
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
        /// 正常音量播放音效
        /// </summary>
        /// <param name="sound">音效</param>
        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }

        /// <summary>
        /// 播放音效並隨機音量 
        /// </summary>
        /// <param name="sound">音效</param>
        public void playSoundRandowVolume(AudioClip sound)
        {
            float volume = Random.Range(0.2f, 0.4f);
            aud.PlayOneShot(sound,volume);
        }
    }

}
