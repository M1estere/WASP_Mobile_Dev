using MauiApp1.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiApp1.ViewModel
{
    internal class OptionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private OptionHandler _option;
        private Label _label;

        public ICommand DoDigitClick => new Command<string>(ClickDigit);
        public ICommand DoActionClick => new Command<string>(ClickAction);
        public ICommand DoEqClick => new Command<string>(ClickEq);
        public ICommand DoResetClick => new Command<string>(ClickReset);

        public OptionViewModel(Label label)
        {
            _option = new OptionHandler();
            _label = label;
        }

        private void ClickDigit(string text)
        {
            _label.Text += text;
        }

        private void ClickAction(string text)
        {
            _option.ActionClicked(_label, text);
            _label.Text += '\n';
        }

        private void ClickEq(string text)
        {
            _label.Text = _option.EqClicked(_label);
        }

        private void ClickReset(string text)
        {
            _label.Text = "";
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
