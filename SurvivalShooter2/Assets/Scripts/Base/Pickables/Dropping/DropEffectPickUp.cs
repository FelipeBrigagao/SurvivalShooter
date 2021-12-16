using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEffectPickUp : MonoBehaviour
{
    [SerializeField] private GameObject[] _drops;

    public void DropPickUp(float dropPossibility)
    {
        float possibility = Random.Range(0, 100);

       if(possibility <= dropPossibility && _drops.Length > 0)
        {
            int randomDrop = Random.Range(0, _drops.Length - 1);

            Instantiate(_drops[randomDrop], this.transform.position, Quaternion.identity);
            
        }
    }


}
