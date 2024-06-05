namespace Lottery
{
    class Program{
        static void Main(string[] args)
        {
            System.Console.Write("Select the number of games: ");
            
           int numberOfGames = Convert.ToInt32(System.Console.ReadLine()); //Gera os jogos
           Game.GeneratorGame(numberOfGames);
           Game.ShowGames();
        }
    }
}