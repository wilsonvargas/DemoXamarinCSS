using DemoAppCSS.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoAppCSS.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Properties

        public string DisplayOperation
        {
            get { return _displayOperation; }
            set { SetProperty(ref _displayOperation, value); }
        }

        public bool HasOperation
        {
            get { return _hasOperation; }
            set { SetProperty(ref _hasOperation, value); }
        }

        public Operator? Operation
        {
            get { return _operation; }
            set { SetProperty(ref _operation, value); }
        }

        public decimal? Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        public decimal? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        private string _displayOperation;
        private bool _hasOperation;
        private Operator? _operation;
        private decimal? _result;
        private decimal? _value;

        #endregion Properties

        public MainPageViewModel()
        {
            Result = 0;
            HasOperation = false;
        }

        public ICommand ClearCommand => new Command(Clear);
        public ICommand ComputeCommand => new Command(Compute);
        public ICommand KeyPressCommand => new Command<string>(ShowOperation);
        public ICommand OperatorCommand => new Command<string>(CalculateCommand);

        public decimal Calculate()
        {
            if (Result.HasValue
                && Operation.HasValue
                && Value.HasValue)
            {
                switch (Operation.Value)
                {
                    case Operator.Addition:
                        return (Value.Value + Result.Value);

                    case Operator.Subtraction:
                        return (Value.Value - Result.Value);

                    case Operator.Multiplication:
                        return (Value.Value * Result.Value);

                    case Operator.Division:
                        return (Value.Value / Result.Value);

                    default:
                        return 0;
                }
            }
            return 0;
        }

        private void CalculateCommand(string op)
        {
            DisplayOperation += Result;
            switch (op)
            {
                case "+":
                    Operation = Operator.Addition;
                    DisplayOperation += " + ";
                    break;

                case "-":
                    Operation = Operator.Subtraction;
                    DisplayOperation += " - ";
                    break;

                case "×":
                    Operation = Operator.Multiplication;
                    DisplayOperation += " × ";
                    break;

                case "÷":
                    Operation = Operator.Division;
                    DisplayOperation += " ÷ ";
                    break;

                default:
                    throw new ArgumentException("Invalid Operator!");
            }
            if (Value.HasValue)
            {
                Result = Calculate();
                Value = Result;
            }
            else
            {
                Value = Result;
            }
        }

        private void Clear()
        {
            Result = 0;
            Value = null;
            DisplayOperation = string.Empty;
        }

        private void Compute()
        {
            Result = Calculate();
            DisplayOperation = string.Empty;
            Value = null;
        }

        private void ShowOperation(string value)
        {
            decimal result;
            if (Decimal.TryParse(value, out result))
            {
                Result = result;
            }
        }
    }
}
