using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Painter : MonoBehaviour
{
    public bool isPainting = false;
    public RaycastHit hit;
    int layerMask = 1 << 8;

    public TextMeshProUGUI textMeshPro;
    float percentage;

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            if (hit.transform.tag != "Mask")
            {
                if (isPainting)
                {
                    textMeshPro.text = (int)percentage + "%";
                    if (percentage <= 99.9f)
                    {
                        percentage += 1.15f;
                    }
                    if (percentage > 99.9f)
                    {
                        percentage = 100;
                    }

                    ObjectPooler.Instance.spawnObjectFromPool("Mask", hit.point, Quaternion.identity);
                }
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPainting = true;

            //Instantiate(obj, hit.point, Quaternion.identity);
            //Debug.Log("a");
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPainting = false;
        }
    }
}
