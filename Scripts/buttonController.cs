using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(updateCoinsCount);  
    }
    void Update()
    {
        if (!gameObject.transform.parent || gameObject.transform.parent.name != "Canvas")
        {
            gameObject.transform.SetParent(canvas.transform);
        }
    }
    void updateCoinsCount()
    {
        canvas.GetComponent<gameController>().coins++;
        Destroy(gameObject);
    }
}
