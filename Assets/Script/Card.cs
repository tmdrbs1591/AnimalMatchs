using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer cardRenderer;

    [SerializeField]
    private Sprite animalSprite; // ī���� �ո�

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    public void FlipCard()
    {
        cardRenderer.sprite = animalSprite;

    }

    void OnMouseDown()
    {
        FlipCard();
    }

}
