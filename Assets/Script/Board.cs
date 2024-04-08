using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    void Start()
    {
        InitBoard();
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

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                float posY = (row - (int)(rowCount / 2 )) * spaceY;
                float posX = (col - (int)(columnCount / 2)) * spaceX + (spaceX / 2);

                Vector3 pos = new Vector3(posX, posY, 0f);
                Instantiate(cardPrefab, pos, Quaternion.identity);
            }
        }
    }
}
