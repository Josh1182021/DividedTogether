using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    //Collider2D[] currentColliders;

    [SerializeField] int LevelUnlocked = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        int playerCount = 0;
        //int colliderCount = 0;

        //Debug.Log(transform.localScale);
        //Debug.Log(transform.localScale / (float)1.5);

        BoxCollider2D boxColl = GetComponent<BoxCollider2D>();
        Vector2 boxSize = (boxColl.size);

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll
            (gameObject.transform.position, boxSize, 0);

        //, m_LayerMask

        foreach (var collider in hitColliders)
        {

            //Debug.Log(collider.gameObject);

            if (collider.gameObject.tag == "Player")
            {
                playerCount += 1;
            }
        }

        //Debug.Log(playerCount);

        if (playerCount == 2)
        {
            MyGameManager myGameManager = FindObjectOfType<MyGameManager>();

            if (myGameManager)
            {
                myGameManager.UnlockLevel(LevelUnlocked);
            }
            else
            {
                Debug.Log("No GameManager Found!!!");
            }

            FindObjectOfType<MySceneManager>().LoadLevelSelect();
        }

    }


}
