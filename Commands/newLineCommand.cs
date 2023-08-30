using AutoCAD_WPF_SlopeAddon.Models;
using AutoCAD_WPF_SlopeAddon.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCAD_WPF_SlopeAddon.Commands
{
    public class newLineCommand : CommandsBase
    {
        
        private readonly userWindowVM _userWindowVM;


        public newLineCommand(userWindowVM userWindowVM)
        {
            _userWindowVM = userWindowVM;

            _userWindowVM.PropertyChanged += _userWindowVM_PropertyChanged;
        }



        public override bool CanExecute(object parameter)
        {
            return _userWindowVM.UserLength != 0 && base.CanExecute(parameter);

        }

        public override void Execute(object parameter)
        {

            CustomLine newLine = new CustomLine();
            
            newLine.SetVector(_userWindowVM.UVector);

            newLine.DrawLine();

            _userWindowVM.UOrigin = _userWindowVM.UVector;


        }

        private void _userWindowVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(userWindowVM.UserLength))
            {
                 OnCanExectuedChanged();
            }
        }

    }
}
