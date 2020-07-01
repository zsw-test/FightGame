using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
   
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSence(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    

}
