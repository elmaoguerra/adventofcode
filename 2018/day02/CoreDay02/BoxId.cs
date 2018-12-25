using System.Collections.Generic;

namespace CoreDay02
{
    public class BoxId
    {
        public readonly HashSet<int> ValueCount;
        public readonly string Id;
        public BoxId(string boxId)
        {
            Id = boxId;
            var dictCount = new Dictionary<char, int>();
            foreach (var c in boxId.ToCharArray())
            {
                if (dictCount.ContainsKey(c))
                    dictCount[c] += 1;
                else
                    dictCount[c] = 1;
            }
            ValueCount = new HashSet<int>(dictCount.Values);
        }

        public string Simmilar(List<BoxId> boxes)
        {
            var simmilar = "";
            foreach (var box in boxes)
            {
                if (!box.Id.Equals(Id))
                {
                    var closer = "";
                    var thatArray = box.Id.ToCharArray();
                    var thisArray = Id.ToCharArray();
                    for (int i = 0; i < Id.Length; i++)
                    {
                        if(thatArray[i] == thisArray[i])
                            closer+=thisArray[i];
                    }

                    if(closer.Length > simmilar.Length)
                        simmilar = closer;
                }
            }

            return simmilar;
        }
    }
}