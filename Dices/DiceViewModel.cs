using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Dices
{
    public class DiceViewModel : IDiceViewModel
    {
        private readonly IDispatcher _dispatcher;

        public DiceViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;

            Players.Add(new UserInfo() { Name = "Player1" });
            Players.Add(new UserInfo() { Name = "Player2" });
            Players.Add(new UserInfo() { Name = "Player3" });
            Players.Add(new UserInfo() { Name = "Player4" });
            SelectedPlayer = Players[0];
            TwoResult = new TwoDicesResult();
            MyRand = new Random();
        }

        private List<UserInfo> _players = new List<UserInfo>();
        public IList<UserInfo> Players
        {
            get
            {
                return _players;
            }
            set
            {
                _players = value as List<UserInfo>;
                RaisePropertyChanged();
            }
        }


        private UserInfo _selectedPlayer;
        public UserInfo SelectedPlayer
        {
            get
            {
                return _selectedPlayer;
            }
            set
            {
                _selectedPlayer = value;
                RaisePropertyChanged();
            }
        }

        public DiceResult FirstDiceResult
        {
            get { return _twoResult.First; }
        }

        public DiceResult SecondDiceResult
        {
            get { return _twoResult.Second; }
        }

        private TwoDicesResult _twoResult;

        public TwoDicesResult TwoResult
        {
            get { return _twoResult; }
            set
            {
                _twoResult = value;
                RaisePropertyChanged();
            }
        }

        private Random _myRand;

        public Random MyRand
        {
            get { return _myRand; }
            set { _myRand = value; }
        }


        private MyCommand _ThrowDicesForSelectedPlayerCommand;


        private void Metoda()
        {
            int a = MyRand.Next(1, 7);
            int b = MyRand.Next(1, 7);
            TwoResult.First = (DiceResult) a;
            TwoResult.Second =(DiceResult) b;
        }

        public System.Windows.Input.ICommand ThrowDicesForSelectedPlayerCommand
        {
            get { return _ThrowDicesForSelectedPlayerCommand ?? (_ThrowDicesForSelectedPlayerCommand = new MyCommand(Metoda)); }
        }

        public IList<UserInfo> Cheaters
        {
            get { throw new NotImplementedException(); }
        }

        public System.Windows.Input.ICommand ShowMeCheatersCommand
        {
            get { throw new NotImplementedException(); }
        }

        public System.Windows.Input.ICommand SaveResultsCommand
        {
            get { throw new NotImplementedException(); }
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
