using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamEssentials_Showcase.Features.TextToSpeech
{
    public class TextToSpeechPageVM : BasePageViewModel
    {
        public string Text { get; set; }

        public ICommand TextSpeechCommand { get; set; }

        public TextToSpeechPageVM()
        {
            TextSpeechCommand = new Command(TextSpeechAction);
        }

        private async void TextSpeechAction(object obj)
        {
            if(!String.IsNullOrEmpty(Text))
            {
                await Xamarin.Essentials.TextToSpeech.SpeakAsync(Text);
            }
        }
    }
}
