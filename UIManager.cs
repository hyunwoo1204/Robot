using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    /*public void OnClickStartBtn()
    {
        Debug.Log("click");
        SceneManager.LoadScene("SampleScene");
       // gameObject.GetComponent<Mouse>().enabled = false;
    }*/
    public void btn()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
