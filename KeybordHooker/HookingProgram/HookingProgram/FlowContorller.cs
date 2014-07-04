using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HookingProgram
{
    class FlowContorller
    {
        private Hashtable keyTable;
        private String result;

        public void process(String key)
        {
            keyTable = new KeyTableMaker().getKeyTable();

            keySearcher searcher = new keySearcher(key, keyTable);
            result = searcher.getKeyString();
            Console.WriteLine(result);
        }
    }
}
