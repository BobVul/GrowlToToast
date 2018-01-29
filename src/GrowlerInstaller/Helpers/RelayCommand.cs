using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GrowlerInstaller.Helpers
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteFunction(parameter);
        }

        public void Execute(object parameter)
        {
            executeFunction(parameter);
        }

        private Action<object> executeFunction;
        private Func<object, bool> canExecuteFunction;

        /// <summary>
        /// Runs executeFunction on command activation. The command is always enabled. <see cref="System.Windows.Input.ICommand"/>
        /// </summary>
        /// <param name="executeFunction">A delegate that performs an action</param>
        public RelayCommand(Action executeFunction) : this(executeFunction, () => true) { }

        /// <summary>
        /// Runs executeFunction on command activation. Checks canActivateFunction to see if the command should be enabled. <see cref="System.Windows.Input.ICommand"/>
        /// </summary>
        /// <param name="executeFunction">A delegate that performs an action</param>
        /// <param name="canExecuteFunction">A delegate that returns a bool indicating whether the command can be executed</param>
        public RelayCommand(Action executeFunction, Func<bool> canExecuteFunction) : this(_ => executeFunction(), _ => canExecuteFunction()) { }

        /// <summary>
        /// Runs executeFunction on command activation. Checks canActivateFunction to see if the command should be enabled. <see cref="System.Windows.Input.ICommand"/>
        /// </summary>
        /// <param name="executeFunction">A delegate that takes one parameter and performs an action</param>
        /// <param name="canExecuteFunction">A delegate that takes one parameter and returns a bool indicating whether the command can be executed</param>
        public RelayCommand(Action<object> executeFunction, Func<object, bool> canExecuteFunction)
        {
            this.executeFunction = executeFunction;
            this.canExecuteFunction = canExecuteFunction;
        }
    }
}
