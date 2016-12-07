namespace DungeonWanderer.Core
{
    public enum GameState
    {
        MainMenu, Game
    }
    public class GameStateManager
    {
        private GameState currentState=GameState.MainMenu;
        private Screen currentScreen;
        private DWGame game;

        public Screen CurrentScreen
        {
            get
            {
                return currentScreen;
            }
        }

        public GameStateManager(DWGame game)
        {
            this.game = game;
        }

        public GameState CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
                switch(value)
                {
                    case GameState.MainMenu:
                        currentScreen = new MainMenuScreen(game);
                        currentScreen.Initialize();
                        currentState = GameState.MainMenu;
                        break;

                    case GameState.Game:
                        currentScreen = new GameScreen(game);
                        currentScreen.Initialize();
                        currentState = GameState.Game;
                        break;

                    default:
                        break;
                }
            }
        }
        public void ResetCurrentScreen()
        {
            currentScreen.Initialize();
        }
    }
}
