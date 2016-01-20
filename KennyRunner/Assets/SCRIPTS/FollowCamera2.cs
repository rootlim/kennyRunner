using UnityEngine;
using System.Collections;

public class FollowCamera2 : MonoBehaviour {

    void FixUpdate()
    {

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(transform.position.x-3f, transform.position.y+0.5f, transform.position.z);
    }
}
