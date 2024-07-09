using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sectionsDay;
    public GameObject[] sectionsNight;
    public GameObject[] sectionsDesert;
    public int zPos = 62;
    public bool CreatingSection=false;
    public int SecNum;
    public GameObject startEnvironmentDay;
    public GameObject startEnvironmentNight;
    public GameObject startEnvironmentDesert;
    private void Awake()
    {

        startEnvironmentDay.SetActive(false);
        startEnvironmentNight.SetActive(false);
        startEnvironmentDesert.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //this condition will be allowed when the day map is selected.. and will generate night environment when start the game
        Debug.Log("Map value: " + MainMenuFunction.mapSelection);
        if (!CreatingSection && MainMenuFunction.mapSelection==1)
        {
            CreatingSection = true;
            StartCoroutine(GenerateSection());
            startEnvironmentDay.SetActive(true);
            startEnvironmentNight.SetActive(false);

            startEnvironmentDesert.SetActive(false);
        }
        //this condition will be allowed when the night map is selected. and will generate night environment when start the game
        if (!CreatingSection && MainMenuFunction.mapSelection == 2)
        {
            CreatingSection = true;
            StartCoroutine(GenerateNightSection());

            startEnvironmentDay.SetActive(false);
            startEnvironmentNight.SetActive(true);
            startEnvironmentDesert.SetActive(false);
        }
        if (!CreatingSection && MainMenuFunction.mapSelection == 3)
        {
            CreatingSection = true;
            StartCoroutine(GenerateDesertSection());

            startEnvironmentDay.SetActive(false);
            startEnvironmentNight.SetActive(false);
            startEnvironmentDesert.SetActive(true);
        }
    }
    IEnumerator GenerateSection() {

        SecNum = Random.Range(0, 3);
        Instantiate(sectionsDay[SecNum],new Vector3(0,0,zPos),Quaternion.identity);
        zPos += 62;
        yield return new WaitForSeconds(3);
        CreatingSection = false ;
    }
    IEnumerator GenerateNightSection()
    {

        SecNum = Random.Range(0, 3);
        Instantiate(sectionsNight[SecNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 62;
        yield return new WaitForSeconds(3);
        CreatingSection = false;
    }
    IEnumerator GenerateDesertSection()
    {

        SecNum = Random.Range(0, 3);
        Instantiate(sectionsDesert[SecNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 62;
        yield return new WaitForSeconds(3);
        CreatingSection = false;
    }

}
