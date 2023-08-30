using AutoCAD_WPF_SlopeAddon.Models;
using AutoCAD_WPF_SlopeAddon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCAD_WPF_SlopeAddon.Commands
{
    internal class contLineCommand : CommandsBase
    {

        private readonly userWindowVM _userWindowVM;


        public contLineCommand(userWindowVM userWindowVM)
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
            newLine.SetOrigin(_userWindowVM.UOrigin);
            newLine.DrawLine();

            _userWindowVM.UOrigin = _userWindowVM.UOriginPlusVec;
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
