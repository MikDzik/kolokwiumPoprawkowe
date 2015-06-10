
namespace Dices
{
    /// <summary>
    /// Sum of two results of throwing two dices
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    public class TwoDicesResult
    {
        /// <summary>
        /// Gets or sets result from first dice
        /// </summary>
        public DiceResult First { get; set; }

        /// <summary>
        /// Gets or sets result from second dice
        /// </summary>
        public DiceResult Second { get; set; }

        /// <summary>
        /// Calculates total number from two dices
        /// </summary>
        public int Sum 
        {
            get
            {
                return (int)First + (int)Second;
            }
        }
    }
}
