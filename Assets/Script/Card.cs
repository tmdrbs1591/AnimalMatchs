using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer cardRenderer;

    [SerializeField]
    private Sprite animalSprite; // 카드의 앞면

    [SerializeField]
    private Sprite backSprite;

    private bool isFlipped = false;
    private bool isFlipping = false;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    public void FlipCard()
    {
        isFlipping = true;

        Vector3 originalScale = transform.localScale; // 초기 스케일 저장
        Vector3 targerScale = new Vector3(0f, originalScale.y, originalScale.z); // 변경할 스케일저장

        transform.DOScale(targerScale, 0.2f).OnComplete(() => // DotWeen DOScale 로 0.2초동안 변경할 스케일로 부드럽게 변경
        { // 다 실행되고 나서 실행할 코드 .OnComplete(()
            isFlipped = !isFlipped;

            if (isFlipped)
            {
                cardRenderer.sprite = animalSprite;
            }
            else
            {
                cardRenderer.sprite = backSprite;
            }

            transform.DOScale(originalScale,0.2f).OnComplete(() =>
            {
                isFlipping = false;
            }); // 다시 서서히 원래 스케일로 변경 서서히 // 끝나고나면 isFlipping을 false로

        });

       

    }

    void OnMouseDown()
    {
        if (!isFlipping)
             FlipCard();
        
    }

}
