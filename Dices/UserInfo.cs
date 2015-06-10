using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dices
{
    /// <summary>
    /// Basic information about the user
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Gets or sets name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets user results of throwing two dices at the same time
        /// </summary>
        public ObservableCollection<TwoDicesResult> Results { get; set; }

        public UserInfo()
        {
            Results = new ObservableCollection<TwoDicesResult>();
        }

    }
}
