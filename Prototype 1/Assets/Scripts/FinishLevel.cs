using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    GameObject m_particles;
    // Start is called before the first frame update
    void Start()
    {
        m_particles = transform.GetChild(2).gameObject;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextScene(other.gameObject));
        }
    }

    IEnumerator LoadNextScene(GameObject _gameObject)
    {
        m_particles.SetActive(false);
        _gameObject.GetComponent<PlayerMovement>().Rotate(Camera.main.gameObject);
                yield return new WaitForSeconds(0.5f);

        if (_gameObject.GetComponent<PlayerControl>().GetIsLeading())
        {
            _gameObject.GetComponentInChildren<WaterChild>().GetComponent<Animator>().SetTrigger("Win");
        }
        else
        {
            _gameObject.GetComponentInChildren<ForestChild>().PlaySwitchAnim();
        }

        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene(LevelLoader.GetInstance().GetLvlName());
        //yield return new WaitForSeconds(2.0f);

        yield return null;

    }
}
