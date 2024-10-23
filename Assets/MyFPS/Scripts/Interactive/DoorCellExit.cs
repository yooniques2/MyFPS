using UnityEngine;

namespace MyFPS
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;

        [SerializeField] private string loadToScene = "PlayScene02";

        private Animator animator;
        private Collider m_collider;
        public AudioSource creakydoor;

        public AudioSource bgm01;
        #endregion
        private void Start()
        {
            animator = GetComponent<Animator>();
            m_collider = GetComponent<Collider>();
        }
        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true);
            m_collider.enabled = false;

            creakydoor.Play();
          
            //다음씬으로 이동
            ChangeScene();
        }

        private void ChangeScene()
        {
            //씬 마무리, bmg strop
            bgm01.Stop();

            fader.FadeTo(loadToScene);
        }

    }
}
