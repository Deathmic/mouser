using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using Mouser;
using Mouser.KeyboardCapturers;
using Mouser.MouseWrappers;
using MouserTests.Stubs;
using NUnit.Framework;

namespace MouserTests
{
    [TestFixture]
    public class MouserTests
    {
        [Test]
        [TestCaseSource(typeof(MouserTests_TestCases), nameof(MouserTests_TestCases.TestCases))]
        public void PerformMouseAction_AllActions_CallsCorrectMouseWrapperMethod(Mouser.Mouser.MouseActions mouseAction,
            Dictionary<Expression<Action<IMouseWrapper>>, Times> expectedMouseWrapperActions)
        {
            var mockKeyboardCapturer = new Mock<IKeyboardCapturer>();
            var mockMouseWrapper = new Mock<IMouseWrapper>();

            var settings = new MouserSettings
            {
                FixedMovePixels = 1,
                MoveMode = MouserSettings.MoveModes.FixedSpeed
            };

            var mouser = new Mouser.Mouser(mockMouseWrapper.Object, mockKeyboardCapturer.Object, new TestLogger());
            mouser.SetSettings(settings);

            mouser.PerformMouseAction(mouseAction);

            foreach (var kvp in expectedMouseWrapperActions) mockMouseWrapper.Verify(kvp.Key, kvp.Value);
        }
    }

    public class MouserTests_TestCases
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MoveUpLeft,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.Move(-1, -1), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MoveUp,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.Move(0, -1), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MoveUpRight,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.Move(1, -1), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MoveRight,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.Move(1, 0), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MoveDownRight,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.Move(1, 1), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MoveDown,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.Move(0, 1), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MoveDownLeft,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.Move(-1, 1), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MoveLeft,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.Move(-1, 0), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.LeftClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Left), Times.Once()},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Left), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.RightClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Right), Times.Once()},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Right), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MiddleClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Middle), Times.Once()},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Middle), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button4Click,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button4), Times.Once()},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button4), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button5Click,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button5), Times.Once()},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button5), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button6Click,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button6), Times.Once()},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button6), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button7Click,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button7), Times.Once()},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button7), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.LeftDoubleClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Left), Times.Exactly(2)},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Left), Times.Exactly(2)}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.RightDoubleClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Right), Times.Exactly(2)},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Right), Times.Exactly(2)}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MiddleDoubleClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Middle), Times.Exactly(2)},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Middle), Times.Exactly(2)}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button4DoubleClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button4), Times.Exactly(2)},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button4), Times.Exactly(2)}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button5DoubleClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button5), Times.Exactly(2)},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button5), Times.Exactly(2)}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button6DoubleClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button6), Times.Exactly(2)},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button6), Times.Exactly(2)}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button7DoubleClick,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button7), Times.Exactly(2)},
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button7), Times.Exactly(2)}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.LeftDown,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Left), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.RightDown,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Right), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MiddleDown,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Middle), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button4Down,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button4), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button5Down,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button5), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button6Down,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button6), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button7Down,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonDown(Mouser.Mouser.MouseButtons.Button7), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.LeftUp,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Left), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.RightUp,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Right), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.MiddleUp,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Middle), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button4Up,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button4), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button5Up,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button5), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button6Up,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button6), Times.Once()}
                    });
                yield return new TestCaseData(
                    Mouser.Mouser.MouseActions.Button7Up,
                    new Dictionary<Expression<Action<IMouseWrapper>>, Times>
                    {
                        {wrapper => wrapper.ButtonUp(Mouser.Mouser.MouseButtons.Button7), Times.Once()}
                    });
            }
        }
    }
}