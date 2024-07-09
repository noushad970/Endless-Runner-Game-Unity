using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyClone : MonoBehaviour
{
    string parentName;
    public GameObject player1;
    public GameObject player2;
    public GameObject clone;
    
    private void Start()
    {
        parentName = transform.name;
    }

    // Update is called once per frame
    //while player pass a environment section clone the section clone will automatically delete.
    void Update()
    {
        Vector3 playerPosition = player1.transform.position;
        Vector3 clonePosition = clone.transform.position;

        if (playerPosition.z > clonePosition.z+62 && parentName=="Section(Clone)")
        {
            StartCoroutine(DestroyObj());
        }
        Vector3 playerPosition2 = player2.transform.position;
        Vector3 clonePosition2 = clone.transform.position;

        if (playerPosition2.z > clonePosition2.z + 62 && parentName == "Section(Clone)")
        {
            StartCoroutine(DestroyObj());
        }


    }
    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
