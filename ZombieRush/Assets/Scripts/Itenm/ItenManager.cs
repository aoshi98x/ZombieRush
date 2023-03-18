using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItenManager : MonoBehaviour
{
    public GameObject PosionItem;
    public TextMeshProUGUI contadorTexto;
    public int contadorItenmInicial = 0;
    public int contadorItenm = 0;
    void Start()
    {

        //GameObject Plataforma = GameObject.FindWithTag("ManagerPlataform");


        contadorItenm = contadorItenmInicial = 0;
        ;


        if (contadorTexto != null)
        {
            contadorTexto.text = contadorItenm.ToString();
        }

    }
    public void DisminuirItenm()
    {
        if (contadorItenm >= 1)
        {
            contadorItenm--;
            if (contadorTexto != null)
            {
                contadorTexto.text = contadorItenm.ToString();
            }
            if (contadorItenm == 0)
            {
                PosionItem.SetActive(false);
            }
        }

    }
    public void AumentarItenm()
    {
        contadorItenm++;
        if (contadorTexto != null)
        {
            contadorTexto.text = contadorItenm.ToString();
        }
        if (contadorItenm == 0)
        {
            PosionItem.SetActive(false);
        }


    }
}
