using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Destroying()
    {
        Destroy(this.gameObject);
    }

}
