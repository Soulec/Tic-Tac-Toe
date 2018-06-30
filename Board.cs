namespace tictactoe
{
    class Board
    {
        public string[,] field
        {
            get;
        }

        public Board()  // constructor to create the array that will be used to render the starting board
        {
            field = new string[,]
            {
                {"7", "8", "9" },
                {"4", "5", "6" },
                {"1", "2", "3" },
            };
        }
    }
}