namespace ChessClient.MVVM.View
{
    public static class ControlOptions
    {
        public static void SetEnabled(this Control control, bool state)
        {
            control.Enabled = state;
            control.Visible = state;
        }
        
        public static void InvokeOnThread(this Form form, Action action)
        {
            if (form.InvokeRequired)
                form.Invoke(action);
        }
    }
}
