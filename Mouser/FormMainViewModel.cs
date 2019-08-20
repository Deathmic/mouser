using System;

namespace Mouser
{
    public class FormMainViewModel
    {
        private readonly FormMain _formMain;

        public FormMainViewModel(FormMain formMain)
        {
            _formMain = formMain;
        }

        public MouserSettings Settings { get; set; }

        public event EventHandler<MouserSignalEventArgs> MouserSignalSent;

        public void ShowView()
        {
            _formMain.Show();
        }
    }
}