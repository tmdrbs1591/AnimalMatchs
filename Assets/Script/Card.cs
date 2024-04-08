using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer cardRenderer;

    [SerializeField]
    private Sprite animalSprite; // ī���� �ո�

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

        Vector3 originalScale = transform.localScale; // �ʱ� ������ ����
        Vector3 targerScale = new Vector3(0f, originalScale.y, originalScale.z); // ������ ����������

        transform.DOScale(targerScale, 0.2f).OnComplete(() => // DotWeen DOScale �� 0.2�ʵ��� ������ �����Ϸ� �ε巴�� ����
        { // �� ����ǰ� ���� ������ �ڵ� .OnComplete(()
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
            }); // �ٽ� ������ ���� �����Ϸ� ���� ������ // �������� isFlipping�� false��

        });

       

    }

    void OnMouseDown()
    {
        if (!isFlipping)
             FlipCard();
        
    }

}
