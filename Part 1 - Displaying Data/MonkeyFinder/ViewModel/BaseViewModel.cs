namespace MonkeyFinder.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    string title;
    bool isBusy;

    public bool IsBusy
    {
        get => isBusy;
        set
        {
            if (isBusy == value)
                return;
            isBusy = value;
            OnPropertyChanged(nameof(IsBusy));
            OnPropertyChanged(nameof(IsNotBusy));
        }
    }

    public bool IsNotBusy => !IsBusy;

    public string Title
    {
        get => title;
        set
        {
            if (title == value)
            {
                return;
            }
            title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
