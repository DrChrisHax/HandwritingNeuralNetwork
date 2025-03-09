namespace HandwritingNeuralNetwork.Shared
{
    public static class AppConstants
    {
        //Grid Constants
        public const int GRID_ROWS = 64;
        public const int GRID_COLUMNS = 64;

        //AI Constants
        public const int INPUT_NEURONS = GRID_ROWS * GRID_COLUMNS;
        public const int HIDDEN_NEURONS = GRID_COLUMNS + GRID_ROWS;
        public const int OUTPUT_NEURONS = 11; //One for every digit + NaN

        public const string NeuralNetworkName = "HWNN v0.1";
    }
}
