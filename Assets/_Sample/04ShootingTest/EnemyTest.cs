using MyFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{

    public class EnemyTest : MonoBehaviour, IDamageable
    {
        #region Variables
        //체력
        [SerializeField] private float maxHealth = 20;

        private float currentHealth;

        private bool isDeath = false;
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
            Debug.Log($"Remain Health: {currentHealth}");
             

            //데미지 효과,  

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        private void Die()
        {
            isDeath = true;
            Debug.Log("Enemy Died");
            
            //보상 - 경험치, 돈

            //효과

            //죽음처리
            Destroy(gameObject, 3f);

        }
    }

}