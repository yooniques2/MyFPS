using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class PlayerController : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        private string loadToScene = "GameOver";

        [SerializeField] private float maxHealth = 20;

        private float currentHealth;

        private bool isDeath = false;

        //damage effect
        public GameObject damageFlash;  //damage flash effect
        public AudioSource hurt01; //damage audio source 1
        public AudioSource hurt02; //damage audio source 2
        public AudioSource hurt03; //damage audio source 3

        #endregion

        private void Start()
        {
            //초기화
            currentHealth = maxHealth;
            isDeath = false;
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Player Health: {currentHealth}");

            //데미지 효과
            StartCoroutine(DamageEffect());

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        private void Die()
        {
            isDeath = true;

            //Debug.Log("Game Over!");
            fader.FadeTo(loadToScene);
        }
        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);

            int randNumber = Random.Range(1, 4);
            if (randNumber == 1)
            {
                hurt01.Play();
            }
            else if (randNumber == 2)
            {
                hurt02.Play();

            }
            else
            {
                hurt03.Play();
            }

            yield return new WaitForSeconds(1f);
            damageFlash.SetActive(false);

        }
    }
}

