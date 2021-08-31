using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Speech.Synthesis;
using System.IO;

namespace TextToSpeech.Modal
{
     public class Speech
     {
        StringBuilder sb;
        public string FiletoReader(string Path)
        {
            sb= new StringBuilder();
            string[] tempdata = File.ReadAllLines(Path);
            foreach(var v in tempdata)
            {
                sb.Append(v+"\n");
            }
            return sb.ToString();
        }

        public void StartSpeech(string text,bool value,VoiceGender type)
        {
            if(value==true)
            {
                PromptBuilder promptBuilder = new PromptBuilder();
                PromptStyle promptStyle = new PromptStyle();
                promptStyle.Volume = PromptVolume.Soft;
                promptStyle.Rate = PromptRate.Slow;
                promptStyle.Emphasis = PromptEmphasis.Moderate;
                promptBuilder.StartStyle(promptStyle);
                promptBuilder.EndStyle();
                promptBuilder.AppendTextWithHint(text, SayAs.SpellOut);
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.SelectVoiceByHints(type);
                speechSynthesizer.Speak(promptBuilder);
            }
            else
            {
                PromptBuilder promptBuilder = new PromptBuilder();
                PromptStyle promptStyle = new PromptStyle();
                promptStyle.Volume = PromptVolume.Soft;
                promptStyle.Rate = PromptRate.Slow;
                promptStyle.Emphasis = PromptEmphasis.Moderate;
                promptBuilder.StartStyle(promptStyle);
                promptBuilder.EndStyle();
                promptBuilder.AppendText(text);
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.SelectVoiceByHints(type);
                speechSynthesizer.Speak(promptBuilder);
            }
        }

     }
}
