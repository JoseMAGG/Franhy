using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Lentes : MonoBehaviour {

    public Animator animator;
    public BoxCollider2D box;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        animator.Play("Arreglar lentes");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.Play("Arreglar lentes");
    }

    private void OnMouseDown()
    {
        animator.Play("Arreglar lentes");
    }

    private void OnMouseEnter()
    {
        animator.Play("Arreglar lentes");
    }
}
