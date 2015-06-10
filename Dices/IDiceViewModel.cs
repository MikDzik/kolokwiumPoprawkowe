using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Dices
{
    /// <summary>
    /// Main viewmodel of application
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public interface IDiceViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the players
        /// </summary>
        IList<UserInfo> Players { get; }

        /// <summary>
        /// Gets or sets selected player
        /// </summary>
        UserInfo SelectedPlayer { get; set; }

        /// <summary>
        /// Gets the result for first dice thrown
        /// </summary>
        DiceResult FirstDiceResult { get; }

        /// <summary>
        /// Gets the result for second dice thrown
        /// </summary>
        DiceResult SecondDiceResult { get; }

        /// <summary>
        /// Gets the command for throwing dices
        /// </summary>
        ICommand ThrowDicesForSelectedPlayerCommand { get; }

        /// <summary>
        /// Gets the players that may cheat by throwing 3 times in a row same result
        /// </summary>
        IList<UserInfo> Cheaters { get; }

        /// <summary>
        /// Gets the command for showing cheaters
        /// </summary>
        ICommand ShowMeCheatersCommand { get; }

        /// <summary>
        /// Gets the command for saving results to the file
        /// </summary>
        ICommand SaveResultsCommand { get; }
    }
}
