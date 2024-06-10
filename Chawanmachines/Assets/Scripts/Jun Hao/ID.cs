using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ID : MonoBehaviour
{
    public new TextMeshProUGUI name;
    public TextMeshProUGUI idNumber;
    public TextMeshProUGUI expiryDate;
    public GameObject idPicture;
    public GameObject platoonPicture;
    private void Start()
    {
        Vector3 target = transform.TransformPoint(Vector3.forward * 0.5f);
        StartCoroutine(animatingID(target));
    }
    
    IEnumerator animatingID(Vector3 targetPosition)
    {
        Vector3 startposition = transform.position;
        float timeElapsed = 0;
        while(timeElapsed < 0.1f)
        {
            transform.position = Vector3.Lerp(startposition, targetPosition, timeElapsed / 0.1f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
