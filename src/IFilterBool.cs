using System;

namespace CompAndDel.Filters {
    public interface IFilterBool : IFilter {
        bool FaceOrNot { get; set;}

        IPicture Filter(IPicture image);
    }
}