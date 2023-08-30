using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoCAD_WPF_SlopeAddon.Commands
{
    public abstract class CommandsBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
        
        protected void OnCanExectuedChanged()
        {
           CanExecuteChanged?.Invoke(this, new EventArgs());        
        }
    }
}
