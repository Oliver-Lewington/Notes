using CommunityToolkit.Mvvm.ComponentModel;

namespace Notes.ViewModel;
public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    string? _title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;

    [ObservableProperty]
    bool _isRefreshing;

    public bool IsNotBusy => !IsBusy;
}
