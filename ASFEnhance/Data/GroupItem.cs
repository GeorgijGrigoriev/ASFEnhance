﻿namespace ASFEnhance.Data
{
    internal sealed record GroupItem
    {
        public string Name { get; set; }
        public ulong GroupID { get; set; }

        public GroupItem(string name, ulong groupID)
        {
            Name = name;
            GroupID = groupID;
        }
    }
}
