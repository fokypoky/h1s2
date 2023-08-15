using System.Windows.Input;
using H1S2.Infrastructure.Commands;
using H1S2.ViewModels.Base;

namespace H1S2.ViewModels.WindowsViewModels;

public class MainWindowViewModel : ViewModel
{
    private string _inputText;
    private string _outputText = "Не расчитан";
    private string _language;
    
    #region Public properties
    public string InputText
    {
        get => _inputText;
        set => SetField(ref _inputText, value);
    }
    public string OutputText
    {
        get => _outputText;
        set => SetField(ref _outputText, value);
    }
    public string Language
    {
        get => _language;
        set => SetField(ref _language, value);
    }
    #endregion

    #region Commands

    public ICommand CalculateCommand
    {
        get => new RelayCommand(Calculate);
    }
    #endregion

    #region Methods

    public void Calculate(object parameter){}

    #endregion
}