using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_0323_51015Game
{
    class Program//酒拳程式Ver.7.0
    {
        enum Speaker
        {
            computer
            , player
        }
        static void Main(string[] args)
        {
            int com_left_hand = 0, com_right_hand = 0;//電腦左右手
            int user_left_hand = 0, user_right_hand = 0;//玩家左右手
            int total = 0;//拳語
            int victory = 0;//勝局
            string input = "";
            Speaker statu = Speaker.computer;
            Random random = new Random();
            
            while (true)
            {
                Console.Clear();
                statu = (Speaker)random.Next(0, 2);
                Console.WriteLine($"\n隨機決定先後：{statu} 先\n");
                Console.WriteLine("======遊戲開始======");
                Console.WriteLine("出拳（左手 / 右手 / 拳語）：");                
                string[] get_number = { "0", "0", "0" };

                while (true)
                {
                    Console.WriteLine($"現在進攻方是 {statu} ");
                    Console.Write("玩家出拳:");
                    //玩家輸入                 
                    while(true)
                    {
                        input = Console.ReadLine();
                        get_number = input.Split(' ');
                        if (statu == Speaker.computer)//電腦進攻
                        {
                            if (get_number.Length == 2)
                            {
                                if ((get_number[0] == "0" || get_number[0] == "5") && (get_number[1] == "0" || get_number[1] == "5"))
                                    break;
                                else
                                    Console.Write("輸入格式(左拳 空格 右拳):");
                            }
                            else
                                Console.Write("輸入格式(左拳 空格 右拳):");
                        }
                        else//玩家進攻
                        {
                            if (get_number.Length == 3)
                            {
                                if ((get_number[0] == "0" || get_number[0] == "5") && (get_number[1] == "0" || get_number[1] == "5")&&(get_number[2] == "0" || get_number[2] == "5" || get_number[2] == "10" || get_number[2] == "15" || get_number[2] == "20"))
                                    break;
                                else
                                    Console.Write("輸入格式(左拳 空格 右拳 空格 拳語):");
                            }
                            else
                                Console.Write("輸入格式(左拳 空格 右拳 空格 拳語):");
                        }
                    }
                    //儲存玩家輸入值
                    user_left_hand = int.Parse(get_number[0]);
                    user_right_hand = int.Parse(get_number[1]);
                    if (statu == Speaker.player)
                        total = int.Parse(get_number[2]);
                    //電腦出拳
                    Console.Write("電腦出拳:");
                    com_left_hand = random.Next(0, 2) * 5;
                    com_right_hand = random.Next(0, 2) * 5;
                    if (statu == Speaker.computer)
                    {
                        total = random.Next((com_left_hand/5+com_right_hand/5), 5) * 5;//電腦拳語不小於自身雙手相加
                        Console.Write($"{com_left_hand} {com_right_hand} {total}\n");
                    }
                    else
                        Console.Write($"{com_left_hand} {com_right_hand}\n");
                    //勝負判斷
                    if (total == user_left_hand + user_right_hand + com_left_hand + com_right_hand)
                        victory += 1;
                    else
                    {
                        victory = 0;
                        if (statu == Speaker.computer)
                            statu = Speaker.player;
                        else
                            statu = Speaker.computer;
                    }
                    if (victory == 1)
                        Console.WriteLine($"{statu}聽牌");
                    if (victory == 2)
                        break;
                }                
                Console.WriteLine($" {statu} 贏 !!!\n");
                //詢問是否繼續進行遊戲
                Console.Write("請問是否繼續 (1: Yes/2: No)？");
                input = Console.ReadLine();
                while (!(input == "2" || input == "1"))
                {
                    Console.Write("請重新輸入 (1: Yes/2: No)？");
                    input = Console.ReadLine();
                }
                if (input == "2")
                    break;
            }
              Console.WriteLine("按任意鍵繼續...");
              Console.ReadKey();
        }
    }
}
