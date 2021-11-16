using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Vector3 direction;
    public float Speed;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition / Screen.width;
        }
        if(Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition / Screen.width;
            direction = endPos - startPos;
        }

        if (Input.GetMouseButton(0))
        {
            startPos = Input.mousePosition / Screen.width;
            var V = new Vector3(direction.x, 0, direction.z);
            var pos = transform.localPosition + (Speed * Time.deltaTime * V);
            var x = Mathf.Clamp(pos.x, -1.6f, 1.6f);
            pos.x = x;
            transform.localPosition = pos; 
        }
    }
}
