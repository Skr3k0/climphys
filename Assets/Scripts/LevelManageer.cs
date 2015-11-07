using UnityEngine;
using System.Collections;

public class LevelManageer : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        player = FindObjectOfType<PlayerController>();
	}

    public void respawnPlayer()
    {
        Debug.Log(" - - - Respawn");
        player.transform.position = currentCheckpoint.transform.position;
    }

}
