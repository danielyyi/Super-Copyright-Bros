using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TSpawnPlayers : MonoBehaviour
{
    //1. Instantiate Characters
    //2. setActive the Images
    //3. change the Text of the names


    public GameObject p1Spawn;
    public GameObject p2Spawn;

    public GameObject waluigi;
    public GameObject miles;
    public GameObject raider;
    public GameObject mando;
    public GameObject peppa;
    public GameObject goku;

    public GameObject p1UI;
    public GameObject p2UI;

    public TMP_Text p1Name;
    public TMP_Text p2Name;

    public int p1Char;
    public int p2Char;

    private GameObject p1;
    private GameObject p2;

    private void Start()
    {
        p1Char = Mathf.RoundToInt(Random.Range(0, 6));
        p2Char = Mathf.RoundToInt(Random.Range(0, 6));
        p1UI.transform.GetChild(p1Char).gameObject.SetActive(true);
        p2UI.transform.GetChild(p2Char).gameObject.SetActive(true);
        switch (p1Char)
        {

            case 0:
                p1 = Instantiate(waluigi, p1Spawn.transform.position, Quaternion.identity);

                p1.GetComponent<PlayerMove>().isPlayer1 = true;
                p1.GetComponent<WaluigiAttack>().player1 = true;

                p1Name.text = "WALUIGI";
                break;
            case 1:
                p1 = Instantiate(miles, p1Spawn.transform.position, Quaternion.identity);

                p1.GetComponent<PlayerMove>().isPlayer1 = true;
                p1.GetComponent<MilesAttack>().player1 = true;

                p1Name.text = "MILES MORALES";
                break;
            case 2:
                p1 = Instantiate(raider, p1Spawn.transform.position, Quaternion.identity);

                p1.GetComponent<PlayerMove>().isPlayer1 = true;
                p1.GetComponent<RaiderAttack>().player1 = true;

                p1Name.text = "RENEGADE RAIDER";
                break;
            case 3:
                p1 = Instantiate(mando, p1Spawn.transform.position, Quaternion.identity);

                p1.GetComponent<PlayerMove>().isPlayer1 = true;
                p1.GetComponent<MandoAttack>().player1 = true;

                p1Name.text = "MANDALORIAN";
                break;
            case 4:
                p1 = Instantiate(peppa, p1Spawn.transform.position, Quaternion.identity);
                p1.transform.GetChild(0).transform.localScale = new Vector3(peppa.transform.localScale.x, peppa.transform.localScale.y, -peppa.transform.localScale.z);

                p1.GetComponent<PeppaMove>().isPlayer1 = true;
                p1.GetComponent<PeppaAttack>().player1 = true;


                p1Name.text = "PEPPA PIG";
                break;
            case 5:
               
                p1 = Instantiate(goku, p1Spawn.transform.position, Quaternion.identity);

                p1.GetComponent<PlayerMove>().isPlayer1 = true;
                p1.GetComponent<GokuAttack>().player1 = true;

                p1Name.text = "GOKU";
                break;
        }

        switch (p2Char)
        {
            case 0:
                p2 = Instantiate(waluigi, p2Spawn.transform.position, Quaternion.identity);

                p2Name.text = "WALUIGI";
                break;
            case 1:
                p2 = Instantiate(miles, p2Spawn.transform.position, Quaternion.identity);

                p2Name.text = "MILES MORALES";
                break;
            case 2:
                p2 = Instantiate(raider, p2Spawn.transform.position, Quaternion.identity);

                p2Name.text = "RENEGADE RAIDER";
                break;
            case 3:
                p2 = Instantiate(mando, p2Spawn.transform.position, Quaternion.identity);

                p2Name.text = "MANDALORIAN";
                break;
            case 4:
                p2 = Instantiate(peppa, p2Spawn.transform.position, Quaternion.identity);
                p2.transform.GetChild(0).transform.localScale = new Vector3(-peppa.transform.localScale.x, peppa.transform.localScale.y, -peppa.transform.localScale.z);

                p2Name.text = "PEPPA PIG";
                break;
            case 5:
                p2 = Instantiate(goku, p2Spawn.transform.position, Quaternion.identity);

                p2Name.text = "GOKU";
                break;
        }
    }

    public void Respawn(bool player1)
    {
        if (player1)
        {
            Vector3 pos = new Vector3(p1Spawn.transform.position.x, p1Spawn.transform.position.y + 4, p1Spawn.transform.position.z);
            p1.GetComponent<PlayerHealth>().isDead = false;
            p1.GetComponent<PlayerHealth>().isCritical = false;
            p1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            p1.transform.position = pos;
        }
        else
        {
            Vector3 pos = new Vector3(p2Spawn.transform.position.x, p2Spawn.transform.position.y + 4, p2Spawn.transform.position.z);
            p2.GetComponent<PlayerHealth>().isDead = false;
            p2.GetComponent<PlayerHealth>().isCritical = false;
            p2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            p2.transform.position = pos;
        }
        
        
    }
}
