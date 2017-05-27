using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI; // 需要引入UI的命名空间

public class GameController : MonoBehaviour {
    // 声明控件
    public Image ImaUser; // 用户出牌
    public Image ImaComputer; // 计算机出牌
    public Image ImaWiner; // 显示胜负结果
    //public Text TxtInfoTip; //  信息显示

    // 0表示剪子,1表示布,2表示锤子
    int intUser = 0;// 用户处的"牌" 
    int intComputer = 0;// 计算机的"牌"
    string strJudgeResult = null;// 判断胜负结果

    // 用户点击剪刀
    public void UserClikJianDao(){
        intUser = 0;
        ProcessCard();
    }
    // 用户点击布
    public void UserClikBu() {
        intUser = 1;
        ProcessCard();
    }
    // 用户点击拳头
    public void UserClikQuanTou() {
        intUser = 2;
        ProcessCard();
    }

    /// <summary>
    /// 内部"牌"的逻辑处理
    /// </summary>
    void ProcessCard() {

        // 用户出牌
        switch (intUser) {
            case 0:
                ImaUser.overrideSprite = Resources.Load("Textures/Human/剪刀特写", typeof(Sprite)) as Sprite;
                break;
            case 1:
                ImaUser.overrideSprite = Resources.Load("Textures/Human/布特写", typeof(Sprite)) as Sprite;
                break;
            case 2:
                ImaUser.overrideSprite = Resources.Load("Textures/Human/石头", typeof(Sprite)) as Sprite;
                break;
        }


        // 计算机出牌
        intComputer = ComputerSendCard();
        switch (intComputer) {
            case 0:
                ImaComputer.overrideSprite = Resources.Load("Textures/Computer/计算机_剪刀", typeof(Sprite)) as Sprite;
                break;
            case 1:
                ImaComputer.overrideSprite = Resources.Load("Textures/Computer/计算机_布", typeof(Sprite)) as Sprite;
                break;
            case 2:
                ImaComputer.overrideSprite = Resources.Load("Textures/Computer/计算机_石头", typeof(Sprite)) as Sprite;
                break;
        }

        // 判断胜负
        strJudgeResult = JudgeWiner(intComputer, intUser);

        // 显示胜负结果

        if (strJudgeResult == "平手") {
            ImaWiner.overrideSprite = Resources.Load("Textures/VirtoryInfo/胜利1", typeof(Sprite)) as Sprite;
        }else if(strJudgeResult == "用户赢") {
            ImaWiner.overrideSprite = Resources.Load("Textures/VirtoryInfo/胜利2", typeof(Sprite)) as Sprite;
        } else if(strJudgeResult == "计算机赢"){
            ImaWiner.overrideSprite = Resources.Load("Textures/FailInfo/出错了2", typeof(Sprite)) as Sprite;
        }

    }

    // 打印谁出了什么牌
    void PrintCard(string user, int Card) {
        switch (Card) {
            case 0:
                Console.WriteLine(user + "出的是剪子");
                break;
            case 1:
                Console.WriteLine(user + "你出的是布");
                break;
            case 2:
                Console.WriteLine(user + "你出的是拳头");
                break;
        }
    }

    // 计算器出牌 
    int ComputerSendCard() {
        int intReturnRonDomResult = 0; // 返回随机数值
        System.Random r = new System.Random();
        intReturnRonDomResult = r.Next(3);
        return intReturnRonDomResult;
    }


    /// <summary>
    /// 判断胜负 xml 注释
    /// </summary>
    /// <param name="intComputerCard">计算机的牌</param>
    /// <param name="intUserCard">用户的牌</param>
    /// <returns>返回胜负结果</returns>
    string JudgeWiner(int intComputerCard, int intUserCard) {
        string strResult = null;
        switch (intUserCard) {
            case 0:
                if (intComputerCard == 0) {
                    strResult = "平手";
                } else if (intComputerCard == 1) {
                    strResult = "用户赢";
                } else if (intComputerCard == 2) {
                    strResult = "计算机赢";
                }
                break;
            case 1:
                if (intComputerCard == 0) {
                    strResult = "计算机赢";
                } else if (intComputerCard == 1) {
                    strResult = "平手";
                } else if (intComputerCard == 2) {
                    strResult = "用户赢";
                }
                break;
            case 2:
                if (intComputerCard == 0) {
                    strResult = "用户赢";
                } else if (intComputerCard == 1) {
                    strResult = "计算机赢";
                } else if (intComputerCard == 2) {
                    strResult = "平手";
                }
                break;
        }
        return strResult;
    }
}
