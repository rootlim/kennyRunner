using UnityEngine;
using System.Collections;

public class menuAnimation : MonoBehaviour {

    float startposx = 0f;
    float endposx = 0f;

    private Animator ani;

    private int aniPosition = 0;

    void Awake()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    public void vOnMouseDrag()
    {
        
        startposx = Input.mousePosition.x;


        Debug.Log("start position : " + startposx);
    }

    public void vOnMouseUp()
    {
       


        endposx = Input.mousePosition.x;

        Debug.Log("end position : " + endposx);

        if (startposx > endposx)
        {
            aniPosition++;
            
        }
        else
        {
            aniPosition--;
        }

        if (aniPosition < 1)
            aniPosition = 1;

        if (aniPosition > 2)
            aniPosition = 2;


        ani.SetInteger("pos", aniPosition);



        ClearData();
    }

    void ClearData()
    {
        startposx = 0f;
        endposx = 0f;
    }

}
