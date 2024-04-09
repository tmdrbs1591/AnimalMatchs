using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<Card> allCards;
    private Card flippedcard;

    private bool isFlipping = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;    
        }
    }
     void Start()
    {
        Board board = FindObjectOfType<Board>();
       allCards =  board.GetCards();

        StartCoroutine(FlipAllCardsRoutine());

    }
    IEnumerator FlipAllCardsRoutine()
    {
        isFlipping = true;
        yield return new WaitForSeconds(0.5f);
        FlipAllCards();
        yield return new WaitForSeconds(3f);
        FlipAllCards();
        yield return new WaitForSeconds(0.5f);
        isFlipping = false;

    }
    void FlipAllCards()
    {
        foreach(Card card in allCards)
        {
            card.FlipCard();
        }
    }

    public void CardClicked(Card card)
    {
        if (isFlipping)
        {
            return;
        }
        card.FlipCard();

        if (flippedcard == null)
        {
            flippedcard = card;
        }
        else
        {
            // �ΰ��� ���� ī������ Ȯ��
            StartCoroutine(CheckMatchRoutine(flippedcard,card));    
        }
    }
  
    IEnumerator CheckMatchRoutine(Card card1,Card card2)
    {
        isFlipping = true;
        if (card1.cardID == card2.cardID)
        {
            card1.SetMatched();
            card2.SetMatched();

        }
        else
        {
            yield return new WaitForSeconds(1f);

            card1.FlipCard();
            card2.FlipCard();

            yield return new WaitForSeconds(0.4f);
        }
        isFlipping = false;
        flippedcard = null;
    }
}
