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
        if(other.CompareTag("ObstaclePool"))
        {
            holder.CubeStackRemove(holder.CaughtCubes[0]);
            holder.ObjectsToFallCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObstaclePool"))
        {
            holder.ObjectsToFallCount = 1;
            holder.FallToTheGround();
        }
    }
}
