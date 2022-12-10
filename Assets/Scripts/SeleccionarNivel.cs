using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarNivel : MonoBehaviour
{
    //imagenes de estrallas
    //lvl1
    public GameObject lvl1Estrella1;
    public GameObject lvl1Estrella2;
    public GameObject lvl1Estrella3;
    public Button btnlvl1;
    //lvl2
    public GameObject lvl2Estrella1;
    public GameObject lvl2Estrella2;
    public GameObject lvl2Estrella3;
    public Button btnlvl2;
    //lvl3
    public GameObject lvl3Estrella1;
    public GameObject lvl3Estrella2;
    public GameObject lvl3Estrella3;
    public Button btnlvl3;
    //lvl4
    public GameObject lvl4Estrella1;
    public GameObject lvl4Estrella2;
    public GameObject lvl4Estrella3;
    public Button btnlvl4;
    //lvl5
    public GameObject lvl5Estrella1;
    public GameObject lvl5Estrella2;
    public GameObject lvl5Estrella3;
    public Button btnlvl5;
    //lvl6
    public GameObject lvl6Estrella1;
    public GameObject lvl6Estrella2;
    public GameObject lvl6Estrella3;
    public Button btnlvl6;


    // Start is called before the first frame update
    void Start()
    {
        // si hemos ganado se reflejará en las variables globales y asi validamos en el select nivel
        // lvl1
        if (VG.lvl1_1Estrella == true) lvl1Estrella1.SetActive(true);
        if (VG.lvl1_2Estrella == true) lvl1Estrella2.SetActive(true);
        if (VG.lvl1_3Estrella == true) lvl1Estrella3.SetActive(true);
        // lvl1
        if (VG.lvl2_1Estrella == true) lvl2Estrella1.SetActive(true);
        if (VG.lvl2_2Estrella == true) lvl2Estrella2.SetActive(true);
        if (VG.lvl2_3Estrella == true) lvl2Estrella3.SetActive(true);
        // lvl1
        if (VG.lvl3_1Estrella == true) lvl3Estrella1.SetActive(true);
        if (VG.lvl3_2Estrella == true) lvl3Estrella2.SetActive(true);
        if (VG.lvl3_3Estrella == true) lvl3Estrella3.SetActive(true);
        // lvl1
        if (VG.lvl4_1Estrella == true) lvl4Estrella1.SetActive(true);
        if (VG.lvl4_2Estrella == true) lvl4Estrella2.SetActive(true);
        if (VG.lvl4_3Estrella == true) lvl4Estrella3.SetActive(true);
        // lvl1
        if (VG.lvl5_1Estrella == true) lvl5Estrella1.SetActive(true);
        if (VG.lvl5_2Estrella == true) lvl5Estrella2.SetActive(true);
        if (VG.lvl5_3Estrella == true) lvl5Estrella3.SetActive(true);
        // lvl1
        if (VG.lvl6_1Estrella == true) lvl6Estrella1.SetActive(true);
        if (VG.lvl6_2Estrella == true) lvl6Estrella2.SetActive(true);
        if (VG.lvl6_3Estrella == true) lvl6Estrella3.SetActive(true);

        //activar botones 
        if (VG.lvl1_1Estrella == true) btnlvl2.interactable = true;
        if (VG.lvl2_1Estrella == true) btnlvl3.interactable = true;
        if (VG.lvl3_1Estrella == true) btnlvl4.interactable = true;
        if (VG.lvl4_1Estrella == true) btnlvl5.interactable = true;
        if (VG.lvl5_1Estrella == true) btnlvl6.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
