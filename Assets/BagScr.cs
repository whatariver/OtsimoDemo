using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
public class BagScr : MonoBehaviour
{
    void Update()
    {
        if(transform.childCount <= 4)
        {
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(200, 200);
        }

        else if (transform.childCount <= 6)
        {
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(150,150) ;

        }
        else
        {
            this.GetComponent<GridLayoutGroup>().cellSize = new Vector2(100, 100);
        }

    }
}
