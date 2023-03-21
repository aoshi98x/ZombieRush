using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItenManager : MonoBehaviour
{
    [SerializeField]private GameObject PosionItemVerde;
    [SerializeField] private TextMeshProUGUI contadorTextoVerde;
    [SerializeField] private int contadorItenmVerdeInicial = 0;
    [SerializeField] private int contadorItenmVerde = 0;
    [SerializeField] private GameObject PosionItemAzul;
    [SerializeField] private TextMeshProUGUI contadorTextoAzul;
    [SerializeField] private int contadorItenmAzulInicial = 0;
    [SerializeField] private int contadorItenmAzul = 0;
    [SerializeField] private GameObject PosionItemRojo;
    [SerializeField] private TextMeshProUGUI contadorTextoRojo;
    [SerializeField] private int contadorItenmRojoInicial = 0;
    [SerializeField] private int contadorItenmRojo = 0;
    void Update()
    {
        if (contadorTextoVerde != null)
        {
            contadorTextoVerde.text = contadorItenmVerde.ToString();
        }
        if (contadorTextoAzul != null)
        {
            contadorTextoAzul.text = contadorItenmAzul.ToString();
        }
        if (contadorTextoRojo != null)
        {
            contadorTextoRojo.text = contadorItenmRojo.ToString();
        }
    }
    void Start()
    {

        //GameObject Plataforma = GameObject.FindWithTag("ManagerPlataform");


        contadorItenmVerde = contadorItenmVerdeInicial = 0;
        ;


        if (contadorTextoVerde != null)
        {
            contadorTextoVerde.text = contadorItenmVerde.ToString();
        }

    }
    public void DisminuirItenmVerde()
    {
        if (contadorItenmVerde >= 1)
        {
            contadorItenmVerde--;
            if (contadorTextoVerde != null)
            {
                contadorTextoVerde.text = contadorItenmVerde.ToString();
            }
            if (contadorItenmVerde <= 1)
            {
                PosionItemVerde.SetActive(false);
            }
        }

    }
    public void AumentarItenmVerde()
    {
        contadorItenmVerde++;
        if (contadorTextoVerde != null)
        {
            contadorTextoVerde.text = contadorItenmVerde.ToString();
        }
        if (contadorItenmVerde >= 0)
        {
            PosionItemVerde.SetActive(true);
        }


    }
    public void AumentarItenmAzul()
    {
        contadorItenmAzul++;
        if (contadorTextoAzul != null)
        {
            contadorTextoAzul.text = contadorItenmAzul.ToString();
        }
        if (contadorItenmAzul >= 0)
        {
            PosionItemAzul.SetActive(true);
        }


    }
    public void AumentarItenmRojo()
    {
        contadorItenmRojo++;
        if (contadorTextoRojo != null)
        {
            contadorTextoRojo.text = contadorItenmRojo.ToString();
        }
        if (contadorItenmRojo >= 1)
        {
            PosionItemRojo.SetActive(true);
        }


    }
    public void DisminuirItenmAzul()
    {
        if (contadorItenmAzul >= 0)
        {
            contadorItenmAzul--;
            if (contadorTextoAzul != null)
            {
                contadorTextoAzul.text = contadorItenmAzul.ToString();
            }
            if (contadorItenmAzul == 0)
            {
                PosionItemAzul.SetActive(false);
            }
        }
    }
    public void DisminuirItenmRojo()
        {
            if (contadorItenmRojo >= 1)
            {
            contadorItenmRojo--;
                if (contadorTextoRojo != null)
                {
                contadorTextoRojo.text = contadorItenmRojo.ToString();
                }
                if (contadorItenmRojo >= 1)
                {
                PosionItemRojo.SetActive(false);
                }
            }

        }

}

