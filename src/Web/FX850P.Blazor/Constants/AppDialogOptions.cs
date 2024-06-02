using MudBlazor;

namespace FX850P.Blazor.Constants
{
    public static class AppDialogOptions
    {
        public static DialogOptions FullScreenDialog()
        {
            return new DialogOptions() { MaxWidth = MaxWidth.Large, FullWidth = true, DisableBackdropClick = true, FullScreen = true, CloseButton = true, CloseOnEscapeKey = true, Position = DialogPosition.Center };
        }

        public static DialogOptions NormalDialog()
        {
            return new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true, CloseButton = true, CloseOnEscapeKey = true, Position = DialogPosition.Center };
        }

    }
}
