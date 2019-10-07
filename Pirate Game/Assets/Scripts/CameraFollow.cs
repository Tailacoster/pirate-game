using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] bool cameraFollowEnabled = true;
    [SerializeField] Player target;

	void Start()
	{

	}
	
	void Update()
	{
        if (cameraFollowEnabled)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
    }
}