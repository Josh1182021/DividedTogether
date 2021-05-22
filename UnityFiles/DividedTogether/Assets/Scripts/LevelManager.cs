using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] bool tilesSwitched = false;


    public bool GetTilesSwitched()
    {
        return tilesSwitched;
    }

    public void SetTilesSwitched(bool newTilesSwitched)
    {
        tilesSwitched = newTilesSwitched;
    }

}
