using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace Arknight_Roll_Tracker
{
    public class MainWindowViewModel : BaseViewModel
    {
        private float _curTotalRolls;
        private float _amtOf6Stars;
        private float _amtOf5Stars;
        private float _amtOf4Stars;
        private float _amtOf3Stars;
        private float _percent6star;
        private float _percent5star;
        private float _percent4star;
        private float _percent3star;
        
        private ICommand _saveCommand;

        public MainWindowViewModel()
        {
            LoadFunction();
        }
        #region Properties
        public float CurTotalRolls
        {
            get
            {
                return _curTotalRolls;
            }
            set
            {
                _curTotalRolls = value;
                OnPropertyChanged(nameof(CurTotalRolls));
            }
        }
        public float AmtOf6Stars
        {
            get
            {
                return _amtOf6Stars;
            }
            set
            {
                _amtOf6Stars = value;
                OnPropertyChanged(nameof(AmtOf6Stars));
                SumforCurRolls();
                PercentCalculation();
            }
        }
        public float AmtOf5Stars
        {
            get
            {
                return _amtOf5Stars;
            }
            set
            {
                _amtOf5Stars = value;
                OnPropertyChanged(nameof(AmtOf5Stars));
                SumforCurRolls();
                PercentCalculation();
            }
        }
        public float AmtOf4Stars
        {
            get
            {
                return _amtOf4Stars;
            }
            set
            {
                _amtOf4Stars = value;
                OnPropertyChanged(nameof(AmtOf4Stars));
                SumforCurRolls();
                PercentCalculation();
            }
        }
        public float AmtOf3Stars
        {
            get
            {
                return _amtOf3Stars;
            }
            set
            {
                _amtOf3Stars = value;
                OnPropertyChanged(nameof(AmtOf3Stars));
                SumforCurRolls();
                PercentCalculation();
            }
        }
        public float Percent6star 
        {
            get
            {
                return _percent6star;
            }
            set
            {
                _percent6star = value;
                OnPropertyChanged(nameof(Percent6star));
            }
        }
        public float Percent5star
        {
            get
            {
                return _percent5star;
            }
            set
            {
                _percent5star = value;
                OnPropertyChanged(nameof(Percent5star));
            }
        }
        public float Percent4star
        {
            get
            {
                return _percent4star;
            }
            set
            {
                _percent4star = value;
                OnPropertyChanged(nameof(Percent4star));
            }
        }
        public float Percent3star
        {
            get
            {
                return _percent3star;
            }
            set
            {
                _percent3star = value;
                OnPropertyChanged(nameof(Percent3star));
            }
        }

        #endregion Properties

        #region Functions
        public void SumforCurRolls()
        {
            CurTotalRolls = _amtOf3Stars + _amtOf4Stars + _amtOf5Stars + _amtOf6Stars;
        }
        public void PercentCalculation()
        {
            Percent6star = divide(_amtOf6Stars, _curTotalRolls) * 100;
            Percent5star = divide(_amtOf5Stars, _curTotalRolls) * 100;
            Percent4star = divide(_amtOf4Stars, _curTotalRolls) * 100;
            Percent3star = divide(_amtOf3Stars, _curTotalRolls) * 100;
        }
        public float divide(float n1, float n2)
        {
            /* n1 divided by n2 */
            if (n2 == 0)
            {
                return (n1 / 1);
            }
            return (n1 / n2);
        }

        private void LoadFunction()
        {
            try
            {
                using (FileStream file = new FileStream(@"ArknightRollTracker.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using var sr = new StreamReader(file);
                    string line = sr.ReadLine();
                    line = sr.ReadLine();
                    if (line == null)
                    {
                        _amtOf6Stars = 0;
                        _amtOf5Stars = 0;
                        _amtOf4Stars = 0;
                        _amtOf3Stars = 0;
                    }
                    else
                    {
                        string[] words = line.Split(",");
                        _amtOf6Stars = float.Parse(words[0]);
                        _amtOf5Stars = float.Parse(words[1]);
                        _amtOf4Stars = float.Parse(words[2]);
                        _amtOf3Stars = float.Parse(words[3]);
                    }
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to Load File.", ex);
            }
            CurTotalRolls = _amtOf3Stars + _amtOf4Stars + _amtOf5Stars + _amtOf6Stars;
            PercentCalculation();
        }

        #endregion Functions

        #region Commands
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new DoCommand(SaveFunction);
                }
                return _saveCommand;
            }
        }

        public void SaveFunction()
        {
            try 
            {
                using(StreamWriter file = new StreamWriter(@"ArknightRollTracker.csv", false))
                {
                    file.WriteLine(_amtOf6Stars + "," + _amtOf5Stars + "," + _amtOf4Stars + "," + _amtOf3Stars);
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Failed to Save File.", ex);
            }
        }


        #endregion Commands
    }
}
