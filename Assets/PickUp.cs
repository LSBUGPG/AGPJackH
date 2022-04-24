using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    int keyCount = 0;
    public int keyToCollect;
    public Animator[] doorAnims;
    public GameObject nextLevel;
    public Timer timer;
    private int doorIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            
            Destroy(other.gameObject);
            keyCount += 1;
            if (keyCount == keyToCollect)
            {
                doorAnims[doorIndex].SetTrigger("DoorOpen");
                timer.StopTimer();
                keyCount = 0;
                doorIndex += 1;
                if (doorIndex >= doorAnims.Length)
                {
                    doorIndex = 0;
                }
            }
        }
        if (other.CompareTag("NextLevel"))
        {
            nextLevel.SetActive(true);
        }
    }
}
