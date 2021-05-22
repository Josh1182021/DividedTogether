using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{

    [SerializeField] Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        int levelUnlocked = FindObjectOfType<MyGameManager>().GetLevelUnlocked();


        for (int i = 0; i < buttons.Length; i++)
        {
            if (i >= levelUnlocked)
            {
                buttons[i].interactable = false;
            }
        }

    }


}
