using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string page;
    public GameObject spawner;
    Spawner SpawnerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int value)
    {
        page = "Level" + value;
        SceneManager.LoadScene(page);
        VG.nivelAct = value;
    }

    public void LoadLSeleccionarNave()
    {
        page = "SeleccionarNaves";
        SceneManager.LoadScene(page);
    }
    public void LoadSetting()
    {
        page = "Settings";
        SceneManager.LoadScene(page);
    }
    public void LoadMain()
    {
        page = "Main";
        SceneManager.LoadScene(page);
    }
    public void LoadSeleccionarLvls()
    {
        page = "SeleccionarLvls";
        SceneManager.LoadScene(page);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void SelectShip(int value)
    {
        VG.SpaceShipNum = value;
    }
}
