using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartSection : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyObj());
    }
    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(90);
        Destroy(gameObject);
    }
}
