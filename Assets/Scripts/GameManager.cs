using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public static GameManager instance {get; private set;}  // singleton for GameManager
    #endregion

    #region PRIVATE VARIABLES

    #endregion

    public void Awake() {
        if (instance==null) {
            instance = this;
        }
        else {
            Debug.Log("Warning, duplicate game manager.  Destroying one");
            Destroy(instance);
            instance = this;
        }
        DontDestroyOnLoad(instance);
    }
}
