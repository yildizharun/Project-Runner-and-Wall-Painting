using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y + .75f, player.transform.localPosition.z);
    }
}
