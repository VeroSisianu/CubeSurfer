using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontriggerwin : MonoBehaviour
{
    private CubeStackHolder holder;

    private void Start()
    {
        holder = FindObjectOfType<CubeStackHolder>();
    }
    private void OnTriggerEnter(Collider other)
    {
        StateManager.CurrentState = StateManager.State.Won;
        holder.WinConfiguration();
    }
}
