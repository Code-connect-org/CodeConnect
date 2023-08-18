using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //メンバー
    public EnemyDataSO data_origin;

    //コンストラクタ
    public Enemy(EnemyDataSO _data)
    {
        this.data_origin = _data;
    }
}
public class BattleEnemy : BattleCharacter
{
    //メンバー
    private float[] weakness;
    private int spd;
    private int EXP;
    private int frame;
    public EnemyData data;
    public int kind;
    GameObject DMGTexPrefab;
    GameObject DeathTexPrefab;
    GameObject canvas;
    public EnemyController enemyController;
    public RectTransform mainBarRectTrf;
    public RectTransform subBarRectTrf;
    private RectTransform hpBar;
    //コンストラクタ
    public void Start(){
        this.Name = data.Name;
        this.Name += kind;
        this.weakness = new float[] { 2, 2, 2, 2 };
        CalculateStatus(data.hp, data.atk, data.def, data.spd, data.grow, data.EXP);
        CalculateFrame(data.frame);
        this.hp = this.hp_max;

        DMGTexPrefab = (GameObject)Resources.Load("DMGText");
        DeathTexPrefab = (GameObject)Resources.Load("DeathText");
        canvas = GameObject.Find("Canvas");
        enemyController = gameObject.GetComponent<EnemyController>();

        hpBar = Instantiate((GameObject)Resources.Load("HPBarPrefab"),canvas.transform).GetComponent<RectTransform>();
        mainBarRectTrf = hpBar.transform.GetChild(1).GetComponent<RectTransform>();
        subBarRectTrf = hpBar.transform.GetChild(0).GetComponent<RectTransform>();
    }
    
    private void Update() {
        hpBar.position = RectTransformUtility.WorldToScreenPoint(Camera.main,transform.position);
        mainBarRectTrf.sizeDelta = new Vector2(Mathf.Clamp((float)hp/(float)hp_max*125,0,125),10);
        if(subBarRectTrf.sizeDelta.x > 0&&mainBarRectTrf.sizeDelta.x < subBarRectTrf.sizeDelta.x)subBarRectTrf.sizeDelta -= new Vector2(15f*Time.deltaTime,0);
    }
    //メソッド(外部からアクセス可能)
    public override int Attack(){
        int atk_final = this.atk * 2;
        animator.Play("Enemy Attack 1");
        return atk_final;
    }
    public override int HitReaction(int damage, int element){
        if (HitDamage(damage, weakness[element])){
            animator.Play("Enemy Death");
            GameObject DMGTex = Instantiate(DeathTexPrefab,Vector2.zero,Quaternion.identity,canvas.transform);
            DMGTex.GetComponent<TextMeshProUGUI>().text = damage.ToString();
            Vector2 screenPos =  RectTransformUtility.WorldToScreenPoint(Camera.main,transform.position);
            DMGTex.GetComponent<RectTransform>().position = screenPos;
            enemyController.playerManager.gameManager.enemys.RemoveAt(0);
            for(int i = 0;i < enemyController.playerManager.gameManager.enemys.Count;i ++){
                enemyController.playerManager.gameManager.enemys[i].transform.position = new Vector3(-3-i,0);
                Debug.Log(enemyController.playerManager.gameManager.enemys[i].transform.position);
            }
            Destroy(gameObject,2f);
            Destroy(hpBar.gameObject);
            Destroy(this);
            return 0;
        }else{
            animator.Play("Enemy Hit");
            GameObject DMGTex = Instantiate(DMGTexPrefab,Vector2.zero,Quaternion.identity,canvas.transform);
            DMGTex.GetComponent<TextMeshProUGUI>().text = damage.ToString();
            Vector2 screenPos =  RectTransformUtility.WorldToScreenPoint(Camera.main,transform.position);
            DMGTex.GetComponent<RectTransform>().position = screenPos;

            enemyController.Rigid = true;
        }
        return this.hp;
    }

    //メソッド(外部からアクセス不可)
    private void CalculateStatus(int hitpoint, int attack, int defence, int speed, float grows, int experience) {
        this.hp_max = (int)(hitpoint * (1 + this.lv * grows));
        this.atk = (int)(attack * (1 + this.lv * grows));
        this.def = (int)(defence * (1 + this.lv * grows));
        this.spd = (int)(speed * (1 + this.lv * grows));
        this.EXP = (int)(experience * (1 + this.lv * grows * 5));
    }
    private void CalculateFrame(int temp_frame){
        this.frame = (int)(Mathf.Exp(Mathf.Sqrt(this.spd + 12) / -5) * temp_frame * 2);
    }
    
}
