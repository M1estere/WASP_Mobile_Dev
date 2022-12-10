namespace MauiApp1.Model
{
    internal class OptionHandler
    {
        private char _action;
        private double? _prevNumber;

        public OptionHandler() {}

        public void ActionClicked(Label label, string text)
        {
            _prevNumber = Convert.ToDouble(label.Text);
            _action = Convert.ToChar(text);
        }

        public string EqClicked(Label label)
        {
            if (label.Text.Split('\n').Last() == "" || _prevNumber is null)
                return "";

            string res = _action switch
            {
                '+' => (_prevNumber + Convert.ToDouble(label.Text.Split('\n').Last())).ToString(),
                '÷' => (_prevNumber / Convert.ToDouble(label.Text.Split('\n').Last())).ToString(),
                '×' => (_prevNumber * Convert.ToDouble(label.Text.Split('\n').Last())).ToString(),
                '-' => (_prevNumber - Convert.ToDouble(label.Text.Split('\n').Last())).ToString(),
                _ => throw new NotImplementedException("This action was not implemented")
            };

            return res;
        }
    }
}
