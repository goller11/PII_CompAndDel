using System;

namespace CompAndDel.Filters {
    public interface IFilterBool : IFilter {
        bool FaceOrNot {get;}

        IPicture Filter(IPicture image);
    }
}