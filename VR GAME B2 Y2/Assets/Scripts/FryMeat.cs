using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryMeat : MonoBehaviour
{    
    private MeshRenderer meatMat;
    private bool isCooked = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get the colour of the meat
        meatMat = GetComponentInChildren<MeshRenderer>();
    }

    //Put it in the pan
    private void OnTriggerEnter(Collider other)
    {
        //Start frying it
        //Parent them together so that it does not move out of the pan
        if (other.gameObject.layer == 6 && !isCooked)
        {
            StartCoroutine(CookTimer());
            Debug.Log("Started Cooking");
            this.gameObject.transform.SetParent(other.gameObject.transform, true);
        }
    }

    //Once cooked, you can remove the meat
    //Cooked meat will have a different colour
    //Unparent them so that the meat can get removed before it is cooked
    IEnumerator CookTimer()
    {
        yield return new WaitForSeconds(5);
        isCooked = true;
        this.gameObject.transform.SetParent(null);
        meatMat.material.color = new Color32(111, 78, 55, 1);
    }
}
