using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohonManager : MonoBehaviour
{
    public static PohonManager instance;

    public int rangePohonRotate = 20;

    PlayerController playerController;
    public new Transform camera;
    public PohonController[] pohons;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        playerController = PlayerController.instance;

        pohons = FindObjectsOfType<PohonController>();
    }
    void Update()
    {
        for (int i = 0; i < pohons.Length; i++)
        {
            RangeToRotate(i);
        }
    }



    void RangeToRotate(int number)
    {
        if (number < pohons.Length)
        {
            if (Vector3.Distance(playerController.transform.position, pohons[number].transform.position) < rangePohonRotate)
            {
                var pohon = pohons[number].transform;

                pohon.GetChild(0).eulerAngles = new Vector3(0, camera.eulerAngles.y, 0);

                //Rotate shadow
                if (pohon.GetChild(0).eulerAngles.y > 270 || pohon.GetChild(0).eulerAngles.y < 90)
                {
                    pohon.GetChild(1).transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    pohon.GetChild(1).transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }
        else if (number >= pohons.Length)
        {
            Debug.LogWarning("pohonnya kurang, total pohon : " + pohons.Length);
        }
        else
        {
            Debug.LogWarning("rotate di update kurang, total pohon : " + pohons.Length);
        }

        
    }
}
