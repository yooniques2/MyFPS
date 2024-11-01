using UnityEngine;

namespace MySample
{

    public class SoundTest : MonoBehaviour
    {
        #region Variables
        private AudioSource audioSource;

        public AudioClip clip;     //재생할 오디오 클립

        [SerializeField] private float volume = 1.0f;
        [SerializeField] private float pitch = 1.0f;
        [SerializeField] private bool loop = false;
        //[SerializeField] private bool playOnAwake = false;

        #endregion
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            SoudPlay();

        }
        void SoudPlay()
        {
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.loop = loop;

            audioSource.Play();
        }
    }
}