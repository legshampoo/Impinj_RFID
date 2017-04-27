using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Impinj.OctaneSdk;

namespace _45PPC_RFID
{
    public class Writer
    {
        const ushort EPC_OP_ID = 123;
        const ushort PC_BITS_OP_ID = 321;

        public Writer()
        {
            
        }

        private void ConfigureEpcParams()
        {
           
        }

        public void Write(Tag tag)
        {
            //disable the on tags reported event handler while we write
            Program.App.r.reader.TagsReported -= EventHandlers.OnTagsReported;

            //query the current tags epc
            string currentEpc = tag.Epc.ToHexString();
            ushort currentPcBits = tag.PcBits;

            //grab the user input for the new tag epc
            TextBox userEpc = Program.App.tagWriter.Controls["UserInput"] as TextBox;
            string newEpc = userEpc.Text;

            try
            {
                if ((currentEpc.Length % 4 != 0) || (newEpc.Length % 4 != 0))
                {
                    //check that the length of the new epc is a multiple of 4, if it's not:
                    throw new Exception("EPC's must be a multiple of 16 bits (4 hex chars)");
                }
                else
                {
                    //if it is the rigth length, notify that we are beginning the write operation
                    System.Diagnostics.Debug.WriteLine("Adding a write operation to change the EPC from :");
                    Console.WriteLine("{0} to {1}\n", currentEpc, newEpc);
                }
            }
            catch (OctaneSdkException err)
            {
                System.Diagnostics.Debug.WriteLine("Octane SDK exception: " + err.Message);
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + err.Message);
            }

            //System.Diagnostics.Debug.WriteLine("writing: " + newEpc);

            //disable the tag reader for now
            EventHandlers.writingTag = false;

            //create a tag op sequence
            TagOpSequence seq = new TagOpSequence();

            //specify a target tag based on the EPC
            seq.TargetTag.MemoryBank = MemoryBank.Epc;
            seq.TargetTag.BitPointer = BitPointers.Epc;
            seq.TargetTag.Data = currentEpc;

            //create a tag write operation to change the EPC
            TagWriteOp writeEpc = new TagWriteOp();
            writeEpc.Id = EPC_OP_ID;

            //write EPC to memory
            writeEpc.MemoryBank = MemoryBank.Epc;

            //specify the new EPC data
            writeEpc.Data = TagData.FromHexString(newEpc);
            
            //start writing at word 2 (word 0 = CRC, word 1 = PC bits)
            writeEpc.WordPointer = WordPointers.Epc;

            //add this tag write op to the tag operation sequence
            seq.Ops.Add(writeEpc);

            if(currentEpc.Length != newEpc.Length)
            {
                // We need adjust the PC bits and write them back to the 
                // tag because the length of the EPC has changed.

                // Adjust the PC bits (4 hex characters per word).
                ushort newEpcLenWords = (ushort)(newEpc.Length / 4);
                ushort newPcBits = PcBits.AdjustPcBits(currentPcBits, newEpcLenWords);

                System.Diagnostics.Debug.WriteLine("Adding a write operation to change the PC bits from :");
                System.Diagnostics.Debug.WriteLine("{0} to {1}\n", currentPcBits.ToString("X4"), newPcBits.ToString("X4"));

                TagWriteOp writePc = new TagWriteOp();
                writePc.Id = PC_BITS_OP_ID;

                //the pc bits are in the epc memory bank
                writePc.MemoryBank = MemoryBank.Epc;
                //specify the dta to write (the modified PC bits)
                writePc.Data = TagData.FromWord(newPcBits);
                //start writing at the start of the pc bits
                writePc.WordPointer = WordPointers.PcBits;
                //add this tag write op to the tag operation sequence
                seq.Ops.Add(writePc);
            }

            //add the tag operation sequence to the reader
            Program.App.r.reader.AddOpSequence(seq);
        }
    }
}
