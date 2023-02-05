namespace MonkeyFinder.ViewModel;
using MonkeyFinder.Services;


public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;

    public RelayCommand GetMonkeysCommand { get; }
    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
        this.GetMonkeysCommand = new RelayCommand(async ()  => await GetMonkeysAsync());
       
    }


    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();

            //Clear if not empty
            if (Monkeys.Count > 0)
                Monkeys.Clear();
            
                
            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
