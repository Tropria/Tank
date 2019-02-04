using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //public GameObject player_TankPrefab;
    //[HideInInspector] public Tank playerTank = new Tank();
    public GameObject titlePrefab;
    [HideInInspector] public GameObject[] titles = new GameObject[6];
    [HideInInspector] public GameObject[] wrongTitles = new GameObject[6];

    public static string functionsString = "11+1=  3-2=  3*3=  7-4=  8+2=  10/2=";
    public static int[] ans = { 12, 1, 9, 3, 10, 5 };
    public static int[] wrongAns = { 2, 4, 7, 8, 11, 13 };


    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;

    public GameObject m_TankPrefab;
    [HideInInspector] public GameObject[] m_Tanks = new GameObject[6];
    [HideInInspector] public static Vector3[] position = {new Vector3(-28+17, 3, 3+24), new Vector3(-18+32, 3, 3-16),new Vector3(-8-10, 3, 3+4),
                                        new Vector3(2+23, 3, 3-25),new Vector3(12+26, 3, 30),new Vector3(22-25, 3, 3+21)};
    [HideInInspector] public GameObject[] friendTanks = new GameObject[6];
    [HideInInspector] public static Vector3[] friendPosition = {new Vector3(-28, 3, 10), new Vector3(-18, 3, -5), new Vector3(-8, 3, -15),
                                        new Vector3(-28, 3, -20), new Vector3(12, 3, 10), new Vector3(32, 13, 35)};
    // Use this for initialization
    void Start () {
        
        SpawnAllTanks();
        Debug.Log("This is an enemy's tank");
    }

    private void SpawnAllTanks()
    {
        //playerTank.m_Instance = Instantiate(player_TankPrefab, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation) as GameObject;
        // For all the tanks enemies
 
        //for(int i=0; i<5; i++)
        //{
          //  m_Tanks[i].m_Instance =
          //  Instantiate(m_TankPrefab, m_Tanks[i].transform.position, m_Tanks[i].transform.rotation) as GameObject;
        //}

        //m_Tanks[0] =
        //    Instantiate(m_TankPrefab, SpawnPoint2.transform.position, SpawnPoint2.transform.rotation) as GameObject;
        for(int i=0; i<6; i++)
        {
            m_Tanks[i] =
           Instantiate(m_TankPrefab, position[i], Quaternion.identity) as GameObject;
            titles[i] =
                Instantiate(titlePrefab, position[i], Quaternion.identity) as GameObject;
            titles[i].GetComponent<TextMesh>().text= "" + ans[i];
        }

        for (int i=0; i<6; i++)
        {
            Debug.Log("Now i is " + i);
            wrongTitles[i] =
                Instantiate(titlePrefab, friendPosition[i], Quaternion.identity) as GameObject;
            wrongTitles[i].GetComponent<TextMesh>().text = "" + wrongAns[i];
            friendTanks[i] = Instantiate(m_TankPrefab, friendPosition[i], Quaternion.identity) as GameObject;
            
        }
        
        //m_Tanks[1] =
        //    Instantiate(m_TankPrefab, new Vector3(-10, 3, 3), Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //Debug.Log("Current health: " + m_Tanks[0].GetComponent<AITank>().health);
        if (m_Tanks[0]==null&& m_Tanks[1] == null && m_Tanks[2] == null && m_Tanks[3] == null && m_Tanks[4] == null && m_Tanks[5] == null)
        {
            Application.LoadLevel("victory");
        }
        if(friendTanks[0]==null || friendTanks[1] == null || friendTanks[2] == null || friendTanks[3] == null || friendTanks[4] == null)
        {
            Application.LoadLevel("defeat");
        }

        
        /*
        bool temp = false;
        for(int i=0; i<6; i++)
        {
            if (m_Tanks[i] == null) { }
            else { temp=}
        }*/

    }
}
