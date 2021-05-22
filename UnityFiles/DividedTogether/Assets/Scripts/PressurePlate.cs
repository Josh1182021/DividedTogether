using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            levelManager.SetTilesSwitched(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            levelManager.SetTilesSwitched(false);
        }
    }


}
