using MudBlazor;

namespace FX850P.Blazor.Constants
{
    public static class AppDialogOptions
    {
        public static DialogOptions FullScreenDialog()
        {
            return new DialogOptions() { MaxWidth = MaxWidth.Large, FullWidth = true, BackdropClick = false, FullScreen = true, CloseButton = true, CloseOnEscapeKey = true, Position = DialogPosition.Center };
        }

        public static DialogOptions NormalDialog()
        {
            return new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true, BackdropClick = false, CloseButton = true, CloseOnEscapeKey = true, Position = DialogPosition.Center };
        }

    }
}
