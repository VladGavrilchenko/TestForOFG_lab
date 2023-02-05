using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProductMover))]
public class Product : MonoBehaviour
{
    private ProductMover _productMover;
    private ProductPart[] _productParts;

    private void Start()
    {
        _productMover = GetComponent<ProductMover>();
        _productParts= GetComponentsInChildren<ProductPart>();
        SetActive(false);
    }

    public void SetActive(bool isActive)
    {
        _productMover.ResetPosition();

        foreach (ProductPart productPart in _productParts)
        {
            productPart.SetActive(isActive);
        }
        gameObject.SetActive(isActive);
    }

}
