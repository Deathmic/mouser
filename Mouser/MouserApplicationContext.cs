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
        private readonly ILogger _logger;
        private readonly Mouser _mouser;

        public MouserApplicationContext()
        {
            _container = Bootstrap();

            _logger = _container.GetInstance<ILogger>();
            _mouser = _container.GetInstance<Mouser>();

            _mouser.Start(LoadSettings() ?? new MouserSettings());

            var formMain = _container.GetInstance<FormMain>();
            formMain.Closed += (sender, args) => Exit();
            formMain.Show();
        }

        private MouserSettings LoadSettings()
        {
            return null; // TODO Implement
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

#if DEBUG
            container.Verify();
#endif

            return container;
        }
    }
}