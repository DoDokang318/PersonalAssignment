using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalAssignment
{
    class Program
    {

        private static List<equipment> equipmentList = new List<equipment>();
        private static List<equipment> RandomBoxList = new List<equipment>();
        private static List<equipment> StoreList = new List<equipment>();
        private static List<equipment> StoreSell = new List<equipment>();
        private static Random random = new Random();

      




        private static player Player;
    


        private static equipment Sword;
        private static equipment Shield;

        private static equipment boneCrusher;
        private static equipment VeilOfNight;
        private static equipment Sheen; 
        private static equipment GreatClub;

        private static equipment spear;
        private static equipment Club;
        private static equipment LongSword;
        private static equipment Stick;
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
            Sword = new equipment("칼           ",8, 0 ,"짱쌘칼",100);
            Shield = new equipment("방패         ",0, 5 ,"짱쌘방패", 100);

            boneCrusher = new equipment("뼈분쇄기     ",14, 0 ,"맞으면 뼈가부서진다", 500);
            VeilOfNight = new equipment("밤의장막     ",0, 3, "검은색 천 이다 ", 50);
            Sheen = new equipment("광휘         ", 10, 10, "전설의 성스러운무기", 1000);
            GreatClub = new equipment("자이언트클럽 ",16, -2, "엄청큰몽둥이", 1000);

            spear = new equipment("창 ", 6, 1, "평범한창", 200);
            Club = new equipment("몽둥이 ", 9, 0, "큰몽둥이", 300);
            LongSword = new equipment("롱소드 ", 10, 0, "평범한 롱소드", 350);
            Stick = new equipment("막대기 ", 3, 1, "엄청큰몽둥이", 150);


            equipmentList.Add(Sword);
            equipmentList.Add(Shield);

            //  RandomBoxList 에서 뽑아서  equipmentList 에 넣어줘야해 ... 어떻게?? 
            RandomBoxList.Add(GreatClub);
            RandomBoxList.Add(Sheen);
            RandomBoxList.Add(VeilOfNight);
            RandomBoxList.Add(boneCrusher);

            //========== 상점 리스트 
            StoreList.Add(spear);
            StoreList.Add(Club);
            StoreList.Add(LongSword);
            StoreList.Add(Stick);

            //============상점 판매 리스트

            StoreSell.Add(Sword);
            StoreSell.Add(Shield);

        }




            static void firstDisplay()
        {
            Console.WriteLine($"스파르타 마을에 오신 {Player.Name }님 환영합니다\n.이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다");
            Console.WriteLine(" 1. 상태 보기\n 2. 인벤토리\n 3.랜덤박스\n 4. 상점");
            


            int input = CheckInput(1, 4);
            switch (input)
            {
                case 1:
                    PlayerInfo();
                    break;
                case 2:
                    Inven();
               
                    break;
                case 3:
                    RandomBox();
                    break;

                case 4:
                    Store();
                    break;

                    
            }



        }

        static void PlayerInfo()
        {

         int TotalAt = Player.At;
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
            Console.WriteLine($"공격력: {  Player.At } (+{ TotalAt - Player.At})"); // 장착했을깨 이미 플레이러 스탯이랑 장비 스탯이 저장이되있음 (18)  그래서 + 8를 더출력하고싶으면  처음 플레이어스탯을 빼줘야함 
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
                Console.Write($"{CompleteEq}  장비 이름:{eqItem.Eq}   ㅣ");
                Console.Write($"장비 공격력:{eqItem.EqAt}   ㅣ");
                Console.Write($"장비 방어력:{eqItem.EqDt}   ㅣ");
                Console.WriteLine($"장비 설명:{eqItem.EqExplain}   ㅣ");
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

        public static void Store()
        {
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine($"보유골드{Player.Gold}");
            int storeEqCount = 1;

            Console.WriteLine("[아이템 목록]\n");



            foreach (equipment eqItem in StoreList)
            {
                string CompleteEq = eqItem.Eqbool ? "구매완료" : " ";
                Console.Write($"{storeEqCount} 장비 이름:{eqItem.Eq} ");
                Console.Write($"장비 공격력:{eqItem.EqAt}   ㅣ");
                Console.Write($"장비 방어력:{eqItem.EqDt}   ㅣ");
                Console.Write($"장비 설명:{eqItem.EqExplain}   ㅣ");
                Console.WriteLine($"장비 가격:{eqItem.EqGold}   ㅣ  {CompleteEq} ");
                storeEqCount++;
            }

            Console.WriteLine("\n\n\n\n\n");

            Console.WriteLine("-1 :처음화면으로");
            Console.WriteLine("0 :판매");
            Console.WriteLine("구매할 번호 입력해주세요");

            int InputEqIndex = int.Parse(Console.ReadLine())-1;




            if (InputEqIndex == -2)
            {
                Console.Clear();
                firstDisplay();
            }
            if (InputEqIndex == -1)
            {
                Console.Clear();
                StoreSales();
            }

            if (InputEqIndex >= 0&& InputEqIndex < StoreList.Count)
            {

                if (StoreList[InputEqIndex].Eqbool == false)
                {
                    StoreList[InputEqIndex].Eqbool = true;

                    equipment storeItem = new equipment(StoreList[InputEqIndex].Eq, StoreList[InputEqIndex].EqAt, StoreList[InputEqIndex].EqDt, StoreList[InputEqIndex].EqExplain, StoreList[InputEqIndex].EqGold);
                    equipmentList.Add(storeItem);
                    StoreSell.Add(storeItem);
                    Player.Gold -= StoreList[InputEqIndex].EqGold;
                  
                }
              
                Console.Clear();
                Store();
            }
            else if(InputEqIndex > storeEqCount-2)
            {
                

                Console.Clear();
                Store();
                Console.WriteLine("-1 ~ 9 사이의 숫자를 입력해주세요  ");
            }
  

        }
        public static void StoreSales()
        {
            Console.WriteLine("필요한 아이템을 팔수 있는 상점입니다.");
            Console.WriteLine($"보유골드{Player.Gold}");
            int storeEqCount = 1;

            Console.WriteLine("[아이템 목록]\n");



            foreach (equipment eqItem in equipmentList)
            {
                string CompleteEq = eqItem.Eqbool ? " " : " ";
                Console.Write($"{storeEqCount} 장비 이름:{eqItem.Eq} ");
                Console.Write($"장비 공격력:{eqItem.EqAt}   ㅣ");
                Console.Write($"장비 방어력:{eqItem.EqDt}   ㅣ");
                Console.Write($"장비 설명:{eqItem.EqExplain}   ㅣ");
                Console.WriteLine($"장비 가격:{eqItem.EqGold}   ㅣ  {CompleteEq} ");
                storeEqCount++;
            }

            Console.WriteLine("\n\n\n\n\n");

            Console.WriteLine("0 :구매");
           
            Console.WriteLine("판매할 아이템 번호 입력해주세요");

            int InputEqIndex = int.Parse(Console.ReadLine()) - 1;




            if (InputEqIndex == -1)
            {
                Console.Clear();
                Store();
            }
     

           if (InputEqIndex >= 0&& InputEqIndex < equipmentList.Count)
            {

                if (equipmentList[InputEqIndex].Eqbool == false || equipmentList[InputEqIndex].Eqbool == true)
                {
                    equipmentList[InputEqIndex].Eqbool = true;

                    equipment storeItem = new equipment(equipmentList[InputEqIndex].Eq, equipmentList[InputEqIndex].EqAt, equipmentList[InputEqIndex].EqDt, equipmentList[InputEqIndex].EqExplain, equipmentList[InputEqIndex].EqGold);                   
                    StoreList.Add(storeItem);

                    Player.At -= equipmentList[InputEqIndex].EqAt;
                    Player.Dt -= equipmentList[InputEqIndex].EqDt;
                    Player.Gold += (StoreList[InputEqIndex].EqGold*0.85);
                    equipmentList.Remove(equipmentList[InputEqIndex]);
                }
              
                Console.Clear();
                StoreSales();
            }
           else if (InputEqIndex > equipmentList.Count-2)
            {
                Console.WriteLine("올바른  숫자를 입력해주세요  ");
                Thread.Sleep(500);
                Console.Clear();
                StoreSales();

            }


        }


        public static void RandomBox()
        {
            Console.WriteLine("장비 랜덤뽑기(50 G)");


            Console.WriteLine("\n\n\n\n\n\n\n");


            Console.WriteLine("나가기: 0");
            Console.WriteLine("랜덤박스 : 1");

            int input = CheckInput(0, 1);
            switch (input)
            {
                case 0:
                    firstDisplay();
                    break;
                case 1:
                    RandomEq();
                    break;

            }

        }
        ///<summary>
        ///플레이어의 장비 를 랜덤으로 뽑아 EquipmentData() 에 add하는 메서드 
        ///</summary>
        public static void RandomEq()
        {
           

            int randomPercentage = random.Next(0, 10);
            Player.Gold -= 50;
           
            if (Player.Gold < 50)
            {
                Console.WriteLine("돈부족!");
                Thread.Sleep(1000);
                Console.Clear();
                firstDisplay();
            }
            else if (randomPercentage <= 1)// 10% 확률로 아이템 선택
            {
                int randomIndex = random.Next(0, 2);
                equipment RandomItem = new equipment(RandomBoxList[randomIndex].Eq , RandomBoxList[randomIndex].EqAt , RandomBoxList[randomIndex].EqDt, RandomBoxList[randomIndex].EqExplain, RandomBoxList[randomIndex].EqGold);
                
                equipmentList.Add(RandomItem);// 새로운 인스턴스로 만들어줘서 넣어줘애한다 
                string selectedItem = RandomItem.Eq;
          

                UniqueEqCountdown(500);

                Console.WriteLine($"축하합니다! 전설장비 '{selectedItem}'  획득하셨습니다.");
                Thread.Sleep(2000);
                Console.Clear();
                firstDisplay();
            }
            else  // 90% 확률로 아이템 선택
            {
                int randomIndex = random.Next(2, 4);
                equipment RandomItem = new equipment(RandomBoxList[randomIndex].Eq, RandomBoxList[randomIndex].EqAt, RandomBoxList[randomIndex].EqDt, RandomBoxList[randomIndex].EqExplain, RandomBoxList[randomIndex].EqGold);

                equipmentList.Add(RandomItem);
                string selectedItem = RandomItem.Eq;
           

                NomaEqCountdown(500);
                Console.WriteLine($" 희귀장비  '{selectedItem}'  획득하셨습니다.");
                Thread.Sleep(1000);
                Console.Clear();
                firstDisplay();
            }


        }

        static void NomaEqCountdown(int milliseconds)
        {
           
            Console.WriteLine("3");

            Thread.Sleep(milliseconds);
            Console.WriteLine("2");

            Thread.Sleep(milliseconds);
            Console.WriteLine("1");
        }

        static void UniqueEqCountdown(int milliseconds)
        {
           
            Console.WriteLine("3");

            Thread.Sleep(milliseconds);
            Console.WriteLine("2");

            Thread.Sleep(milliseconds);
            Console.WriteLine("1");

            Thread.Sleep(milliseconds);
            Console.WriteLine("!★!☆!★!☆!★!☆!★!☆!★!☆!★!☆!★!☆!★!☆!★!☆!");
            
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

        public double EqGold { get; }
        public equipment(string eq, int eqat,int eqdt, string eqExplain, double eqGold)
        {
            Eq = eq;

            EqAt = eqat;

            EqDt = eqdt;

            EqExplain = eqExplain;

            EqGold = eqGold;

        }
        
    }
    public class player
    {
      
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int At { get; set; }
        public float Dt { get; set; }
        public double Gold { get; set; }
         public int Hp { get; }

        public player(string name, string job, int level, int at, float dt, int hp, double gold)
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

