using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCustomiser : MonoBehaviour
{
    [SerializeField] Color[] allcolors;

    public void SetColor (int colorIndex)
    {
      PlayerController.localPlayer.SetColor(allcolors[colorIndex]);
    }

    public void NextScene(int sceneIndex){
      SceneManager.LoadScene(sceneIndex);
    }

}
