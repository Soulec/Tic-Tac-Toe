namespace tictactoe
{
    class Player
    {
        public int PlayerTurn { get; private set; }

        public Player()
        {
            PlayerTurn = 1; // first player
        }

        public void SwapPlayersTurn()
        {
            if (PlayerTurn == 1)
                PlayerTurn = 2;
            else
                PlayerTurn = 1;
        }
    }
}