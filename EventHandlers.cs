using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impinj.OctaneSdk;

namespace _45PPC_RFID
{
    class EventHandlers
    {
        public static void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            foreach (Tag tag in report)
            {
                    string tagInfo = Formatting.FormatRawTagData(tag);
                    CheckTagMatch(tag);
                    Display.UpdateTagConsole(tagInfo);
            }
        }

        private static void CheckTagMatch(Tag tag)
        {
            string epc = tag.Epc.ToString();

            if(Program.App.tagObjects.Any(matched => matched.Epc == epc))
            {
                TagObject t = Program.App.tagObjects.First(s => s.Epc == epc);
                
                t.StartTimer();
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("not found");
            }
            
        }
        
    }
}
