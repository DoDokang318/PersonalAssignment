using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAssignment
{
    class Program
    {

        private static player Player;
      

        private static equipment Sword;
        private static equipment Shield;

        static void Main(string[] args)
        {
            playerData();
            firstDisplay();

        }
        static void playerData()
        {
            Console.WriteLine("게임시작전 플레이어 이름을 입력해주세요");
            string name = Console.ReadLine();
            Player   = new player(name, "전사", 1, 10, 5, 100, 1500);
           
            
        }

        static void EquipmentData()
        {
            Sword = new equipment("칼", 8, "짱쌘칼");
            Shield = new equipment("방패 ", 5, "짱쌘방패");


        }


            static void firstDisplay()
        {
            Console.WriteLine($"스파르타 마을에 오신 {Player.Name }님 환영합니다\n.이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다");
            Console.WriteLine(" 1. 상태 보기\n 2. 인벤토리");

           
            int input = CheckInput(1, 2);
            switch (input)
            {
                case 1:
                    PlayerInfo();
                    break;
                case 2:
                    Inven();
               
                    break;
            }



        }

        static void PlayerInfo()
        {

            Console.WriteLine("Lv."+ Player.Level );
            Console.WriteLine("이름. :"+ Player.Name);
            Console.WriteLine("직업  :" + Player.Job);
            Console.WriteLine("공격력: " + Player.At);
            Console.WriteLine("방어력: " + Player.Dt);
            Console.WriteLine("체력: " + Player.Hp);
            Console.WriteLine("gold: " + Player.Gold);

            Console.WriteLine(" ");
            Console.WriteLine("0 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            string DispStat = Console.ReadLine();

            int input = CheckInput(0, 0);
            switch (input)
            {
                case 0:
                    firstDisplay();
                break;

            }
            
        }


        ///<summary>
        ///플레이어의 인벤토리에 관련된  메서드 이다 
       ///</summary>
        public static void Inven()
        {
            EquipmentData();


            Console.WriteLine("인벤토리\n");
          
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다\n\n");
          
            Console.WriteLine("[아이템 목록]\n");

            Console.WriteLine(Sword.Eq + "      l   " + Sword.Stat + "   l   " + Sword.EqExplain+"\n");
            Console.WriteLine(Shield.Eq + "   l   " + Shield.Stat + "   l   " + Shield.EqExplain);


            Console.WriteLine("\n\n\n\n\n");



            Console.WriteLine("0 :나가기");
            int input = CheckInput(0, 0);
            switch (input)
            {
                case 0:
                    firstDisplay();
                    break;

            }

        }


        // 매개변수를 받아서 받는 숫자 를 지정하고싶음 

        static int CheckInput(int min, int max)
        {
            int DispStat;
            bool parseSuccess;
          
            do
            {
                string input = Console.ReadLine();

                
                parseSuccess = int.TryParse(input, out DispStat);

                if (parseSuccess && DispStat >= min && DispStat <= max)
                {

                    Console.Clear();
                    return DispStat;
                  

                }
                Console.WriteLine("잘못된 입력입니다.");

            } while (true);
        }
    }

    public class equipment
    {

        public string Eq { get; }
        public int Stat { get; }
        public string EqExplain { get; }
        public equipment(string eq, int stat, string eqExplain )
        {
            Eq = eq;

            Stat = stat;

            EqExplain = eqExplain;
        }
    }
    public class player
    {
      
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int At { get; }
        public int Dt { get; }
        public int Gold { get; }
         public int Hp { get; }

        public player(string name, string job, int level, int at, int dt, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            At = at;
            Dt = dt;
            Hp = hp;
            Gold = gold;
        }
    }
}
