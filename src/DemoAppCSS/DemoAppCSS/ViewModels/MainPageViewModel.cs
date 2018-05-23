using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DemoAppCSS.Models;
using Xamarin.Forms;

namespace DemoAppCSS.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Properties

        private decimal? _value;

        public decimal? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }


        private decimal? _result;

        public decimal? Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        private string _displayOperation;

        public string DisplayOperation
        {
            get { return _displayOperation; }
            set { SetProperty(ref _displayOperation, value); }
        }

        private bool _hasOperation;

        public bool HasOperation
        {
            get { return _hasOperation; }
            set { SetProperty(ref _hasOperation, value); }
        }

        private Operator? _operation;

        public Operator? Operation
        {
            get { return _operation; }
            set { SetProperty(ref _operation, value); }
        }


        #endregion

        public MainPageViewModel()
        {
            Result = 0;
            HasOperation = false;
        }

        public ICommand KeyPressCommand => new Command<string>(ShowOperation);
        public ICommand ClearCommand => new Command(Clear);

        public ICommand OperatorCommand => new Command<string>(CalculateCommand);

        public ICommand ComputeCommand => new Command(Compute);


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
    }
}
