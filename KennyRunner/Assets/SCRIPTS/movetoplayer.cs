using UnityEngine;
using System.Collections;

public class movetoplayer : MonoBehaviour {

    public GameObject target;
    float m_fMoveSpeed = 4.0f;

    public bool blMove = false;


	// Update is called once per frame
	void Update () {
        if (blMove)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * m_fMoveSpeed * 3.0f);
            transform.position = pos;
        }
	}
}
