namespace OrdemServico.Web.Services
{
    public class TitleService
    {
        public event Action? OnTitleChanged;
        private string _title = "Home";

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnTitleChanged?.Invoke();
                }
            }
        }
    }
}