using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    [SerializeField] KeyCode demonInteractKey = KeyCode.DownArrow;
    [SerializeField] KeyCode angelInteractKey = KeyCode.S;

	[Header("Events")]
	public UnityEvent Activate;

    bool canTrigger = true;

    bool angleTrigger = false;
    bool demonTrigger = false;

    private void Update()
    {
        if(Input.GetKeyDown(angelInteractKey))
            angleTrigger = true;
        if(Input.GetKeyDown(demonInteractKey))
            demonTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.tag == "Player" && canTrigger)
        {

            //layer numbers
            //9 = angel
            //10 = demon
            //Debug.Log("player and can trigger");

            if (collision.gameObject.layer == 9 && angleTrigger)
            {
                Trigger();
            }

            else if (collision.gameObject.layer == 10 && demonTrigger)
            {
                Trigger();
            }

        }

        //Debug.Log(collision.gameObject);
        demonTrigger = false;
        angleTrigger = false;

    }

    private void Trigger()
    {
        Activate.Invoke();
        canTrigger = false;
        StartCoroutine(ResetCanTrigger());
    }

    IEnumerator ResetCanTrigger ()
    {
        yield return new WaitForSeconds(0.05f);
        canTrigger = true;
    }




}
