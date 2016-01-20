using UnityEngine;
using System.Collections;

public class playerTouch : MonoBehaviour {

    /*
             switch (hit.gameObject.tag)
            {
                case "COIN":
                    Destroy(hit.gameObject);
                    coinManager.coin += 1;
                    break;
                case "BIGCOIN":
                    Destroy(hit.gameObject);
                    coinManager.coin += 10;
                    break;
                case "DEAD":              
                    break;
                default:
                    break;
            }
     */

    void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "COIN":
                Destroy(other.gameObject);
                coinManager.coin += 1;
                break;
            case "BIGCOIN":
                Destroy(other.gameObject);
                coinManager.coin += 10;
                break;
            case "DEAD":
                GameObject.Find("UI").GetComponent<ShowPanels>().ShowPausePanel();
                break;
            default:
                break;
        }
    }
}
