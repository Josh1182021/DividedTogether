using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSwitcher : MonoBehaviour
{

    LevelManager levelManager;
    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite startingSprite;
    [SerializeField] Sprite endingSprite;

    [SerializeField] int startingLayer;
    [SerializeField] int endingLayer;

    bool wasSwitched;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        gameObject.layer = startingLayer;
        spriteRenderer.sprite = startingSprite;

        wasSwitched = levelManager.GetTilesSwitched();

    }

    // Update is called once per frame
    void Update()
    {
        bool currentSwitched = levelManager.GetTilesSwitched();


        if (currentSwitched != wasSwitched)
        {
            if (currentSwitched == true)
            {
                spriteRenderer.sprite = endingSprite;
                gameObject.layer = endingLayer;
            }
            else
            {
                spriteRenderer.sprite = startingSprite;
                gameObject.layer = startingLayer;
            }


            wasSwitched = currentSwitched;
        }


    }
}
