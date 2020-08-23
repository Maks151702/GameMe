﻿using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	static Camera m_camera;
	// Update is called once per frame
  void Start(){
    m_camera = GetComponent<Camera>();
  }
	void Update ()
	{
		if (target)
		{
			Vector3 point = m_camera.WorldToViewportPoint(new Vector3(target.position.x, target.position.y+0.75f,target.position.z));
			Vector3 delta = new Vector3(target.position.x, target.position.y+0.75f,target.position.z) - m_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;


			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

	}
}