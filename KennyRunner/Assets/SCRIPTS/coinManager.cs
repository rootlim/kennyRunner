using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class coinManager : MonoBehaviour {

    public static int coin;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        coin = 0;
    }

    void Update()
    {
        text.text = "$: " + coin;
    }
	
}
