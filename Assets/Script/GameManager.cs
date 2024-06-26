using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<Card> allCards;
    private Card flippedcard;

    private bool isFlipping = false;

    [SerializeField] private Slider timeoutSlider;
    [SerializeField] TextMeshProUGUI timeoutText;
    [SerializeField] private float timeLimit = 60f;
    private float currentTime;

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

        currentTime = timeLimit;

        SetcurrentTimeText();
        StartCoroutine(FlipAllCardsRoutine());

    }
    void SetcurrentTimeText()   
    {
        int timeSec = Mathf.CeilToInt(currentTime);
        timeoutText.SetText(timeSec.ToString());
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

        yield return StartCoroutine(CountDownTimerRoutine());
    }
    IEnumerator CountDownTimerRoutine()
    {
        while(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeoutSlider.value = currentTime/timeLimit;
            SetcurrentTimeText();
            yield return null;
        }

        GameOver(false);    
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
            // 두개가 같은 카드인지 확인
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
    void GameOver(bool succes)
    {
        if (succes)
        {
            Debug.Log("d");
        }
        else
        {
            Debug.Log("over");

        }
    }
}
