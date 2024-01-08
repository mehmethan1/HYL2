using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BossHeadAnim : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    bool a = true;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        Idle();
    }
    public void Idle()
    {
        if (a)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos1.position, 0.01f);
            if (transform.position == pos1.position)
            {
                a = false;
            }
            StartCoroutine(ExampleCoroutine());
           

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos2.position, 0.01f);
            if (transform.position == pos2.position)
            {
                a = true;
            }

        }
        
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
    }
}
