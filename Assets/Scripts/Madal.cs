using UnityEngine;
using UnityEngine.UI;

public class Madal : MonoBehaviour
{
    public Sprite Metal, Bronz, Silver, Gold;
    Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

   
    void Update()
    {
       
        int gameScore = GameMenager.gameScore;

        if (gameScore >0 && gameScore <=3 )
        {
            img.sprite = Metal;
        }
       else if (gameScore > 3 && gameScore <= 5)
        {
            img.sprite = Bronz;
        }
        else if (gameScore > 5 && gameScore <= 7)
        {
            img.sprite = Silver;    
        }
        else if (gameScore > 7)
        {
            img.sprite = Gold;
        }

    }

}
