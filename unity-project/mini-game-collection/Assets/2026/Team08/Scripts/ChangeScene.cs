using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, IPointerClickHandler
{

    TextMeshPro StartText;

    // Start is called before the first frame update
    void Start()
    {
        StartText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

  public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(6);
    }

}
