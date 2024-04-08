using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField]
    private Sprite[] cardSprites;

    private List<int> cardIDList = new List<int>();


    void Start()
    {
        GenerateCardID();
        ShuffleCardID();
        InitBoard();
    }
    void GenerateCardID()
    {
        for (int i = 0; i < cardSprites.Length; i++)
        {
            cardIDList.Add(i);
            cardIDList.Add(i);
        }
    }
    void ShuffleCardID()
    {
        int cardCount = cardIDList.Count;
        for (int i = 0; i < cardCount; i++)
        {
            int randomIndex = Random.Range(i,cardCount);
            int temp = cardIDList[randomIndex];
            cardIDList[randomIndex] = cardIDList[i];
            cardIDList[i] = temp;
        }
    }
    void InitBoard()
    {
        float spaceY = 1.8f;
        float spaceX = 1.3f;

        //row
        //0
        //1
        //2
            
        int rowCount = 5; //세로 카드개수
        int columnCount = 4; //가로 카드개수

        int cardIndex = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                float posY = (row - (int)(rowCount / 2 )) * spaceY;
                float posX = (col - (int)(columnCount / 2)) * spaceX + (spaceX / 2);

                Vector3 pos = new Vector3(posX, posY, 0f);
               GameObject cardObject =  Instantiate(cardPrefab, pos, Quaternion.identity);
                Card card = cardObject.GetComponent<Card>();
                int cardID = cardIDList[cardIndex++];
                card.SetCardID(cardID);
                card.SetAnimalSprite(cardSprites[cardID]);

              
            }
        }
    }
}
