namespace GPArray
{
    class Program
    {
        //The array for the details of the arrangement in text
        static string[] arrangements = new string[100];
        //Multidimensional array :int [100,3]{ {0,1,2} {0,1,2} ......x100}
        //Multidimensional array :int [100,3,2]{ {0,1}{0,1,2} {0,1,2} ......x100}
        static int[,] tickets = new int[1000,2];
        static void Main(string[] args)
        {
            //Add data to the array
            AddtoArray();
            // Loop menu infinite
            while (true)
            {
                Menu();
            }
            
        }
        static void Menu()
        {
            
            Console.WriteLine("Billet System");
            Console.WriteLine("1.Show\n2.Køb Biilet\n3.Vis All billeter\n Enter choice: ");
            //switch case for the numeric key pressed
            switch (Console.ReadKey(true).Key)
            {

                //Both cases points to the same code
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowAllArrangements();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    ShowAllArrangements();
                    int t = BuyTicket();
                    Console.Write("Ticket number:"+t);
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    ShowTicketBought();
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.D7:
                    break;
                case ConsoleKey.D8:
                    break;
                case ConsoleKey.D9:
                    break;
                               
                case ConsoleKey.NumPad4:
                    break;
                case ConsoleKey.NumPad5:
                    break;
                case ConsoleKey.NumPad6:
                    break;
                case ConsoleKey.NumPad7:
                    break;
                case ConsoleKey.NumPad8:
                    break;
                case ConsoleKey.NumPad9:
                    break;

                default:
                    break;
                
            }
        }
        /// <summary>
        /// Shows all tickets that have been purchased by looping thrru all the multi
        /// array,and stopping when empty
        /// </summary>
        /// <returns></returns>
        static void ShowTicketBought()
        {
            Console.WriteLine("Antal\t Arrangement\t Lokation");
            for (int i = 0; i < tickets.Length; i++)
            {
                // if its empty we stop the loop
                if (tickets[i, 0] == 0) return;
                string arr = arrangements[tickets[i,1]];
                string [] splitArray = arr.Split("- ");
                Console.WriteLine(tickets[i, 0] +" \t"+splitArray[0]+"\t"+ splitArray[1]);
            }
        }
        /// <summary>
        ///  Buy Ticket for the concert you are looking for 1 or 2 or 3
        /// </summary>
        /// <returns>int  next free spot</returns>
        static int BuyTicket()
        {
            Console.Write("Indstat Nummer på arragement du ønsker at købe billet: ");
            string input =Console.ReadLine();
            //Gets the string and tries to convert to int if success returns true and it ouputs int
            // if fail nothing happens
            int.TryParse(input, out int arrangementNumber);

            Console.Write("Enter the nymber of billets: ");
            //input = Console.ReadLine();
            // No reason to add another string,We ask directly on the readline
            int.TryParse(Console.ReadLine(), out int amountOfTickets);
            
            
            int freeSpot=GetNextFreeSpotInTicketArray();
            // We insert out the ticket data in out multi array
            //First the 0 pos and then the 1 pos
            int[] temp = {amountOfTickets, arrangementNumber};
            tickets[freeSpot,0]=amountOfTickets;
            tickets[freeSpot, 0] = arrangementNumber;
            return freeSpot;

        }
      /// <summary>
      /// Loops through all the ticket array and return first empty spot unless its full and then it starts over 0
      /// </summary>
      /// <returns></returns>
        static int GetNextFreeSpotInTicketArray()
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                
                if (tickets[i,0] == 0) 
                { 
                    return i;
                }
            }
            return 0;
        }
        static void ShowAllArrangements()
        {
            foreach (string  arr in arrangements)
            {
                ShowArrangements(arr);
            }
        }

        private static void ShowArrangements(string arr)
        {
            if (arr != null && arr != "")
            {
                //indexof takes the data of the array and ask what position it
                // have in the array.
                int i = Array.IndexOf(arrangements, arr);
                Console.WriteLine(i + " " + arr);
            }
        }

        static void AddtoArray()
        {
            arrangements[0] = "Lil Johan - hello ";
            arrangements[1] = "Deagle - TEC";
            arrangements[2] = "DTEC  Læreband-Amager Plads";
                
                

        }
    }

}
