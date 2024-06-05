
namespace Lottery
{
    public class Game
    {
        static List<Game> gamesList = new List<Game>();  //List to save the number of games requested by the user | Lista para salvar o numero de jogos solicitados pelo usuário
        public int[] Games { get; set; } //Array to save the numbers of the game | Array para salvar os numeros do jogo
        public Game(int[] games)
        {
            if (games.Length != 6) //Verifica se o numero de jogos é diferente a 6
                throw new Exception("The number of games must be 6");
            Games = games;
        }
        public static void AddGame(Game game)
        {
            gamesList.Add(game);
        }

        public static void OrderNumbers(int index)
        {
            Array.Sort(gamesList[index].Games); //Ordena os numeros do jogo | Sort the numbers of the game
        }

        public static void ShowGames()//Show all the games in the list | Mostra todos os jogos na lista
        {
            int index = 0;
            foreach (var game in gamesList)
            {
                OrderNumbers(index); 
                System.Console.WriteLine($"Jogo {index + 1}: {string.Join(" | ", game.Games)}"); //Imprime o jogo na tela 
                index++;
            }
        }
        public static void GeneratorGame(int numberOfGames)
        {
            for (int i = 0; i < numberOfGames; i++)
            {
                int[] games = new int[6]; //Array para salvar os numeros do jogo
                Random random = new Random();

                HashSet<int> usedNumbers = new HashSet<int>(); //HashSet para salvar os numeros ja utilizados no jogo

                for (int j = 0; j < games.Length; j++)
                {

                    int randomNumber;
                    do
                    {
                        randomNumber = random.Next(1, 60); //Gera um numero aleatorio entre 1 e 60
                    } while (usedNumbers.Contains(randomNumber)); //Verifica se o numero ja foi utilizado no jogo
                    games[j] = randomNumber; //Adiciona o novo numero no jogo
                    usedNumbers.Add(randomNumber); //Adiciona o novo numero no HashSet
                }
                AddGame(new Game(games)); //Adiciona o novo jogo na lista
                usedNumbers.Clear(); //Limpa o HashSet
            }
        }
    }
}