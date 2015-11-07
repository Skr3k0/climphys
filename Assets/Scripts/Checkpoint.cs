using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

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
        if (other.name == "Player") 
        {
            // gameobjekt akutalny object na ktr. je script attachnuty
            levelManager.currentCheckpoint = gameObject;
        }
    }
}
