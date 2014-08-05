using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace HookingProgram
{
    class keySearcher
    {
        private String key;
        private Hashtable keyTable;
     
        public keySearcher(String key, Hashtable keyTable)
        {
            this.key = key;
            this.keyTable = keyTable;
        }

        public String getKeyString()
        {
            if (keyTable.ContainsKey(key))
                return keyTable[key].ToString();
            else
                return key;
        }
    }
}
