using System;
using System.Windows.Input;

namespace BirdsAI
{
	class CommonCommand : ICommand
	{
		private Action<object> Executer { get; }
		private Predicate<object> CanExecuter { get; }

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public CommonCommand(Action<object> execute, Predicate<object> canExecute = null)
		{
			Executer = execute;
			CanExecuter = canExecute;
		}

		public bool CanExecute(object parameter = null)
		{
			return CanExecuter(parameter);
		}

		public void Execute(object parameter = null)
		{
			Executer(parameter);
		}
	}
}
