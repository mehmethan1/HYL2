using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Important : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(eve());
    }

    IEnumerator eve()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        yield break;
    }
}
