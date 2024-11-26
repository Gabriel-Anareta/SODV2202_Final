using ChessClient.MVVM.View._2Player;
using ChessClient.MVVM.View._4Player;

namespace ChessHub
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new ChessClient.AppContext());
            Application.Run(new Chess2PlayerView(
                ChessModel.PlayerColor.White,
                new ChessClient.Net.Server(),
                new List<string>() { "Hannah", "John" }
            ));
            //Application.Run(new Chess4PlayerView(
            //    ChessModel.PlayerColor.Red, 
            //    new ChessClient.Net.Server(), 
            //    new List<string>() { "Hannah", "John", "Yoru", "Onda" }
            //));
        }
    }
}