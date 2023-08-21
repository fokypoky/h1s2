using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using H1S2.Infrastructure.Commands;
using H1S2.Models.Terminals.Implementation;
using H1S2.Models.Terminals.Interfaces;
using H1S2.ViewModels.Base;

namespace H1S2.ViewModels.WindowsViewModels;

public class MainWindowViewModel : ViewModel
{
    private string _inputText;
    private string _outputText = "Не расчитан";
    private string _language;
    private List<ITerminal> _terminals = new List<ITerminal>();
    
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

    public void Calculate(object parameter)
    {
        var textCleaner = new StringBuilder(InputText);
        textCleaner.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")
            .Replace("+", " + ").Replace("-", " - ")
            .Replace("*", " * ").Replace("/", " / ")
            .Replace("^", " ^ ");
        
        var stringTerminals = textCleaner.ToString().Split(" ").ToList();
        stringTerminals.RemoveAll(c => c == "");
        
        foreach (var terminal in stringTerminals)
        {
            switch (terminal.ToLower())
            {
                case "start":
                    _terminals.Add(new StartTerminal());
                    break;
                case "stop":
                    _terminals.Add(new StopTerminal());
                    break;
            }
        }

        #region Начальная проверка

        if (_terminals.Count == 0)
        {
            OutputText = "Ничего не введено";
            return;
        }
        
        if (_terminals.ElementAt(0) is not StartTerminal)
        {
            OutputText = "Первое слово не 'Start'";
            return;
        }

        if (_terminals.ElementAt(_terminals.Count - 1) is not StopTerminal)
        {
            OutputText = "Последнее слово не 'Stop'";
            return;
        }
        #endregion
        
    }

    #endregion

    public MainWindowViewModel()
    {
        var sBuilder = new StringBuilder();
        
        using (var stream = new FileStream("Language.txt", FileMode.Open))
        {
            using (var streamReader = new StreamReader(stream))
            {
                while (!streamReader.EndOfStream)
                {
                    sBuilder.Append(streamReader.ReadLine() + "\n");
                }
            }
        }

        Language += sBuilder.ToString();
    }
}