using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

    GameObject inimigo;

	// Use this for initialization
	void Start () {
        inimigo = transform.Find("Inimigo").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inimigo.AddComponent<Rigidbody2D>();
    }
}
