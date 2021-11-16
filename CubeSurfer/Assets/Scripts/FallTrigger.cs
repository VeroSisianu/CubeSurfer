using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public CubeStackHolder holder;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            holder.FallToTheGround();
            Debug.Log("called");
        }
    }
}
