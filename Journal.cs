using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class Journal
    {
        private List<JournalEntry> journalEntries = new List<JournalEntry>();
        public void OnStudentChanged(object source, StudentListHandlerEventArgs args)
        {
            JournalEntry journalEntry = new JournalEntry(args.NameOfCollections, args.TypeOfChange, args.Student);
            journalEntries.Add(journalEntry);
        }
        public override string ToString()
        {
            string str = "";
            foreach(JournalEntry je in journalEntries)
            {
                str += je.ToString() + "\n";
            }
            return str;
        }
    }
}
