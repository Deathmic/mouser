using System;
using System.Windows.Forms;
using Mouser.KeyboardCapturers;
using Mouser.Loggers;
using Mouser.MouseWrappers;
using SimpleInjector;

namespace Mouser
{
    public class MouserApplicationContext : ApplicationContext
    {
        private readonly Container _container;
        private readonly FormMainViewModel _formMainViewModel;
        private readonly ILogger _logger;
        private readonly Mouser _mouser;
        private readonly ISettingsRepository _settingsRepository;

        public MouserApplicationContext()
        {
            _container = Bootstrap();

            _logger = _container.GetInstance<ILogger>();
            _mouser = _container.GetInstance<Mouser>();
            _settingsRepository = _container.GetInstance<ISettingsRepository>();

            var formMain = _container.GetInstance<FormMain>();
            formMain.Closed += (sender, args) => Exit();

            _formMainViewModel = new FormMainViewModel(formMain) {Settings = _settingsRepository.Load()};
            _formMainViewModel.MouserSignalSent += FormMainViewModelOnMouserSignalSent;
            _formMainViewModel.ShowView();
        }

        private void FormMainViewModelOnMouserSignalSent(object sender, MouserSignalEventArgs e)
        {
            switch (e.Signal)
            {
                case Mouser.Signals.Start:
                    _settingsRepository.Save(_formMainViewModel.Settings);
                    _mouser.Start(_formMainViewModel.Settings);
                    break;
                case Mouser.Signals.Stop:
                    _mouser.Stop();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Exit()
        {
            _logger.Debug("Exiting application.");
            _container.Dispose();
            Application.Exit();
        }

        private Container Bootstrap()
        {
            var container = new Container();

            container.Register<FormMain>(Lifestyle.Singleton);
            container.Register<Mouser>(Lifestyle.Singleton);
            container.Register<IMouseWrapper, User32_MouseEvent_MouseWrapper>(Lifestyle.Singleton);
            container.Register<IKeyboardCapturer, KeyboardCapturer>(Lifestyle.Singleton);
            container.Register<ILogger, DebugLogger>(Lifestyle.Singleton);
            container.Register<ISettingsRepository, JsonSettingsRepository>(Lifestyle.Singleton);

#if DEBUG
            container.Verify();
#endif

            return container;
        }
    }
}