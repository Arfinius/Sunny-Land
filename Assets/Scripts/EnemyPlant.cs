using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant : MonoBehaviour {

    public Transform target;
    public Animator attack;
    public SpriteRenderer SpRe;
    public HpBar hpbar;


    // Use this for initialization
    void Start () {
        SpRe.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.x < target.transform.position.x)
        {
            SpRe.flipX = true;
        }
        else
        {
            SpRe.flipX = false;
        }

		if(Vector2.Distance(transform.position, target.position) < 0.48f)
        {
            attack.SetBool("isCollide", true);
        }
        else
        {
            attack.SetBool("isCollide", false);
        }
    }


    public void OnCollide()
    {
        hpbar.HpSubstractionWhenK();
    }
}
