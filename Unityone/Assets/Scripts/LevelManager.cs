using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectType<Character>();
    }

    public void RespawnPlayer(){
    	Debug.Log ("Player Respawn");
    	player.transform.position=currentCheckpoint.transform.position;
    }
}