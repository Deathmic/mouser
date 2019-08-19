using System;
using System.Diagnostics;
using Mouser.ExtensionMethods;
using Mouser.Loggers;

namespace MouserTests.Stubs
{
    public class TestLogger : ILogger
    {
        private const int CLASS_NAME_LENGTH = 20;
        private const int METHOD_NAME_LENGTH = 20;

        public void Debug(string sMessage)
        {
            Console.WriteLine();

            var frame = new StackFrame(1);

            var sClass = frame?.GetMethod()?.DeclaringType?.Name ?? "N/A";
            var sMethod = frame?.GetMethod()?.Name ?? "N/A";

            Console.WriteLine(
                $"{DateTime.Now:u}: {sClass.Max(CLASS_NAME_LENGTH, StringExtensionMethods.MaxCutModes.MidEllipse),-CLASS_NAME_LENGTH} | {sMethod.Max(METHOD_NAME_LENGTH, StringExtensionMethods.MaxCutModes.MidEllipse),-METHOD_NAME_LENGTH} | {sMessage}");
        }
    }
}