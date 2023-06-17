namespace User.Crud.Wpf.Utilities.Event
{
    public delegate void MethodCompletedEventHandler(object sender, MethodCompletedEventArgs e);

    public class MethodCompletedEventArgs : EventArgs
    {
        public string MethodName { get; set; }
    }
}
