using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManageer levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManageer>();
	}
	
	// Update is called once per frame
	void Update () {
	 
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player") //iba ked prejde hrac nie enemy alebo nieco ine
        {
            levelManager.respawnPlayer();
        }
    }
}
