using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour
{
    private IEnumerable<ICustomUpdate> customUpdate;

    void Start()
    {
        InvokeRepeating("customUpdate", 0, 1);
    }

    private void CustomUpdate()
    {

    }

}
