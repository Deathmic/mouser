namespace Mouser.MouseWrappers
{
    public interface IMouseWrapper
    {
        void Move(int iRight, int iDown);
        void ButtonDown(Mouser.MouseButtons mouseButton);
        void ButtonUp(Mouser.MouseButtons mouseButton);
    }
}