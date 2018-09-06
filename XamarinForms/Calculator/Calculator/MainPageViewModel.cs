using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private decimal _total = 0;
        private string _display = String.Empty;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        public MainPageViewModel()
        {
            ButtonPressedCommand = new Command<string>(HandleButtonPressedCommand);   
        }

        #region Properties
        public decimal Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }
        public string Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;

                if(PropertyChanged != null){
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Display)));
                }
            }
        }

        public ICommand ButtonPressedCommand { get; protected set; }
        #endregion

        #region Methods
        private void HandleButtonPressedCommand(string enteredValue){
            Display = Display + enteredValue;
        }
        #endregion


    }
}
