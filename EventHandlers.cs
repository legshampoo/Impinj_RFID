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

        //might change these later, they are also used in writer class, not sure exactly what for
        const ushort EPC_OP_ID = 123;
        const ushort PC_BITS_OP_ID = 321;

        public static bool writingTag = false;

        public static void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            foreach (Tag tag in report)
            {
                if (!writingTag)
                {
                    string tagInfo = Formatting.FormatRawTagData(tag);
                    CheckTagMatch(tag);
                    Display.UpdateTagConsole(tagInfo);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("handler: about to write tag");
                    
                    TagWriter.writer.Write(tag);
                }
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

        
        public static void OnTagOpComplete(ImpinjReader reader, TagOpReport report)
        {
            // Loop through all the completed tag operations.
            foreach (TagOpResult result in report)
            {
                // Was this completed operation a tag write operation?
                if (result is TagWriteOpResult)
                {
                    // Cast it to the correct type.
                    TagWriteOpResult writeResult = result as TagWriteOpResult;
                    if (writeResult.OpId == EPC_OP_ID)
                        Console.WriteLine("Write to EPC complete : {0}", writeResult.Result);
                    else if (writeResult.OpId == PC_BITS_OP_ID)
                        Console.WriteLine("Write to PC bits complete : {0}", writeResult.Result);

                    // Print out the number of words written
                    Console.WriteLine("Number of words written : {0}", writeResult.NumWordsWritten);
                }
            }
            reader.TagsReported += EventHandlers.OnTagsReported;
        }

    }
}
