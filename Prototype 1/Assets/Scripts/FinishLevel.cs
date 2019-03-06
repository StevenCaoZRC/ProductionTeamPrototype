using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Happs");
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextScene(other.gameObject));
        }
    }

    IEnumerator LoadNextScene(GameObject _gameObject)
    {
        if (_gameObject.GetComponent<PlayerControl>().GetIsLeading())
        {
            _gameObject.GetComponentInChildren<WaterChild>().PlaySwitchAnim();
        }
        else
        {
            _gameObject.GetComponentInChildren<ForestChild>().PlaySwitchAnim();
        }

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("Waterfall");
        yield return new WaitForSeconds(2.0f);

        yield return null;

    }
}
