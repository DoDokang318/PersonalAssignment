using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAssignment
{
    class Program
    {
        private static List<equipment> equipmentList = new List<equipment>();
        private static List<equipment> RandomBoxList = new List<equipment>();


        private static player Player;

  
        private static equipment Sword;
        private static equipment Shield;

        private static equipment boneCrusher;
        private static equipment VeilOfNight;
        private static equipment Sheen; 
        private static equipment GreatClub; 
        static void Main(string[] args)
        {
            playerData();
            EquipmentData();
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
            Sword = new equipment("칼           ",8, 0 ,"짱쌘칼");
            Shield = new equipment("방패         ",0, 5 ,"짱쌘방패");

            boneCrusher = new equipment("뼈분쇄기     ",14, 0 ,"맞으면 뼈가부서진다");
            VeilOfNight = new equipment("밤의장막     ",0, 3, "검은색 천 이다 ");
            Sheen = new equipment("광휘         ", 10, 10, "전설의 성스러운무기");
            GreatClub = new equipment("자이언트클럽 ",16, -2, "엄청큰몽둥이");

            equipmentList.Add(Sword);
            equipmentList.Add(Shield);

            //  RandomBoxList 에서 뽑아서  equipmentList 에 넣어줘야해 ... 어떻게?? 
            RandomBoxList.Add(GreatClub);
            RandomBoxList.Add(Sheen);
            RandomBoxList.Add(VeilOfNight);
            RandomBoxList.Add(boneCrusher);
        }

        static void InvenData()
        {


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

         int TotalAt = Player.At; // 장착했을깨 이미 플레이러 스탯이랑 장비 스탯이 저장이되있음 (18)  그래서 + 8를 더출력하고싶으면  처음 플레이어스탯을 빼줘야함 
         float TotalDt = Player.Dt;

            foreach (equipment eqItem in equipmentList) //무기 점수를 한번더 더해서 빼줘
            {
                if (eqItem.Eqbool)
                {
                    TotalAt += eqItem.EqAt;
                    TotalDt += eqItem.EqDt;
                }
            }


            Console.WriteLine("Lv."+ Player.Level );
            Console.WriteLine("이름. :"+ Player.Name);
            Console.WriteLine("직업  :" + Player.Job);
            Console.WriteLine($"공격력: {  Player.At } (+{ TotalAt - Player.At})");
            Console.WriteLine($"방어력: {  Player.Dt } (+{ TotalDt - Player.Dt})");
            Console.WriteLine("체력: " + Player.Hp);
            Console.WriteLine("gold: " + Player.Gold);

            Console.WriteLine(" ");
            Console.WriteLine("0 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요");
           

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
           
          

            Console.WriteLine("인벤토리\n");
          
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다\n\n");
          
            Console.WriteLine("[아이템 목록]\n");

            

            foreach (equipment eqItem in equipmentList)
            {
                string CompleteEq = eqItem.Eqbool ? "E" : " ";
                Console.Write($"{CompleteEq}  장비 이름:{eqItem.Eq}   ㅣ"); Console.Write($"장비 공격력:{eqItem.EqAt}   ㅣ"); Console.Write($"장비 방어력:{eqItem.EqDt}   ㅣ"); Console.WriteLine($"장비 설명:{eqItem.EqExplain}   ㅣ");
            }

            Console.WriteLine("\n\n\n\n\n");



            Console.WriteLine("0 :나가기");
            Console.WriteLine("1 :장비 장착 ");
            int input = CheckInput(0, 1);
            switch (input)
            {
                case 0:
                    firstDisplay();
                    break;
                case 1:
                    InvenEq();
                    break;
            }

        }

        ///<summary>
        ///플레이어의 장비 장착 에 관련된  메서드 이다 
        ///</summary>
        public static void InvenEq()
        {

            int EqCount = 1;

            Console.WriteLine("인벤토리\n");

            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다\n\n");
           
            Console.WriteLine("[아이템 목록]\n");



            foreach (equipment eqItem in equipmentList)
            {
                string CompleteEq = eqItem.Eqbool ? "E" : " ";
                Console.Write($"{EqCount}  {CompleteEq}  장비 이름:{eqItem.Eq}   ㅣ");
                Console.Write($"장비 공격력:{eqItem.EqAt}   ㅣ");
                Console.Write($"장비 방어력:{eqItem.EqDt}   ㅣ");
                Console.WriteLine($"장비 설명:{eqItem.EqExplain}   ㅣ");
                EqCount++;
            }

            Console.WriteLine("\n\n\n\n\n");
    
            Console.WriteLine("0 :인벤토리");
            Console.WriteLine("장착할장비 번호 입력해주세요");

            int InputEqIndex = int.Parse(Console.ReadLine())-1;


          

            if (InputEqIndex == -1)
              {
                Console.Clear();
                Inven();
              }
   
             if(InputEqIndex>=0)
            {
               
                if (equipmentList[InputEqIndex].Eqbool == false)
                {
                    equipmentList[InputEqIndex].Eqbool = true;

                    
                    Player.At += equipmentList[InputEqIndex].EqAt;
                    Player.Dt += equipmentList[InputEqIndex].EqDt;
                    Console.WriteLine("장착완료");
                }
                else
                { 
                    equipmentList[InputEqIndex].Eqbool = false;
                    Console.WriteLine("장착해제");

                    Player.At -= equipmentList[InputEqIndex].EqAt;
                    Player.Dt -= equipmentList[InputEqIndex].EqDt;
                }
                Console.Clear();
                InvenEq();
             }


        }
        ///<summary>
        ///플레이어의 장비 를 랜덤으로 뽑아 EquipmentData() 에 add하는 메서드 
        ///</summary>
        public static void RandomBox()
        {
            Console.WriteLine("장비 랜덤뽑기(50 G)");




           


            int input = CheckInput(0, 1);
            switch (input)
            {
                case 0:
                    firstDisplay();
                    break;
                case 1:

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
        public bool Eqbool { get; set; }
        public string Eq { get; }
        public int EqAt { get; set; }

        public int EqDt { get; set; }
        public string EqExplain { get; }
        public equipment(string eq, int eqat,int eqdt, string eqExplain )
        {
            Eq = eq;

            EqAt = eqat;

            EqDt = eqdt;

           EqExplain = eqExplain;
        }
    }
    public class player
    {
      
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int At { get; set; }
        public float Dt { get; set; }
        public int Gold { get; }
         public int Hp { get; }

        public player(string name, string job, int level, int at, float dt, int hp, int gold)
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
