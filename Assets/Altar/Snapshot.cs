using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Snapshot : MonoBehaviour
{
   public Camera snapCam;
   public int reswidth=1080;
    public int resheight=1080;
     void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture==null)
        {
            snapCam.targetTexture = new RenderTexture(reswidth, resheight, 24);
        }
        else
        {
            reswidth = snapCam.targetTexture.width;
            resheight = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    
    string snapShotname()
    {
        return string.Format("{0}/snapshots/Snap_{1}x{2}_{3}.png",Application.dataPath,
            reswidth,resheight,System
            .DateTime.Now.ToString("yyyy-mm-dd-ss"));
    }
    public void snapshot()
    {
        snapCam.gameObject.SetActive(true);

    }
    public void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D Snapimage = new Texture2D(reswidth, resheight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            Snapimage.ReadPixels(new Rect(0, 0, reswidth, resheight),0,0);
            byte[] bytes = Snapimage.EncodeToPNG();
            string fileName = snapShotname();
            System.IO.File.WriteAllBytes(fileName, bytes);
            Debug.Log(" made by : https://www.linkedin.com/in/eslam-zakiiv/");
            snapCam.gameObject.SetActive(false);


        }
    }
}
