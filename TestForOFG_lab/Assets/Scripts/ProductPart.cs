using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPart : MonoBehaviour
{
    [SerializeField] ProductPartical _productPartical;

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void InstantiateProductPartical()
    {
        GameObject productPartical = Instantiate(_productPartical.gameObject, transform.position, Quaternion.identity);
    }
}
