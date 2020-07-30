using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class propertyAct : MonoBehaviour
{
    Tweener tweener1;
    Tweener tweener2;
    // Start is called before the first frame update
    void Start()
    {
        tweener1= transform.DOScale(new Vector3(1.2f,0.8f,1f),0.6f);
        tweener1.SetAutoKill(false);
        tweener2 = transform.DOScale(new Vector3(0.8f, 1.2f, 1f), 0.6f);

        tweener2.SetAutoKill(false);
        StartCoroutine(playact());
    }

    IEnumerator playact()
    {
        tweener1.Restart();
        yield return new WaitForSeconds(0.6f);
        tweener2.Restart();
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(playact());
    }
    // Update is called once per frame
    void Update()
    {
      //if(tweener.IsComplete())
      //  {
      //      Debug.Log("??");
      //      tweener.Restart();
      //  }
    }
}
