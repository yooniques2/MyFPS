using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyFPS
{

    public class PickupPuzzleItem : Interactive
    {
        #region Variables
        //퍼즐 UI
        [SerializeField] private PuzzleKey puzzleKey;

        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGp;

        public Sprite itemSprite;                                       //획득한 아이템 아이콘
        [SerializeField] private string puzzleStr = "Puzzle Text";      //아이템 획득 안내 텍스트

        #endregion
        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());

        }
        IEnumerator GainPuzzleItem()
        {
            PlayerStats.Instance.AcquirePuzzleItem(puzzleKey);

            //UI연출
            if (puzzleUI != null)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGp.SetActive(false);

                puzzleUI.SetActive(true);

                puzzleText.text = puzzleStr;
                itemImage.sprite = itemSprite;

                /*
                //itemImage.gameObject.SetActive(true);   //<---------
                                //=====
                                if (itemImage != null)
                                {
                                    itemImage.sprite = itemSprite;
                                }
                                else
                                {
                                    Debug.LogError("itemImage가 할당되지 않았습니다.");
                                }
                                //======


                */
/*
                //========
                if (itemSprite != null)
                {
                    itemImage.sprite = itemSprite;
                }
                else
                {
                    Debug.LogError("itemSprite가 할당되지 않았습니다.");
                }
                //========
*/

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);

            }
            //킬
            Destroy(gameObject);

        }
    }

}