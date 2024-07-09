using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sectionsDay;
    public GameObject[] sectionsNight;
    public GameObject[] sectionsDesert;
    public GameObject[] sectionsSubway;

    public int zPos = 62;
    public bool CreatingSection=false;
    public int SecNum;
    public GameObject startEnvironmentDay;
    public GameObject startEnvironmentNight;
    public GameObject startEnvironmentDesert;
    public GameObject startEnvironmentSubway;
    private void Awake()
    {

        startEnvironmentDay.SetActive(false);
        startEnvironmentNight.SetActive(false);
        startEnvironmentDesert.SetActive(false);
        startEnvironmentSubway.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //this condition will be allowed when the day map is selected.. and will generate night environment when start the game
        Debug.Log("Map value: " + MainMenuFunction.mapSelection);
        Debug.Log("Section value:" + SecNum);
        if (!CreatingSection && MainMenuFunction.mapSelection==1)
        {
            CreatingSection = true;
            StartCoroutine(GenerateSection());
            startEnvironmentDay.SetActive(true);
            startEnvironmentNight.SetActive(false);

            startEnvironmentDesert.SetActive(false);
            startEnvironmentSubway.SetActive(false);
        }
        //this condition will be allowed when the night map is selected. and will generate night environment when start the game
        if (!CreatingSection && MainMenuFunction.mapSelection == 2)
        {
            CreatingSection = true;
            StartCoroutine(GenerateNightSection());

            startEnvironmentDay.SetActive(false);
            startEnvironmentNight.SetActive(true);

            startEnvironmentSubway.SetActive(false);
            startEnvironmentDesert.SetActive(false);
        }
        if (!CreatingSection && MainMenuFunction.mapSelection == 3)
        {
            CreatingSection = true;
            StartCoroutine(GenerateDesertSection());

            startEnvironmentDay.SetActive(false);
            startEnvironmentNight.SetActive(false);
            startEnvironmentDesert.SetActive(true);

            startEnvironmentSubway.SetActive(false);
        }
        if (!CreatingSection && MainMenuFunction.mapSelection == 4)
        {
            CreatingSection = true;
            StartCoroutine(GenerateSubwaySection());

            startEnvironmentDay.SetActive(false);
            startEnvironmentNight.SetActive(false);
            startEnvironmentDesert.SetActive(false);
            startEnvironmentSubway.SetActive(true);
        }
    }
    IEnumerator GenerateSection() {

        SecNum = Random.Range(0, sectionsDay.Length);
        Instantiate(sectionsDay[SecNum],new Vector3(0,0,zPos),Quaternion.identity);
        zPos += 62;
        yield return new WaitForSeconds(3);
        CreatingSection = false ;
    }
    IEnumerator GenerateNightSection()
    {

        SecNum = Random.Range(0, sectionsNight.Length);
        Instantiate(sectionsNight[SecNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 62;
        yield return new WaitForSeconds(3);
        CreatingSection = false;
    }
    IEnumerator GenerateDesertSection()
    {

        SecNum = Random.Range(0, sectionsDesert.Length);
        Instantiate(sectionsDesert[SecNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 62;
        yield return new WaitForSeconds(3);
        CreatingSection = false;
    }
    float zPosSubway = 477;
    IEnumerator GenerateSubwaySection()
    {
        
        yield return new WaitForSeconds(50);
        Instantiate(sectionsSubway[0], new Vector3(0, 0, zPosSubway), Quaternion.identity);
        zPosSubway += 460;

        CreatingSection = false;
    }

}
