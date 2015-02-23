namespace Zen.Ux
{
    // marker interface for views
    public interface IView
    {
        void Close();
        void Show();
        bool? ShowDialog();
    }
}