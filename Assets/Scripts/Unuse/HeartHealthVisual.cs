using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealthVisual : MonoBehaviour
{
    [SerializeField] 
    private Sprite heartSprite0;
    private Sprite heartSprite1;
    private Sprite heartSprite2;

    private List<HeartImage> heartImageList;

    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }

    private void Start()
    {
        HeartHealthSystem heartHealthSystem = new HeartHealthSystem(0);
        CreateHeartImage(new Vector2(0,0));
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition)
    {
        //Create GameObject
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        //Set as child of this transform
        heartGameObject.transform.parent = transform;
        heartGameObject.transform.localPosition = Vector3.zero;

        //Locate and Size heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(10,10);

        //Set heart sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heartSprite0;

        //store image in class
        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImageList.Add(heartImage);

        return heartImage;

    }

    //Represents a single heart
    public class HeartImage
    {
        private Image heartImage;
        private HeartHealthVisual heartHealthVisual;

        public HeartImage(HeartHealthVisual heartHealthVisual, Image heartImage)
        {
            this.heartHealthVisual = heartHealthVisual;
            this.heartImage = heartImage;
        }

        public void SetHeartFragments(int fragments)
        {
            switch (fragments)
            {
                case 0: heartImage.sprite = heartHealthVisual.heartSprite0; break;
                case 1: heartImage.sprite = heartHealthVisual.heartSprite1; break;
                case 2: heartImage.sprite = heartHealthVisual.heartSprite2; break;
            }
        }
    }
}
