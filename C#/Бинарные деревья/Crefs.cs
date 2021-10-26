using System;
using System.Collections.Generic;
using System.Text;

namespace Tree11
{
    class Crefs
    {
        public string Word { get; set; }
        public List<int> Refs { get; set; }
        public Crefs(List<int> refs, string word)
        {
            Refs = refs;
            Word = word;
        }
        public override string ToString()
        {
            string res = "";
            foreach (var x in Refs)
                res += x.ToString() + " ";
            return ($"Lines: {res}, word: {Word}; ");
        }

    }
}
