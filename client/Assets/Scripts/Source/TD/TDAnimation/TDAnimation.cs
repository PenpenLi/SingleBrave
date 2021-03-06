using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Base;


//  TDAnimation.cs
//  Author: Lu Zexi
//  2012-11-29


/// <summary>
/// 2D动画播放组件
/// </summary>
public class TDAnimation : ITDAnimation
{
    private const float FPS = 10;           //动画固定帧
	private float m_fSpeed;                 //播放速度
	private UIAtlas m_cAtlas;              //图集
	private UISprite m_cSprite;            //精灵实体
	private bool m_bIsPlay;                //是否正在播放动画
    private List<UISpriteData> m_lstSprites;   //需要播放的精灵列表
	private TDAnimationMode m_eMode;       //播放模式
    private string m_strCurrentAniName;     //当前播放的动作名

    //更新态变量
    private float m_fLastUpdateTime;        //最后一次渲染更新时间
    private int m_iSpriteIndex;             //当前精灵索引
    private int m_iIncDir;                  //精灵递增方向
	

	public TDAnimation (UIAtlas atlas,UISprite sprite)
	{
		Initialize();
		
		m_cAtlas = atlas;
		m_cSprite = sprite;
        this.m_cSprite.spriteName = this.m_cAtlas.spriteList[0].name;
		m_cSprite.MakePixelPerfect();
	}
	
	
    /// <summary>
    /// 初始化
    /// </summary>
	private void Initialize()
	{
        this.m_strCurrentAniName = "";
		this.m_cAtlas = null;
		this.m_cSprite = null;
		this.m_bIsPlay = false;
        this.m_lstSprites = new List<UISpriteData>();
        this.m_fLastUpdateTime = 0;
		this.m_eMode = TDAnimationMode.Once;
	}
	
	
	/// <summary>
	/// search all sprite name contain 'name' in atlas. add them into lst_SpriteName.
	/// </summary>
	/// <param name='name'>
	/// Name.
	/// </param>
	private void BuildSpriteList(string name)
	{
        this.m_lstSprites.Clear();
		
		if(name == null || name.Equals(""))
		{
			return ;
		}
		
	
		if(m_cAtlas != null)
		{

            List<UISpriteData> atlasSpriteList = m_cAtlas.spriteList;

            foreach (UISpriteData sprite in atlasSpriteList)
			{
				if(sprite.name.StartsWith(name))
				{
                    this.m_lstSprites.Add(sprite);
					
				}
			}
            this.m_lstSprites.Sort(SortNameCompare);
		}

        if (this.m_lstSprites.Count == 0)
		{
			GAME_LOG.ERROR("TDAnimaiton not found any Sprite startwith " + " ' "+ name+"'");
			return;	
		}
	}

    /// <summary>
    /// 排序比较方法--队列以名称最后一个数字升序排列
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private int SortNameCompare(UISpriteData a, UISpriteData b)
    {
        string aInt = "";
        string bInt = "";
        for (int i = a.name.Length - 1; i>=0 ; i-- )
        {
            if (a.name[i] >= '0' && a.name[i] <= '9')
            {
                aInt = a.name[i] + aInt;
            }
            else
            {
                break;
            }
        }

        for (int i = b.name.Length - 1; i>=0 ; i-- )
        {
            if (b.name[i] >= '0' && b.name[i] <= '9')
            {
                bInt = b.name[i] + bInt;
            }
            else
            {
                break;
            }
        }

        if (int.Parse(aInt) > int.Parse(bInt))
        {
            return 1;
        }
        else if (int.Parse(aInt) < int.Parse(bInt))
        {
            return -1;
        }

        return 0;
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    /// <returns></returns>
    public bool Update()
	{
		if( m_cSprite == null) return false;
		if( m_cAtlas == null) return false;
		if( !m_bIsPlay ) return false;

        float disTime = (GAME_TIME.TIME_FIXED() - this.m_fLastUpdateTime);
        if (disTime * FPS * this.m_fSpeed >= 1f)
        {
            if (this.m_iSpriteIndex >= this.m_lstSprites.Count || this.m_iSpriteIndex < 0)
            {
                switch (this.m_eMode)
                { 
                    case TDAnimationMode.Loop:
                        if (this.m_iIncDir < 0)
                            this.m_iSpriteIndex = this.m_lstSprites.Count - 1;
                        else
                            this.m_iSpriteIndex = 0;
                        break;
                    case TDAnimationMode.Once:
                        Stop();
                        this.m_iSpriteIndex = this.m_lstSprites.Count - 1;
                        break;
                    case TDAnimationMode.PingPong:
                        this.m_iIncDir = -this.m_iIncDir;
                        this.m_iSpriteIndex += this.m_iIncDir;
                        break;
                }
            }

            this.m_cSprite.spriteName = this.m_lstSprites[this.m_iSpriteIndex].name;
            
            this.m_iSpriteIndex += this.m_iIncDir;
            this.m_cSprite.MakePixelPerfect();
            this.m_fLastUpdateTime = GAME_TIME.TIME_FIXED();
        }
        else
        { 
            //nothing
        }

        return true;
	}
    
    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="name"></param>
    /// <param name="mode"></param>
    /// <param name="speed"></param>
    public void Play(string name, TDAnimationMode mode, float speed)
	{
        this.m_strCurrentAniName = name;
		BuildSpriteList(name);
        this.m_fSpeed = speed;
		this.m_eMode = mode;
		this.m_bIsPlay = true;

        if (this.m_fSpeed < 0)
        {
            this.m_iIncDir = -1;
            this.m_iSpriteIndex = this.m_lstSprites.Count -1;
            this.m_fSpeed = -this.m_fSpeed;
        }
        else
        {
            this.m_iSpriteIndex = 0;
            this.m_iIncDir = 1;
        }
        m_cSprite.spriteName = m_lstSprites[0].name;
		m_cSprite.MakePixelPerfect();
	}

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="name"></param>
    /// <param name="mode"></param>
    /// <param name="speed"></param>
    public void Play(string name, TDAnimationMode mode)
    {
        Play(name, mode, 1f);
    }

    /// <summary>
    /// 停止播放动画
    /// </summary>
    public void Stop()
	{
		this.m_bIsPlay = false;
	}

    /// <summary>
    /// 是否正在播放
    /// </summary>
    /// <returns></returns>
    public bool IsPlay()
	{
		return m_bIsPlay;
	}

    /// <summary>
    /// 是否正在播放某动画
    /// </summary>
    /// <param name="aniName"></param>
    /// <returns></returns>
    public bool IsPlay(string aniName)
    {
        if (IsPlay() && this.m_strCurrentAniName.CompareTo(aniName) == 0)
        {
            return true;
        }
        return false;
    }

}


