using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;
    public NodeManager nodeManager;
    public GameObject DMGTexPrefab;
    public GameObject DeathTexPrefab;
    public RectTransform mainBarRectTrf;
    public RectTransform subBarRectTrf;
    public GameOver GameOverObj;

    public int hp;
    public int maxHp;
    public bool death;
    private void Start() {
        
        DMGTexPrefab = (GameObject)Resources.Load("DMGText");
        DeathTexPrefab = (GameObject)Resources.Load("DeathText");
    }
    public void Attack(int dmg){
        gameManager.enemys[0].HitReaction(dmg,1);
        nodeManager.specialActing =true;
    }
    public void Heal(int value){
        hp = Mathf.Clamp(value+hp,0,maxHp);
    }
    public void Change(int dmg){
        gameManager.enemys[0].HitReaction(dmg,1);
        nodeManager.specialActing =true;
    }
    public bool Hurt(int DMG,int element){
        this.hp -= (int)(DMG * element);
        Debug.Log("[DMGLog]" + " Object:" + gameObject.name + " Damage:" + DMG + " AfterHP:" + this.hp);
        return this.hp < 0;

    }
    private void Update() {
        
        mainBarRectTrf.sizeDelta = new Vector2(Mathf.Clamp((float)(hp)/(float)(maxHp)*125,0,125),10);
        if(subBarRectTrf.sizeDelta.x > 0&&mainBarRectTrf.sizeDelta.x < subBarRectTrf.sizeDelta.x)subBarRectTrf.sizeDelta -= new Vector2(15f*Time.deltaTime,0);
    }
    public int HitReaction(int damage, int element){
        if (Hurt(damage,element)){
            gameObject.GetComponent<Animator>().Play("Death");
            GameObject DMGTex = Instantiate(DeathTexPrefab,Vector2.zero,Quaternion.identity,GameObject.Find("Canvas").transform);
            DMGTex.GetComponent<TextMeshProUGUI>().text = damage.ToString();
            Vector2 screenPos =  RectTransformUtility.WorldToScreenPoint(Camera.main,transform.position);
            DMGTex.GetComponent<RectTransform>().localPosition = screenPos;
            death = true;
            Destroy(gameObject,2f);
            GameOverObj.gameObject.SetActive(true);
            StartCoroutine(GameOverObj.Gameover());
            return 0;
        }else{
            gameObject.GetComponent<Animator>().Play("Hurt");
            Destroy(nodeManager.magicObj);
            GameObject DMGTex = Instantiate(DMGTexPrefab,Vector2.zero,Quaternion.identity,GameObject.Find("Canvas").transform);
            DMGTex.GetComponent<TextMeshProUGUI>().text = damage.ToString();
            Vector2 screenPos =  RectTransformUtility.WorldToScreenPoint(Camera.main,transform.position);
            DMGTex.GetComponent<RectTransform>().position = screenPos;
            Debug.Log(DMGTex.GetComponent<RectTransform>().anchoredPosition);

            nodeManager.Rigid = true;
        }
        return this.hp;
    }
}
