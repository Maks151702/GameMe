using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
       levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.name=="Character")
    	{
    		levelManager.currentCheckpoint=gameObject;
    		Debug.Log("Activated CheckPoint" + transform.position);
    	}
    }
}