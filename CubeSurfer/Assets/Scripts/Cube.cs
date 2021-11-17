using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    CubeStackHolder holder;
    public bool canBeAdded = true;
    public TrailRenderer trailRend;
    ParticleSystem PS;
    private void Start()
    {
        holder = FindObjectOfType<CubeStackHolder>();
        trailRend = GetComponentInChildren<TrailRenderer>();
        PS = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube") && canBeAdded)
        {
            canBeAdded = false;
            holder.CubeStackAdd(this);
            PS.Play();
        }
        if (other.CompareTag("Obstacle"))
        {
            holder.CubeStackRemove(this);
        }
        if (other.CompareTag("FinalObstacle"))
        {
            StateManager.CurrentState = StateManager.State.EndPlatform;
            holder.CubeStackRemove(this);
            trailRend.emitting = false;
        }
    }
}
