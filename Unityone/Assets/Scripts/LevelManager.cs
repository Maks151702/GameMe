using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public Charater player;
	public GameObject currentCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Charater>();
    }

    public void RespawnPlayer(){
    	Debug.Log ("Player Respawn");
    	player.transform.position=currentCheckpoint.transform.position;
    }
}