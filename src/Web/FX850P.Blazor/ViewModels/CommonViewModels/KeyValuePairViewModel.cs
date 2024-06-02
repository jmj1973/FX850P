﻿namespace FX850P.Blazor.ViewModels.CommonViewModels
{
    public class KeyValuePairViewModel<TType>
    {
        public TType Id { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
