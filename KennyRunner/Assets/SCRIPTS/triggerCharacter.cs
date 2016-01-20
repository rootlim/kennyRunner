using UnityEngine;
using System.Collections;

public class triggerCharacter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "COIN")
        {
            //other.gameObject.transform.
            other.GetComponent<movetoplayer>().blMove = true;
        }
    }
   
}
