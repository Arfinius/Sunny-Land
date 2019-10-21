using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public HpBar hp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player collide with the star, it addits hp.
        if (collision.name != "Player") { return; }

        hp.HpAddition();

        Destroy(gameObject);
    }
}
