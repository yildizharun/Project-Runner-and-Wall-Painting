﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_Manager : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
