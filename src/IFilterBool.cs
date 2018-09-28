using System;

namespace CompAndDel {

    public interface IFilterBool : IFilter {


        bool FaceOrNot { get; }

        IPicture Filter (IPicture image);
    }
}