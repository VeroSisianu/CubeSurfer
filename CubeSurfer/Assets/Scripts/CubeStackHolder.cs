using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeStackHolder : MonoBehaviour
{
    public Action<Cube> CubeStackAdd;
    public Action<Cube> CubeStackRemove;
    public StateManager stateManager;
    public Transform ParentOfCubes;
    [SerializeField]
    public List<Cube> CaughtCubes = new List<Cube>();
    public Transform Player;
    public SplineWalker walker;

    private int ObjectsToFallCount = 0;
    private void Start()
    {
        CubeStackAdd += AddCube;
        CubeStackRemove += RemoveCube;
    }
    public void AddCube(Cube cube)
    {
        CaughtCubes.Add(cube);

        cube.transform.parent = ParentOfCubes;
        cube.transform.localPosition = Player.localPosition;
        cube.transform.localRotation = Player.localRotation;
        Player.transform.localPosition += Vector3.up * cube.transform.localScale.y;
        cube.transform.parent = Player;
        for (int i = 0; i < CaughtCubes.Count-1; i++)
        {
            CaughtCubes[i].transform.localPosition -= Vector3.up * cube.transform.localScale.y;
        }
        Debug.Log("addcube");

    }
    public void RemoveCube(Cube cube)
    {
        ObjectsToFallCount++;
        cube.transform.parent = null;
        CaughtCubes.Remove(cube);
        Destroy(cube, 2f);
        Debug.Log("removecube");
        if(CaughtCubes.Count == 1 && StateManager.CurrentState != StateManager.State.EndPlatform)
        {
            StateManager.CurrentState = StateManager.State.Lost;
            walker.enabled = false;
        }
        if (CaughtCubes.Count == 0 && StateManager.CurrentState == StateManager.State.EndPlatform)
        {
            StateManager.CurrentState = StateManager.State.Won;
            walker.enabled = false;
        }
    }

    public void FallToTheGround()
    {
        Player.transform.localPosition = new Vector3(Player.localPosition.x, Player.localPosition.y - ObjectsToFallCount, Player.localPosition.z);
        ObjectsToFallCount = 0;
    }
}
