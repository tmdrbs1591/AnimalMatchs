using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<Card> allCards;
    private Card flippedcard;

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
        yield return new WaitForSeconds(0.5f);
        FlipAllCards();
        yield return new WaitForSeconds(3f);
        FlipAllCards();
        yield return new WaitForSeconds(0.5f);

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
        card.FlipCard();

        if (flippedcard == null)
        {
            flippedcard = card;
        }
        else
        {
            // 두개가 같은 카드인지 확인
            StartCoroutine(CheckMatchRoutine(flippedcard,card));    
        }
    }
  
    IEnumerator CheckMatchRoutine(Card card1,Card card2)
    {
        if (card1.cardID == card2.cardID)
        {
            Debug.Log("Same");
        }
        else
        {
            Debug.Log("Deffrent");
            yield return new WaitForSeconds(1f);

            card1.FlipCard();
            card2.FlipCard();

            yield return new WaitForSeconds(0.4f);
        }
        flippedcard = null;
    }
}
