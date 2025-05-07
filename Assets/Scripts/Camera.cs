using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public float cameraSpeed;
    public float verticalDistance = 4.5f;
    public float horizontalDistance = 6.0f;
    Vector3 targetPos;
    
    private void FixedUpdate()
    {
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        Vector3 targetPosX = new Vector3(target.transform.position.x, 0, 0);
        Vector3 targetPosY = new Vector3(0, target.transform.position.y, 0);
        RaycastHit2D rightHit = Physics2D.Raycast(target.transform.position, Vector3.right, horizontalDistance, LayerMask.GetMask("Wall"));
        RaycastHit2D leftHit = Physics2D.Raycast(target.transform.position, Vector3.left, horizontalDistance, LayerMask.GetMask("Wall"));
        RaycastHit2D upHit = Physics2D.Raycast(target.transform.position, Vector3.up, verticalDistance, LayerMask.GetMask("Wall"));
        RaycastHit2D downHit = Physics2D.Raycast(target.transform.position, Vector3.down, verticalDistance, LayerMask.GetMask("Wall"));

        if (rightHit || leftHit)
        {
            targetPosX = new Vector3(transform.position.x, 0, 0);
        }
        if (upHit  || downHit)
        {
            targetPosY = new Vector3(0, transform.position.y, 0);
        }
        targetPos = new Vector3(targetPosX.x, targetPosY.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, cameraSpeed);
    }

    
}
